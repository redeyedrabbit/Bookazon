using Bookazon.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Services
{
    class AuthorshipService
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

    }
}
