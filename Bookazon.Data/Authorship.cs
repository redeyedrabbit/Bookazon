using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Data
{
    public class Authorship
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid ManagerId { get; set; }
        
        [Required]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
        public virtual IEnumerable<Author> Authors { get; set; }
    }
}
