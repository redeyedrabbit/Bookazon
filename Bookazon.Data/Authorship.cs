using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Data
{
    public class Authorship
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Author Author { get; set; }
    }
}
