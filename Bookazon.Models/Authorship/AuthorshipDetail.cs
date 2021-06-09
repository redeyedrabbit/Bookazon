using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Models.Authorship
{
    class AuthorshipDetail
    {
        public int Id { get; set; }        
        public int AuthorId { get; set; }                
        public int ProductId { get; set; }

        public virtual IEnumerable<Bookazon.Data.Product> Product { get; set; }
        public virtual IEnumerable<Bookazon.Data.Author> Author { get; set; }
    }
}
