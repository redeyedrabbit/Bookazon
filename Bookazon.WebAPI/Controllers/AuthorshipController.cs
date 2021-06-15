using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bookazon.Services;
using Bookazon.Models.Authorship;
using System.Web.Http.Description;

namespace Bookazon.WebAPI.Controllers
{
    /// <summary>
    /// Controller for Authorships and Authorship Services
    /// </summary>
    public class AuthorshipController : ApiController
    {
        /// <summary>
        /// Get all authorships in the database.
        /// </summary>
        /// <returns>
        /// Returns the authorship information for each authorship in the database, listing the AuthorId and ProductId. Each authorship consists of an author and a product. Some products may have multiple authors. 
        /// </returns>
        [ResponseType(typeof(AuthorshipListItem))]
        public IHttpActionResult GetAllAuthorships()
        {
            AuthorshipService authorshipService = CreateAuthorshipService();
            var authorships = authorshipService.GetAuthorships();
            return Ok(authorships);
        }

        /// <summary>
        /// Delete an existing authorship.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Allows a user to delete an existing authorship by that authorship's Id. If successful, returns the message "Authorship successfully deleted."
        /// </returns>
        [ResponseType(typeof(string))]
        public IHttpActionResult DeleteAuthorships(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAuthorshipService();

            if (!service.DeleteAuthorship(id))

                return InternalServerError();

            return Ok("Authorship successfully deleted");
        }

        /// <summary>
        /// Create a new authorship and add it to the database. 
        /// </summary>
        /// <param name="authorship"></param>
        /// <returns>
        /// Allows a user to link an Author to a Product through a joining table. You will need to create an Author and a Product before you can link them. If successful, returns the message "Authorship successfully added."
        /// </returns>
        [ResponseType(typeof(string))]
        public IHttpActionResult PostAuthorship(AuthorshipCreate authorship)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAuthorshipService();

            if (!service.ConnectAuthorToBook(authorship.ProductId, authorship.AuthorId))
                return InternalServerError();

            return Ok("Authorship sucessfully added.");
        }

        /// <summary>
        /// Get all products by AuthorId.
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns>
        /// Returns all products linked to the entered AuthorId, returns the Authorship Id, AuthorId, and ProductId.
        /// </returns>
        [ResponseType(typeof(AuthorshipListItem))]
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
