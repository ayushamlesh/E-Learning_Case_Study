using System.ComponentModel.DataAnnotations;

namespace TekGain.DAL.Entities
{
    public class Admission
    {
        // Implement the properties here
        [Key]
        public int Id { get; set; }
        [Required]
        public int AssociateId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public string Status { get; set; }

        public string Feedback { get; set; }


    }
}