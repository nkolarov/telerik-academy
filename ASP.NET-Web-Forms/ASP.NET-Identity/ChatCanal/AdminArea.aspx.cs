using ChatCanal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsTemplate
{
    public partial class AdminArea : System.Web.UI.Page
    {
        public IQueryable<Message> ListMessages_Get()
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

                this.ListMessages.DataBind();

            }
        }

        public void ListMessages_UpdateItem(int id)
        {

            var context = new ChatCanalEntities();

            using (context)
            {
                var item = context.Messages.FirstOrDefault(p => p.Id == id);

                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item not found", id));
                    return;
                }

                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    context.SaveChanges();

                }
            }


        }

        public void ListMessages_DeleteItem(int id)
        {
            var context = new ChatCanalEntities();
            using (context)
            {
                var message = context.Messages.FirstOrDefault(p => p.Id == id);
                context.Messages.Remove(message);

                context.SaveChanges();
            }
        }
    }
}
