using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Data
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        public Guid ManagerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        public virtual IEnumerable<Authorship> BooksAuthored { get; set; }

    }
}
