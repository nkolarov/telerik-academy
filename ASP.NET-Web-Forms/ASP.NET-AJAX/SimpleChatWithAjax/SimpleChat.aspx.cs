using SimpleChatWithAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleChatWithAjax
{
    public partial class SimpleChat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessagesDbEntities context = new MessagesDbEntities();
            var messages = context.Messages.ToList();
            this.ListViewSimpleChat.DataSource = messages;
            this.ListViewSimpleChat.DataBind();
        }


        protected void LinkButtonSendMessage_Click(object sender, EventArgs e)
        {
            MessagesDbEntities context = new MessagesDbEntities();
            Message msg = new Message();
            msg.UserName = this.TextBoxUserName.Text;
            msg.Text = this.TextBoxMessage.Text;
            context.Messages.Add(msg);
            context.SaveChanges();
        }
    }
}