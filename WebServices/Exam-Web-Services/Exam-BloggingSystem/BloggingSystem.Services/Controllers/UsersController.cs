using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using BloggingSystem.Data;
using BloggingSystem.Models;
using BloggingSystem.Services.Attributes;
using BloggingSystem.Services.Models;

namespace BloggingSystem.Services.Controllers
{
    public class UsersController : BaseApiController
    {
        private const int MinUsernameLength = 6;

        private const int MaxUsernameLength = 30;

        private const int MinDisplayNameLength = 6;

        private const int MaxDisplayNamLength = 30;

        private const string ValidUsernameCharacters = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";

        private const string ValidDisplayNameCharacters = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_. -";

        private const string SessionKeyChars = "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";

        private const int SessionKeyLength = 50;

        private const int AuthCodeLength = 40;

        private static readonly Random rand = new Random();

        [ActionName("register")]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new BloggingSystemContext();
                    using (context)
                    {
                        this.ValidateUsername(model.Username);
                        this.ValidateDisplayName(model.DisplayName);
                        this.ValidateAuthCode(model.AuthCode);
                        var usernameToLower = model.Username.ToLower();
                        var displayNameToLower = model.DisplayName.ToLower();
                        var user = context.Users.FirstOrDefault(
                            usr => usr.Username == usernameToLower
                            || usr.DisplayName.ToLower() == displayNameToLower);

                        if (user != null)
                        {
                            throw new InvalidOperationException("Users exists");
                        }

                        user = new User()
                        {
                            Username = usernameToLower,
                            DisplayName = model.DisplayName,
                            AuthCode = model.AuthCode
                        };

                        context.Users.Add(user);
                        context.SaveChanges();

                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        context.SaveChanges();

                        var loggedModel = new LoggedUserModel()
                        {
                            DisplayName = user.DisplayName,
                            SessionKey = user.SessionKey
                        };

                        var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);
                        return response;
                    }
                });

            return responseMsg;
        }

        [ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  var context = new BloggingSystemContext();
                  using (context)
                  {
                      this.ValidateUsername(model.Username);
                      this.ValidateAuthCode(model.AuthCode);
                      var usernameToLower = model.Username.ToLower();
                      var user = context.Users.FirstOrDefault(
                          usr => usr.Username == usernameToLower
                          && usr.AuthCode == model.AuthCode);

                      if (user == null)
                      {
                          throw new InvalidOperationException("Invalid username or password");
                      }

                      if (user.SessionKey == null)
                      {
                          user.SessionKey = this.GenerateSessionKey(user.Id);
                          context.SaveChanges();
                      }

                      var loggedModel = new LoggedUserModel()
                      {
                          DisplayName = user.DisplayName,
                          SessionKey = user.SessionKey
                      };

                      var response = this.Request.CreateResponse(HttpStatusCode.Created, loggedModel);
                      return response;
                  }
              });

            return responseMsg;
        }

        [ActionName("logout")]
        public HttpResponseMessage PutLogoutUser([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystemContext();
                using (context)
                {
                    var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                    if (user == null)
                    {
                        var errorMessage = "User is already logged out or does not esits!";
                        var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessage);
                        return errResponse;
                    }

                    user.SessionKey = null;
                    context.SaveChanges();
                }

                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
            return responseMsg;
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder skeyBuilder = new StringBuilder(SessionKeyLength);
            skeyBuilder.Append(userId);
            while (skeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyChars.Length);
                skeyBuilder.Append(SessionKeyChars[index]);
            }

            return skeyBuilder.ToString();
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != AuthCodeLength)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted");
            }
        }

        private void ValidateDisplayName(string displayName)
        {
            if (displayName == null)
            {
                throw new ArgumentNullException("DisplayName cannot be null");
            }
            else if (displayName.Length < MinDisplayNameLength)
            {
                throw new ArgumentOutOfRangeException(string.Format("Displayname must be at least {0} characters long", MinUsernameLength));
            }
            else if (displayName.Length > MaxDisplayNamLength)
            {
                throw new ArgumentOutOfRangeException(string.Format("Username must be less than {0} characters long", MaxUsernameLength));
            }
            else if (displayName.Any(ch => !ValidDisplayNameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Username must contain only Latin letters, digits, space, -.,_");
            }
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null");
            }
            else if (username.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be at least {0} characters long",
                    MinUsernameLength));
            }
            else if (username.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be less than {0} characters long",
                    MaxUsernameLength));
            }
            else if (username.Any(ch => !ValidUsernameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Username must contain only Latin letters, digits .,_");
            }
        }
    }
}
