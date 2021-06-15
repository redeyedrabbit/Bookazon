using Bookazon.Models.Publisher;
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
    /// Controller for Publishers and Publisher Services
    /// </summary>
    public class PublisherController : ApiController
    {
        // Method that creates a PublisherService
        private PublisherService CreatePublisherService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var publisherService = new PublisherService(userId);
            return publisherService;
        }

        // Create New Publisher
        /// <summary>
        /// Create a new publisher and add it to the database.
        /// </summary>
        /// <param name="publisher"></param>
        /// <returns>
        /// Allows a user to create a new publisher. To create a new product, an author and publisher must be created first. If the publisher is successfully created, returns the message "Publisher successfully created."
        /// </returns>
        [ResponseType(typeof(string))]
        public IHttpActionResult Post(PublisherCreate publisher)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePublisherService();

            if (!service.CreatePublisher(publisher))
                return InternalServerError();
            return Ok("Publisher successfully created.");
        }

        // Update Existing Publisher
        /// <summary>
        /// Update an existing publisher.
        /// </summary>
        /// <param name="publisher"></param>
        /// <returns>
        /// Allows a user to edit an existing publisher by that publisher's PublisherId. Each field must be confirmed or changed. Be sure follow the fields in the API to ensure you have all fields edited or remain unchanged. If successful, returns the message "Publisher successfully edited."
        /// </returns>
        [ResponseType(typeof(string))]
        public IHttpActionResult Put(PublisherUpdate publisher)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePublisherService();

            if (!service.UpdatePublisher(publisher))
                return InternalServerError();

            return Ok("Publisher successfully edited.");
        }

        // Get All Publishers
        /// <summary>
        /// Get all publishers from the database.
        /// </summary>
        /// <returns>
        /// Returns the publisher information for each publisher in the database with the PublisherId and publisher Name.
        /// </returns>
        [ResponseType(typeof(PublisherListItem))]
        public IHttpActionResult Get()
        {
            PublisherService publisherService = CreatePublisherService();
            var publishers = publisherService.GetPublishers();
            return Ok(publishers);
        }

        // Get Publisher by ID
        /// <summary>
        /// Get publisher by their PublisherId.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Allows a user to search the databse for a publisher by their PublisherId, and returns the publisher that matches the searched PublisherId if a match is found.
        /// </returns>
        [ResponseType(typeof(PublisherListItem))]
        public IHttpActionResult Get(int id)
        {
            PublisherService publisherService = CreatePublisherService();
            var publisher = publisherService.GetPublisherById(id);
            return Ok(publisher);
        }

        // Delete Publisher
        /// <summary>
        /// Delete publisher by their PublisherId.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Allows a user to delete an existing publisher by that publisher's PublisherId. If successful, returns the message "Publisher successfully deleted."
        /// </returns>
        [ResponseType(typeof(string))]
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePublisherService();

            if (!service.DeletePublisher(id))
                return InternalServerError();
            return Ok("Publisher successfully deleted.");
        }
    }
}
