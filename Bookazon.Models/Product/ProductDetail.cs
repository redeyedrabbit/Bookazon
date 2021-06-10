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
        [Display(Name = "Authors")]
<<<<<<< HEAD
        public IEnumerable<Bookazon.Data.Authorship> Authors { get; set; }
        public FormatType TypeOfFormat { get; set; }
        public Genre TypeofGenre { get; set; }
        public int PublisherId { get; set; }
        public List<Bookazon.Data.Publisher> Publishers { get; set; }
=======
        public List<int> Authors { get; set; }
        public FormatType TypeOfFormat { get; set; }
        public Genre TypeofGenre { get; set; }
        public int PublisherId { get; set; }
        public List<int> Publishers { get; set; }
>>>>>>> b542011f4c8fe78ac03c0fa6bcfb647045a9f7ae
        public int PublishYear { get; set; }
        public decimal Price { get; set; }
        public Condition TypeOfCondition { get; set; }

        

    }
}
