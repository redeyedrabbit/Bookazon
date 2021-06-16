﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Models.Product
{
    public class ProductStarRatingRangeItem
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public double StarRating { get; set; }
        public decimal Price { get; set; }
    }
}
