using Bookazon.Data;
using Bookazon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Services
{
    public class AuthorService
    {
        private readonly Guid _userId;

        public AuthorService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAuthor(AuthorCreate model)
        {
            var entity =
                new Author()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Authors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AuthorListItem> GetAuthors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Authors
                    .Select(
                        e =>
                        new AuthorListItem
                        {
                            AuthorId = e.AuthorId,
                            FirstName = e.FirstName,
                            LastName = e.LastName
                        }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<AuthorDetail> GetAuthorByLastName(string lastName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Authors
                    .Where(e => e.LastName == lastName)
                    .Select(
                        e =>
                        new AuthorDetail
                        {
                            AuthorId = e.AuthorId,
                            FirstName = e.FirstName,
                            LastName = e.LastName
                        }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<AuthorDetail> GetAuthorByFirstName(string firstName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = 
                    ctx
                    .Authors
                    .Where(e => e.FirstName == firstName)
                    .Select(
                        e =>
                        new AuthorDetail
                        {
                            AuthorId = e.AuthorId,
                            FirstName = e.FirstName,
                            LastName = e.LastName
                        }
                        );
                return query.ToArray();
            }
        }

        public AuthorDetail GetAuthorByFullName(string firstName, string lastName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Authors
                    .Single(e => e.FirstName == firstName && e.LastName == lastName);
                   return
                    new AuthorDetail
                    {
                        AuthorId = entity.AuthorId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName
                    };
            }
        }


    }
}
