using System.ComponentModel.DataAnnotations;

namespace TekGain.DAL.Entities
{
    public class Course
    {
        // Implement the properties here
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public double Fee { get; set; }
        [Required]
        public int Duration { get; set; }


        public double Rating { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
