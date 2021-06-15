using Bookazon.Models.Author;
using Bookazon.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Bookazon.WebAPI.Controllers
{
    /// <summary>
    /// Controller for Authors and Author Services
    /// </summary>
    public class AuthorController : ApiController
    {
        /// <summary>
        /// Get all authors in the database.
        /// </summary>
        /// <returns>
        /// Returns the Author information for each author in the database with the AuthorId, FirstName and LastName.
        /// </returns>
        [ResponseType(typeof(AuthorListItem))]
        public IHttpActionResult Get()
        {
            AuthorService authorService = CreateAuthorService();
            var authors = authorService.GetAuthors();
            return Ok(authors);

        }

        /// <summary>
        /// Get authors by first name.
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns>
        /// Allows a user to search the database for authors by their first name, and returns all authors that match that criteria with their AuthorId, FirstName and LastName.
        /// </returns>
        [ResponseType(typeof(AuthorDetail))]
        public IHttpActionResult GetAuthorsByFirst(string firstName)
        {
            AuthorService authorService = CreateAuthorService();
            var authors = authorService.GetAuthorByFirstName(firstName);
            return Ok(authors);
        }

        /// <summary>
        /// Get authors by last name.
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns>
        ///  Allows a user to search the database for authors by their last name, and returns all authors that match that criteria with their AuthorId, FirstName and LastName.
        /// </returns>
        [ResponseType(typeof(AuthorDetail))]
        public IHttpActionResult GetAuthorsByLast(string lastName)
        {
            AuthorService authorService = CreateAuthorService();
            var authors = authorService.GetAuthorByLastName(lastName);
            return Ok(authors);
        }

        /// <summary>
        /// Get authors by full name.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>
        /// Allows a user to do a more specific search of the database for authors by their first and last name, and returns all authors that match that criteria with their AuthorId, FirstName and LastName.
        /// </returns>
        [ResponseType(typeof(AuthorDetail))]
        public IHttpActionResult GetAuthorByFull(string firstName, string lastName)
        {
            AuthorService authorService = CreateAuthorService();
            var authors = authorService.GetAuthorByFullName(firstName, lastName);
            return Ok(authors);
        }

        /// <summary>
        /// Get authors by their AuthorId.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Allows a user to search the databse for an author by their AuthorId, and returns the author that matches the searched AuthorId if a match is found.
        /// </returns>
        [ResponseType(typeof(AuthorDetail))]
        public IHttpActionResult getAuthorById(int id)
        {
            AuthorService authorService = CreateAuthorService();
            var author = authorService.GetAuthorById(id);
            return Ok(author);
        }

        /// <summary>
        /// Create a new author and add them to the database.
        /// </summary>
        /// <param name="author"></param>
        /// <returns>
        /// Allows a user to create a new author and save them to the database. If the author is successfully created, returns the message "Author successfully created."
        /// </returns>
        [ResponseType(typeof(string))]
        public IHttpActionResult Post(AuthorCreate author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAuthorService();

            if (!service.CreateAuthor(author))
                return InternalServerError();

            return Ok("Author sucessfully created.");
        }

        /// <summary>
        /// Edit an existing author.
        /// </summary>
        /// <param name="author"></param>
        /// <returns>
        /// Allows a user to edit an existing author by that author's AuthorId. Each field must be confirmed or changed. Be sure follow the fields in the API to ensure you have all fields edited or remain unchanged. If successful, returns the message "Author successfully edited."
        /// </returns>
        [ResponseType(typeof(string))]
        public IHttpActionResult Put (AuthorEdit author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAuthorService();

            if (!service.UpdateAuthor(author))
                return InternalServerError();

            return Ok("Author successfully updated.");
        }

        /// <summary>
        /// Delete an existing author.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Allows a user to delete an existing author by that author's AuthorId. If successful, returns the message "Author successfully deleted."
        /// </returns>
        [ResponseType(typeof(string))]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAuthorService();

            if (!service.DeleteAuthor(id))
                return InternalServerError();

            return Ok("Author successfully deleted.");
        }

        private AuthorService CreateAuthorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var authorService = new AuthorService(userId);
            return authorService;
        }
    }
}
