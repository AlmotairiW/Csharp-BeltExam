using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models
{
    public class UserHobby
    {
        [Key]
        public int UserHobbyId { get; set; }

        public int UserId { get; set; }
        public int HobbyId { get; set; }

        public User UserOnHobby { get; set; }
        public Hobby HobbyOfUser { get; set;}
        
    }
}