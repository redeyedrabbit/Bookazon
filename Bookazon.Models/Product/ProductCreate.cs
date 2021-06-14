using Bookazon.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Models.Product
{
    public class ProductCreate
    {
        [Required]
        [MinLength (3, ErrorMessage = "The title needs to be longer.")]
        [MaxLength (80, ErrorMessage = "Please enter a more brief title.")]
        public string Title { get; set; }

        [MinLength(3, ErrorMessage = "The description needs to be longer.")]
        [MaxLength(80, ErrorMessage = "Please enter a more brief description.")]
        public string Description { get; set; }

        public double StarRating { get; set; }

        [Required]
        public FormatType TypeOfFormat { get; set; }

        public Genre TypeofGenre { get; set; }

        [Required]
        public int PublisherId { get; set; }     
        
        public int PublishYear { get; set; }

        public decimal Price { get; set; }

        public Condition TypeOfCondition { get; set; }
    }
}
