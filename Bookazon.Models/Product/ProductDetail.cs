using Bookazon.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Models.Product
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }       
        public List<string> Authors { get; set; }
        public double StarRating { get; set; }
        public FormatType TypeOfFormat { get; set; }
        public Genre TypeOfGenre { get; set; }
        public Audience TypeOfAudience { get; set; }
        public int PublisherId { get; set; }
        public List<int> Publishers { get; set; }
        public int PublishYear { get; set; }
        public decimal Price { get; set; }
        public Condition TypeOfCondition { get; set; }        

    }
}
