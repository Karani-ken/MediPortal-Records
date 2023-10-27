using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediPortal_Records.Models
{
    public class Record
    {
        [Key]
        public Guid RecordId { get; set; }
       
        public Guid PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Allergies { get; set; } = new List<string>();
        public List<string> ChronicConditions { get; set; } = new List<string>();
        public List<string> Medications { get; set; } = new List<string>();
     


    }
    

}
