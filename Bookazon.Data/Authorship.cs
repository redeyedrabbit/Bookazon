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

        [ForeignKey(nameof(Authors))]
        public int AuthorId { get; set; }

        [ForeignKey(nameof(Products))]
        public int ProductId { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
        public virtual IEnumerable<Author> Authors { get; set; }
    }
}
