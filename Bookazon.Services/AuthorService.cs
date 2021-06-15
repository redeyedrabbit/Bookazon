﻿using Bookazon.Data;
using Bookazon.Models;
using Bookazon.Models.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Services
{
    public class AuthorService
    {
        private readonly Guid _managerId;

        public AuthorService(Guid managerId)
        {
            _managerId = managerId;
        }

        public bool CreateAuthor(AuthorCreate model)
        {                       
            var entity =
                new Author()
                {
                    ManagerId = _managerId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };

            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Authors.Any(e => e.FirstName == model.FirstName && e.LastName == model.LastName))
                    return false;
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
                if (!ctx.Authors.Any(e => e.FirstName == firstName && e.LastName == lastName))
                    return null;
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

        public AuthorDetail GetAuthorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.Authors.Any(e => e.AuthorId == id))
                    return null;

                var entity =
                    ctx
                    .Authors
                    .Single(e => e.AuthorId == id);
                return
                    new AuthorDetail
                    {
                        AuthorId = entity.AuthorId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName
                    };
            }
        }

        public bool UpdateAuthor (AuthorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.Authors.Any(e => e.AuthorId == model.AuthorId))
                    return false;

                var entity =
                    ctx
                    .Authors
                    .Single(e => e.AuthorId == model.AuthorId && e.ManagerId == _managerId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAuthor(int authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.Authors.Any(e => e.AuthorId == authorId))
                    return false;

                var entity =
                    ctx
                    .Authors
                    .Single(e => e.AuthorId == authorId && e.ManagerId == _managerId);

                ctx.Authors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
