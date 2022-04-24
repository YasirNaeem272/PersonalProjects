using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TashBlock.Models
{
    public class HeadLevel3
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public int Code { get; set; }
        public int Level1_D { get; set; }
        [NotMapped]
        public List<SelectListItem> Type { get; set; }
    }   
}
