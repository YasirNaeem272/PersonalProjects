using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Secondtask.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }

        [Required]
       [StringLength(150)]
        public string Name { get; set; } = "";
        [Required]
        [StringLength(10)]
        public string Gender { get; set; } = "";
        [Required]
        [DisplayName("Age of Year")]
        public string Age { get; set; } 
        [Required]
        [StringLength(50)]
        public string Qualification { get; set; } = "";
        [Required]
        [DisplayName("Total Experience of Year")]
        public int TotalExperince { get; set; }

        public virtual List<Experience> Experiences { get; set; } = new List<Experience>();//details show applicant table
    } 
}
