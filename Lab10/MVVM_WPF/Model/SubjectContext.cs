using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_WPF
{
    public class SubjectContext : DbContext
    {
        public SubjectContext() : base("MVVM")
        {

        }
        public DbSet<Subject> Subjects { get; set; }
    }

}