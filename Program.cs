using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EfCore
{
    public class User
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string password { get; set; }
    }
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");        
            
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            User user = new User()
            {
                firstname = firstName,
                lastname = lastName,
                email = email,
                password = password
            };

            try
            {
                using(UsersContext context = new UsersContext())
                {
                    context.Users.Add(user);
                    int rowAffected = context.SaveChanges();
                    
                    if(rowAffected > 0)
                    {
                        Console.WriteLine("User data saved successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to save!");
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine("An error occured" + ex.Message);
            }
            Console.ReadLine();
        }
    }
}
