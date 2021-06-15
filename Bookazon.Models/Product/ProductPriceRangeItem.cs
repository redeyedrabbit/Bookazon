using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Models.Product
{
    public class ProductPriceRangeItem
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public List<int> Authors { get; set; }
        public decimal Price { get; set; }
    }
}
