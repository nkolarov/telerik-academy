using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using BloggingSystem.Data;
using BloggingSystem.Models;
using BloggingSystem.Services.Attributes;
using BloggingSystem.Services.Models;

namespace BloggingSystem.Services.Controllers
{
    public class PostsController : BaseApiController
    {
        [HttpPost]
        public HttpResponseMessage PostAddPost(PostModel postData, [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var context = new BloggingSystemContext();
                    using (context)
                    {
                        var user = GetAndValidateUser(sessionKey, context);

                        ValidatePost(postData);

                        var postEntity = new Post()
                        {
                            Text = postData.Text,
                            Title = postData.Title
                        };

                        postEntity.PostDate = DateTime.Now;
                        postEntity.User = user;

                        AddTags(context, postData, postEntity);
                        AddTitleTags(context, postData, postEntity);

                        context.Posts.Add(postEntity);
                        context.SaveChanges();

                        var postCreatedModel = new PostCreatedModel() { Id = postEntity.Id, Title = postEntity.Title };

                        var response = this.Request.CreateResponse(HttpStatusCode.Created, postCreatedModel);
                        return response;
                    }
                });

            return responseMsg;
        }

        [HttpGet]
        public IQueryable<PostModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystemContext();
                var user = GetAndValidateUser(sessionKey, context);
                var postsEntities = context.Posts;
                var models = GetPostModelsFromEntities(postsEntities);

                return models.OrderByDescending(p => p.PostDate);
            });

            return responseMsg;
        }

        [HttpGet]
        public IQueryable<PostModel> GetPage(int page, int count,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var postsModels = this.GetAll(sessionKey)
                    .Skip(page * count)
                    .Take(count);
                return postsModels;
            });

            return responseMsg;
        }

        [HttpGet]
        public IQueryable<PostModel> GetByKeyword(string keyword,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var postsModels = this.GetAll(sessionKey)
                    .Where(p => p.Title.Contains(keyword));
                return postsModels;
            });

            return responseMsg;
        }

        [HttpGet]
        public IQueryable<PostModel> GetByTag(string tags,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var searchedTags = tags.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var postsModels = this.GetAll(sessionKey);

                foreach (var tag in searchedTags)
                {
                    postsModels = postsModels.Where(p => p.Tags.Any(tagValue => tagValue == tag));
                }

                return postsModels;
            });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("comment")]
        public HttpResponseMessage AddComment(int postId, CommentModel comment,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystemContext();
                var user = GetAndValidateUser(sessionKey, context);
                var postEntity = context.Posts.FirstOrDefault(p => p.Id == postId);
                var commentEntity = new Comment() { PostDate = DateTime.Now, Text = comment.Text, User = user };
                postEntity.Comments.Add(commentEntity);
                context.SaveChanges();

                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                return response;
            });

            return responseMsg;
        }

        public static IQueryable<PostModel> GetPostModelsFromEntities(IQueryable<Post> postsEntities)
        {
            var models =
                (from postEntity in postsEntities
                 select new PostModel()
                 {
                     Id = postEntity.Id,
                     Title = postEntity.Title,
                     Text = postEntity.Text,
                     PostedBy = postEntity.User.DisplayName,
                     PostDate = postEntity.PostDate,
                     Tags =
                        from tags in postEntity.Tags
                        select tags.Name,
                     Comments =
                         from comment in postEntity.Comments
                         select new CommentModel()
                         {
                             Text = comment.Text,
                             CommentedBy = comment.User.DisplayName,
                             PostDate = comment.PostDate
                         }
                 });

            return models;
        }

        private void AddTags(BloggingSystemContext context, PostModel postData, Post postEntity)
        {
            if (postData.Tags != null)
            {
                foreach (var tag in postData.Tags)
                {
                    var tagEntity = this.GetOrCreateTag(context, tag);

                    postEntity.Tags.Add(tagEntity);
                }
            }
        }

        private Tag GetOrCreateTag(BloggingSystemContext context, string tag)
        {
            var tagEntity = context.Tags.FirstOrDefault(t => t.Name == tag.ToLower());
            if (tagEntity == null)
            {
                tagEntity = new Tag() { Name = tag.ToLower() };
            }

            return tagEntity;
        }

        private void AddTitleTags(BloggingSystemContext context, PostModel postData, Post postEntity)
        {
            var titleTags = postData.Title.ToLower().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (titleTags != null)
            {
                foreach (var tag in titleTags)
                {
                    var tagEntity = this.GetOrCreateTag(context, tag);

                    postEntity.Tags.Add(tagEntity);
                }
            }
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

        private void ValidatePost(PostModel postData)
        {
            if (postData == null || string.IsNullOrEmpty(postData.Title) || string.IsNullOrEmpty(postData.Text))
            {
                throw new InvalidOperationException("Incomplete Post data!");
            }
        }
    }
}
