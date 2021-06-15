using Bookazon.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Models.Product
{
    public class ProductEdit
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The title needs to be longer.")]
        [MaxLength(80, ErrorMessage = "Please enter a more brief title.")]
        public string Title { get; set; }

        [MinLength(3, ErrorMessage = "The description needs to be longer.")]
        [MaxLength(80, ErrorMessage = "Please enter a more brief description.")]
        public string Description { get; set; }

        [Range(0, 5, ErrorMessage = "The star rating must be between 0 and 5")]
        public double StarRating { get; set; }

        public Genre TypeOfGenre { get; set; }

        public Audience TypeOfAudience { get; set; }

        [Required]
        public int PublisherId { get; set; }

        public int PublishYear { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The price must be greater than 0")]
        public decimal Price { get; set; }

        public Condition TypeOfCondition { get; set; }

    }
}
