using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;

namespace WebFormsTemplate.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public string Email { get; set; }

        public HashSet<Message> Messages;

        public ApplicationUser() {
            this.Messages = new HashSet<Message>();
        }
    }

    // You can inherit the base IdentityContext and add your application custom DbSets
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
        public ApplicationDbContext()
            : base("ChatCanalConnection")
        {
        }

        public DbSet<Message> Messages { get; set; }
    }
}
