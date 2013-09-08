using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

namespace CustomImageHandler
{
    public class PNGHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var requestURL = context.Request.Url;
            var path = context.Server.MapPath("Images/blank.jpg");

            using (var bitmap = new Bitmap(path))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    var brush = new SolidBrush(Color.BlueViolet);
                    graphics.FillRectangle(brush, 0, 0, 5000, 150);
                    graphics.DrawString(
                        "You requested: " + requestURL,
                        new Font("Segoe UI", 15),
                        new SolidBrush(Color.BlanchedAlmond),
                        new PointF(25, 40));
                    context.Response.ContentType = "image/jpeg";
                    bitmap.Save(context.Response.OutputStream, ImageFormat.Png);
                }
            }
        }

        #endregion
    }
}
