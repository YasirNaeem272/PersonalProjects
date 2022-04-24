using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext>options):base(options)
        {

        }

        public DbSet<Student> tb_student { get; set; }
        public DbSet<Departments> tb_Departments { get; set; }
    }
}
