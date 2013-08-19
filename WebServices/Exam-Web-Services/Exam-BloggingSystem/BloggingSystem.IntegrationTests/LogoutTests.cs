using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using BloggingSystem.Services.Controllers;
using System.Collections.Generic;
using System.Web.Http;
using BloggingSystem.Services.Models;
using Newtonsoft.Json;
using System.Net;

namespace BloggingSystem.IntegrationTests
{
    [TestClass]
    public class LogoutTests
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {

            var type = typeof(PostsController);
            tran = new TransactionScope();

            var routes = new List<Route>
            {
                new Route(
                    "TagsApi", 
                    "api/tags/{tagId}/posts",
                 new { controller = "tags", action = "posts"}
                 ),
                new Route( 
                    "PostsApi", 
                    "api/posts/{postId}/comment",
                 new { controller = "posts", action = "comment"}
                ),  
                new Route(
                    "UsersApi",
                    "api/users/{action}",
                    new { controller = "users"}
                    ),          
                new Route(
                    "DefaultApi",
                    "api/{controller}/{id}",
                    new { id = RouteParameter.Optional }),
            };

            this.httpServer = new InMemoryHttpServer("http://localhost/", routes);
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void Logout_Valid_User_And_Should_Return_OK()
        {
            var testUser = RegisterValidUser();

            var response = this.httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(testUser.DisplayName, userModel.DisplayName);
            Assert.IsNotNull(userModel.SessionKey);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            response = this.httpServer.Put("api/users/logout", 1, headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void Logout_Wrong_SeesionKey_Return_BadRequest()
        {
            var testUser = RegisterValidUser();

            var response = this.httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(testUser.DisplayName, userModel.DisplayName);
            Assert.IsNotNull(userModel.SessionKey);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            userModel.SessionKey = "wrongsessionkey";

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            response = this.httpServer.Put("api/users/logout", 1, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Logout_Double_Wrong_SeesionKey_Return_BadRequest()
        {
            var testUser = RegisterValidUser();

            var response = this.httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(testUser.DisplayName, userModel.DisplayName);
            Assert.IsNotNull(userModel.SessionKey);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            response = this.httpServer.Put("api/users/logout", 1, headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            // Double logout
            response = this.httpServer.Put("api/users/logout", 1, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Logout_Empty_SeesionKey_Return_BadRequest()
        {
            string sessionKey = null;

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;
            var response = this.httpServer.Put("api/users/logout", 1, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private static UserModel RegisterValidUser()
        {
            var testUser = new UserModel()
            {
                Username = "username",
                DisplayName = "display name",
                AuthCode = new string('b', 40)
            };
            return testUser;
        }
      
    }
}
