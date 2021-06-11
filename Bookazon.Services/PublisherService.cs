using Bookazon.Data;
using Bookazon.Models.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Services
{
    public class PublisherService
    {
        private readonly Guid _managerId;
        public PublisherService(Guid managerId)
        {
            _managerId = managerId;
        }
        // Create New Publisher
        public bool CreatePublisher(PublisherCreate model)
        {
            var entity = new Publisher()
            {
                ManagerId = _managerId,
                Name = model.Name
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Publishers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        
        // Update Existing Publisher
        public bool UpdatePublisher(PublisherUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Publishers.Single(e => e.PublisherId == model.PublisherId && e.ManagerId == _managerId);

                entity.Name = model.Name;
                return ctx.SaveChanges() == 1;
            }
        }

        // Get all Publishers
        public IEnumerable<PublisherListItem> GetPublishers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                // do I need == _manager??
                var query = ctx
                    .Publishers.Where(e => e.ManagerId == _managerId)
                    .Select(e => new PublisherListItem
                    {
                        PublisherId = e.PublisherId,
                        Name = e.Name
                    }
                    );
                return query.ToArray();
            }
        }

        // Get Publisher by ID
        public PublisherDetail GetPublisherById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Publishers.Single(e => e.PublisherId == id);
                return new PublisherDetail
                {
                    PublisherId = entity.PublisherId,
                    Name = entity.Name
                };
            }
        }
                
        // Delete Publisher
        public bool DeletePublisher(int publisherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Publishers
                    .Single(e => e.PublisherId == publisherId && e.ManagerId == _managerId);
                ctx.Publishers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
