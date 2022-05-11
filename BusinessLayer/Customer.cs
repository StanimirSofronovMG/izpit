using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Customer
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [Range(18, 81)]
        public int Age { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MaxLength(70)]
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        public string Email { get; set; }

        public List<Customer> Friends { get; set; }

        public IEnumerable<Interest> Interests { get; set; }

        private Customer() { }

        public Customer(string fname, string lname, int age, string uname, string password, string email)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Age = age;
            this.Username = uname;
            this.Password = password;
            this.Email = email;
        }
    }
}
