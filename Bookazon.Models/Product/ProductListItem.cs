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
        public List<string> Authors { get; set; }
        public double StarRating { get; set; }
        public Genre TypeOfGenre { get; set; }
        public Audience TypeOfAudience { get; set; }
    }
}
