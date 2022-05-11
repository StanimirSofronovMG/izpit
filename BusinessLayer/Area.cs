using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Area
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public IEnumerable<Customer> Customers  { get; set; }

        private Area() { }

        public Area(string name)
        {
            this.Name = name;
        }
    }
}