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
    public class RegisterTests
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
        public void Register_Valid_User_Shoud_Create_And_Return_Created()
        {
            var testUser = new UserModel()
            {
                Username = "username",
                DisplayName = "display name",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(testUser.DisplayName, userModel.DisplayName);
            Assert.IsNotNull(userModel.SessionKey);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void Register_NULL_User_Shoud_Return_BadRequest()
        {
            var testUser = new UserModel() { };

            var response = this.httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(userModel.DisplayName, null);
            Assert.AreEqual(userModel.SessionKey, null);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_Invalid_UserName_Shoud_Return_BadRequest()
        {
            var testUser = new UserModel()
            {
                Username = "nm",
                DisplayName = "display name",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(userModel.DisplayName, null);
            Assert.AreEqual(userModel.SessionKey, null);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_Null_UserName_Shoud_Return_BadRequest()
        {
            var testUser = new UserModel()
            {
                Username = null,
                DisplayName = "display name",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(userModel.DisplayName, null);
            Assert.AreEqual(userModel.SessionKey, null);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_Invalid_DisplayName_Shoud_Return_BadRequest()
        {
            var testUser = new UserModel()
            {
                Username = "validusername",
                DisplayName = "dn",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(userModel.DisplayName, null);
            Assert.AreEqual(userModel.SessionKey, null);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_NULL_DisplayName_Shoud_Return_BadRequest()
        {
            var testUser = new UserModel()
            {
                Username = "validusername",
                DisplayName = null,
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(userModel.DisplayName, null);
            Assert.AreEqual(userModel.SessionKey, null);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_Invalid_AuthCode_Shoud_Return_BadRequest()
        {
            var testUser = new UserModel()
            {
                Username = "validusername",
                DisplayName = "dn",
                AuthCode = new string('b', 20)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(userModel.DisplayName, null);
            Assert.AreEqual(userModel.SessionKey, null);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_NULL_AuthCode_Shoud_Return_BadRequest()
        {
            var testUser = new UserModel()
            {
                Username = "validusername",
                DisplayName = "dn",
                AuthCode = new string('b', 20)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(userModel.DisplayName, null);
            Assert.AreEqual(userModel.SessionKey, null);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_Duplicate_Username_Shoud_Return_BadRequest()
        {
            var testUser = new UserModel()
            {
                Username = "validusername",
                DisplayName = "validdisplayname",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(testUser.DisplayName, userModel.DisplayName);
            Assert.IsNotNull(userModel.SessionKey);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var sameTestUser = new UserModel()
            {
                Username = "validusername",
                DisplayName = "anotherdisplayName",
                AuthCode = new string('b', 40)
            };

            response = this.httpServer.Post("api/users/register", sameTestUser);
            contentString = response.Content.ReadAsStringAsync().Result;
            userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(userModel.DisplayName, null);
            Assert.AreEqual(userModel.SessionKey, null);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_Duplicate_DisplayName_Shoud_Return_BadRequest()
        {
            var testUser = new UserModel()
            {
                Username = "validusername",
                DisplayName = "validdisplayname",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(testUser.DisplayName, userModel.DisplayName);
            Assert.IsNotNull(userModel.SessionKey);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var sameTestUser = new UserModel()
            {
                Username = "anothervalidusername",
                DisplayName = "validdisplayname",
                AuthCode = new string('b', 40)
            };

            response = this.httpServer.Post("api/users/register", sameTestUser);
            contentString = response.Content.ReadAsStringAsync().Result;
            userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            Assert.AreEqual(userModel.DisplayName, null);
            Assert.AreEqual(userModel.SessionKey, null);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
