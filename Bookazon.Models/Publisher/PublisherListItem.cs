using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Models.Publisher
{
    public class PublisherListItem
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
    }
}
