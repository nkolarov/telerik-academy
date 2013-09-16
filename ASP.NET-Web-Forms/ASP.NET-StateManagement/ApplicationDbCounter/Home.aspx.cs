using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace ApplicationDbCounter
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
            ApplicationCounterEntities context = new ApplicationCounterEntities();
            var counter = context.Counters.FirstOrDefault();

            var visitorsCount = counter.Count;
            return visitorsCount;
        }

        private void EnrollUser()
        {
            ApplicationCounterEntities context = new ApplicationCounterEntities();
            var counter = context.Counters.FirstOrDefault();

            if (counter == null)
            {
                context.Counters.Add(new Counter { Id = 1 });
            }
            else
            {
                counter.Count++;
            }

            context.SaveChanges();
        }
    }
}