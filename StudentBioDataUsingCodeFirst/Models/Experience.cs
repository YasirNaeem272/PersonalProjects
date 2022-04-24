using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace Secondtask.Models
{
    public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        public virtual Applicant Applicant { get; private set; }
        public string CompanyName { get; set; }
        public string Designation{ get; set; }
        public int YearsWorked { get; set; }
    }
}
