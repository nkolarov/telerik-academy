using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class TagsController : BaseApiController
    {
        [HttpGet]
        public IQueryable<TagModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystemContext();
                var user = GetAndValidateUser(sessionKey, context);
                var tagsEntities = context.Tags;
                var models = GetTagsModelsFromEntities(tagsEntities);

                return models.OrderBy(t => t.Name);
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("posts")]
        public IQueryable<PostModel> GetPostsForTag(int tagId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystemContext();
                var user = GetAndValidateUser(sessionKey, context);
                var postEntities = context.Posts.Where(p => p.Tags.Any(t => t.Id == tagId)).AsQueryable();
                var models = PostsController.GetPostModelsFromEntities(postEntities);

                return models.OrderByDescending(p => p.PostDate);
            });

            return responseMsg;
        }

        private User GetAndValidateUser(string sessionKey, BloggingSystemContext context)
        {
            var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
            if (user == null)
            {
                throw new InvalidOperationException("Invalid username or password!");
            }

            return user;
        }

        private IQueryable<TagModel> GetTagsModelsFromEntities(DbSet<Tag> tagsEntities)
        {
            var models =
                from tagEntity in tagsEntities
                select new TagModel()
                {
                    Id = tagEntity.Id,
                    Name = tagEntity.Name,
                    PostsCount = tagEntity.Posts.Count
                };

            return models;
        }
    }
}
