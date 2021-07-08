using Microsoft.EntityFrameworkCore;

namespace BeltExam.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}
        public DbSet<User> Users {set;get;}
        public DbSet<Hobby> Hobbies {set;get;}
        public DbSet<UserHobby> UserHobbies {set;get;}
    }
}