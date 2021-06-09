using Bookazon.Data;
using Bookazon.Models.Authorship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Services
{
    public class AuthorshipService
    {
        private readonly Guid _managerId;

        public AuthorshipService(Guid managerId)
        {
            _managerId = managerId;
        }

        public bool ConnectAuthorToBook(int productId, int authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Authorships.Count(e => e.AuthorId == authorId && e.ProductId == productId) != 0) 
                    return false;
            }
            
            var entity =
                new Authorship()
                {
                    AuthorId = authorId,
                    ProductId = productId
                };
            using (var ctx2 = new ApplicationDbContext())
            {
                ctx2.Authorships.Add(entity);
                return ctx2.SaveChanges() == 1;
            }
        }

        public bool DeleteAuthorship(int productId, int authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Authorships
                    .Single(e => e.AuthorId == authorId && e.ProductId == productId);

                ctx.Authorships.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AuthorshipListItem> GetAuthorships()
        {
            using(var ctx = new ApplicationDbContext()) 
            {
                var query =
                    ctx
                    .Authorships
                    .Select(
                        e =>
                        new AuthorshipListItem
                        {
                            Id = e.Id,
                            AuthorId = e.AuthorId,
                            ProductId = e.ProductId
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
