using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Models.Authorship
{
    public class AuthorshipEdit
    {
        public int Id { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
