using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models
{
    public class LoginUser
    {
        [Required]
        [Display(Name = "Username")]
        public string LoginUsername {set;get;}

        [Required]
        [Display(Name = "Password")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string LoginPassword {set;get;}
    }
}