using System.ComponentModel.DataAnnotations;

namespace Cakekue_J94824.Models
{
    public class EmailModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public string Subject { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string Body { get; set; }
    }
}















