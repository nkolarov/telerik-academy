using ChatCanal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsTemplate
{
    public partial class UserArea : System.Web.UI.Page
    {
        public IQueryable<Message> ListMessages()
        {
            var context = new ChatCanalEntities();
            var messages = context.Messages;

            return messages;
        }

        protected void makePostBtn_Click(object sender, EventArgs e)
        {
            var context = new ChatCanalEntities();

            using (context)
            {
                var text = this.usersMessageText.Text;
                var user = context.AspNetUsers.FirstOrDefault(u => u.UserName == User.Identity.Name);
                Message post = new Message()
                {
                    Name = text
                };
                user.Messages.Add(post);

                context.SaveChanges();

                this.ListPosts.DataBind();

            }
        }
    }
}