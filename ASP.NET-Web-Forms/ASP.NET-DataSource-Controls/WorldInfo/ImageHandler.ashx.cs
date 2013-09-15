using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WorldInfo
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {
        // http://stackoverflow.com/questions/14935205/retrieve-image-from-database-in-asp-net
        public void ProcessRequest(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.QueryString["countryId"]))
            {
                int countryId = Convert.ToInt32(context.Request.QueryString["countryId"]);
                if (countryId > 0)
                {
                    var result = RetrieveCountryImage(countryId, context);
                    if (result != null)
                    {
                        context.Response.BinaryWrite(result);
                        context.Response.ContentType = "image/png";
                        context.Response.End();
                    }
                }
            }
        }

        private Byte[] RetrieveCountryImage(int countryId, HttpContext context)
        {
            WorldInfoEntities db = new WorldInfoEntities();
            var country = db.Countries.Find(countryId);
            if (country != null)
            {
                if (country.Flag != null)
                {
                    return country.Flag;
                }
                else
                {
                    return File.ReadAllBytes(context.Server.MapPath("~/Images/default_flag.png"));
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