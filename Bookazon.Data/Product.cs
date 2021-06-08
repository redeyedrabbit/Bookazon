using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Data
{
    public enum FormatType { Book, CD, Ebook}
    public enum Condition { New, Used}
    public enum Genre { Mystery, Thriller, Horror, Fantasy, Childrens, Romance, Nonfiction}
    public class Product    
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public FormatType TypeOfFormat { get; set; }
        [Required]
        public Genre TypeofGenre { get; set; }
        public int PublisherId { get; set; }
        [Required]
        public DateTime PublishYear { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Condition TypeOfCondition { get; set; }

    }
}
