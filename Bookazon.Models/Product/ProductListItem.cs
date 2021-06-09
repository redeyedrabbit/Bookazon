using Bookazon.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Models.Product
{
    public class ProductListItem
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public virtual IEnumerable<Bookazon.Data.Authorship> Authors { get; set; }
        public Genre TypeOfGenre { get; set; }
    }
}
