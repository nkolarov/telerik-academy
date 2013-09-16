using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicationCounter
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EnrollUser();

            var path = Server.MapPath("Images/blank.jpg");
            var visitorsCount = GetCounter();

            using (var bitmap = new Bitmap(path))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    var brush = new SolidBrush(Color.BlueViolet);
                    graphics.FillRectangle(brush, 0, 0, 5000, 150);
                    graphics.DrawString(
                        "Current visitors count: " + visitorsCount.ToString(),
                        new Font("Segoe UI", 15),
                        new SolidBrush(Color.BlanchedAlmond),
                        new PointF(25, 40));
                    Response.ContentType = "image/jpeg";
                    bitmap.Save(Response.OutputStream, ImageFormat.Png);
                }
            }
        }

        private object GetCounter()
        {
            var visitorsCount = Application["Visitors"];
            return visitorsCount;
        }

        private void EnrollUser()
        {
            Application.Lock();
            if (Application["Visitors"] == null)
            {
                Application["Visitors"] = 1;
            }
            else
            {
                Application["Visitors"] = (int)Application["Visitors"] + 1;
            }

            Application.UnLock();
        }
    }
}