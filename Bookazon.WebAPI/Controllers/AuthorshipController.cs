using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bookazon.Services;
using Bookazon.Models.Authorship;

namespace Bookazon.WebAPI.Controllers
{
    [Authorize]
    public class AuthorshipController : ApiController
    {
        public IHttpActionResult GetAllAuthorships()
        {
            AuthorshipService authorshipService = CreateAuthorshipService();
            var authorships = authorshipService.GetAuthorships();
            return Ok(authorships);
        }
                
        public IHttpActionResult DeleteAuthorships(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAuthorshipService();

            if (!service.DeleteAuthorship(id))

                return InternalServerError();

            return Ok("Authorship deleted");
        }
        public IHttpActionResult PostAuthorship(AuthorshipCreate authorship)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAuthorshipService();

            if (!service.ConnectAuthorToBook(authorship.ProductId, authorship.AuthorId))
                return InternalServerError();

            return Ok("Authorship sucessfully added.");
        }

        public IHttpActionResult GetProductByAuthor(int authorId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AuthorshipService authorshipService = CreateAuthorshipService();
            var authorships = authorshipService.GetProductByAuthorship(authorId);

            return Ok(authorships);
        }

            private AuthorshipService CreateAuthorshipService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var authorshipService = new AuthorshipService(userId);
            return authorshipService;
        }

    }
}
