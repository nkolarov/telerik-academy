using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data
{
    public interface IUowData
    {
        //IRepository<Laptop> Laptops { get; }

        int SaveChanges();
    }
}
