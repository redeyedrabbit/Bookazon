using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Services
{
    public class PublisherService
    {
        // Create New Publisher 
        public bool CreatePublisher(PublisherCreate model)
        {
            var entity = new PublisherService()
            {
                PublisherId = _publisherId,
                Name = model.Name
            };
        }
        // Update Existing Publisher
        //public bool UpdatePublisher(PublisherUpdate model)
        //{
        //    using (var ctx = new ApplicationException DbContext()){
        //        var entity = ctx.Publishers.Single(e => e.PublisherId == model.PublisherId && e.)
        //    }
        //}
        // Get all Publishers

        // Get Publisher by ID

        // Delete Publisher

    }
}
