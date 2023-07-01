using System.ComponentModel.DataAnnotations;
namespace TekGain.DAL.Entities
{
    public class Associate
    {
        // Implement the properties here
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
