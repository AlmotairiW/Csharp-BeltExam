using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltExam.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "First Name must be at least 2 characters long!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters long!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [MinLength(3, ErrorMessage = "Username must be between 3 - 15 characters long!")]
        [MaxLength(15, ErrorMessage = "Username must be between 3 - 15 characters long!")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        [Compare("Password", ErrorMessage = "Passwords does not match!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string Confirm { get; set; }

        public List<Hobby> HobbiesCreated { get; set; }
        public List<UserHobby> AllHobbies { get; set; }
    }
}