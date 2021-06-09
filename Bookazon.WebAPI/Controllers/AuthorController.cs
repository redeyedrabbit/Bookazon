using Bookazon.Models.Author;
using Bookazon.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bookazon.WebAPI.Controllers
{

    public class AuthorController : ApiController
    {
        public IHttpActionResult Get()
        {
            AuthorService authorService = CreateAuthorService();
            var authors = authorService.GetAuthors();
            return Ok(authors);

        }

        public IHttpActionResult GetAuthorsByFirst(string firstName)
        {
            AuthorService authorService = CreateAuthorService();
            var authors = authorService.GetAuthorByFirstName(firstName);
            return Ok(authors);
        }

        public IHttpActionResult GetAuthorsByLast(string lastName)
        {
            AuthorService authorService = CreateAuthorService();
            var authors = authorService.GetAuthorByLastName(lastName);
            return Ok(authors);
        }

        public IHttpActionResult GetAuthorByFull(string firstName, string lastName)
        {
            AuthorService authorService = CreateAuthorService();
            var authors = authorService.GetAuthorByFullName(firstName, lastName);
            return Ok(authors);
        }

        public IHttpActionResult getAuthorById(int id)
        {
            AuthorService authorService = CreateAuthorService();
            var author = authorService.GetAuthorById(id);
            return Ok(author);
        }

        public IHttpActionResult Post(AuthorCreate author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAuthorService();

            if (!service.CreateAuthor(author))
                return InternalServerError();

            return Ok("Author sucessfully created.");
        }

        public IHttpActionResult Put (AuthorEdit author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAuthorService();

            if (!service.UpdateAuthor(author))
                return InternalServerError();

            return Ok("Author successfully updated.");
        }

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
