using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Models.Authorship
{
    class AuthorshipEdit
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int ProductId { get; set; }
    }
}
