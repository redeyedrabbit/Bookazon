using Bookazon.Models.Publisher;
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
        public IHttpActionResult Post(PublisherCreate publisher)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePublisherService();

            if (!service.CreatePublisher(publisher))
                return InternalServerError();
            return Ok();
        }

        // Update Existing Publisher
        public IHttpActionResult Put(PublisherUpdate publisher)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePublisherService();

            if (!service.UpdatePublisher(publisher))
                return InternalServerError();

            return Ok();
        }

        // Get All Publishers
        public IHttpActionResult Get()
        {
            PublisherService publisherService = CreatePublisherService();
            var publishers = publisherService.GetPublishers();
            return Ok(publishers);
        }

        // Get Publisher by ID
        public IHttpActionResult Get(int id)
        {
            PublisherService publisherService = CreatePublisherService();
            var publisher = publisherService.GetPublisherById(id);
            return Ok(publisher);
        }

        // Delete Publisher
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePublisherService();

            if (!service.DeletePublisher(id))
                return InternalServerError();
            return Ok("Publisher successfully deleted.");
        }
    }
}
