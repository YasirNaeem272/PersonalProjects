using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TashBlock.Models
{
    public class HeadLevel
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public int Code { get; set; }
        public int Type { get; set; }
    }
}
