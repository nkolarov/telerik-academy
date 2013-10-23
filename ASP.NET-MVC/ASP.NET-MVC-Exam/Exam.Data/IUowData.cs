using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data
{
    public interface IUowData
    {
        IRepository<Ticket> Tickets { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Category> Categories { get; }

        IRepository<ApplicationUser> Users { get;  }

        int SaveChanges();
    }
}
