using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Interest
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public IEnumerable<Customer> Customers { get; set; }

        public IEnumerable<Area> Areas { get; set; }

        private Interest() { }

        public Interest(string name, IEnumerable<Area> Areas)
        {
            this.Name = name;
            this.Areas = Areas;
        }
    }
}
