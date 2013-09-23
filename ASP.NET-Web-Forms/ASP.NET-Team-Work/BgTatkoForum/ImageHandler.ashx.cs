using BgTatkoForum.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BgTatkoForum
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {
        // http://stackoverflow.com/questions/14935205/retrieve-image-from-database-in-asp-net
        public void ProcessRequest(HttpContext context)
        {
            string userId = context.Request.QueryString["userId"];
            if (!string.IsNullOrEmpty(userId))
            {
                Byte[] result = RetrieveCountryImage(userId, context);
                if (result != null)
                {
                    context.Response.BinaryWrite(result);
                    context.Response.ContentType = "image/png";
                    context.Response.End();
                }
            }
        }

        private Byte[] RetrieveCountryImage(string userId, HttpContext context)
        {
            BgTatkoEntities db = new BgTatkoEntities();
            var user = db.Users.FirstOrDefault(use => use.Id == userId);
            if (user != null)
            {
                if (user.UserDetail != null &&
                    user.UserDetail.Avatar != null)
                {
                    return user.UserDetail.Avatar;
                }
                else
                {
                    return File.ReadAllBytes(context.Server.MapPath("~/img/default.png"));
                }
            }
            return null;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}