using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Data
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }

        [Required]
        public Guid ManagerId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }

    }
}
