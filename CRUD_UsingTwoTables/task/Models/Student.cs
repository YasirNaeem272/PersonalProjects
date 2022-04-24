using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace task.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name{ get; set; }
        public string FName { get; set; }
       
        public int DepId { get; set; }
        [NotMapped]
        public string Department { get; set; }
    }
}
