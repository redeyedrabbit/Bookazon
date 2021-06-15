using Bookazon.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Models.Product
{
    public class ProductEdit
    {
        public int Id { get; set; }        
        public string Title { get; set; }
        public string Description { get; set; }
        public double StarRating { get; set; }
        public Genre TypeofGenre { get; set; }
        public Audience TypeofAudience { get; set; }
        public int PublisherId { get; set; }
        public int PublishYear { get; set; }
        public decimal Price { get; set; }
        
    }
}
