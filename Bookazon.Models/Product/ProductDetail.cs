﻿using Bookazon.Data;
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
        [Display(Name = "Authors")]
        public List<int> Authors { get; set; }
        public FormatType TypeOfFormat { get; set; }
        public Genre TypeofGenre { get; set; }
        public int PublisherId { get; set; }
        public List<int> Publishers { get; set; }
        public int PublishYear { get; set; }
        public decimal Price { get; set; }
        public Condition TypeOfCondition { get; set; }

        

    }
}
