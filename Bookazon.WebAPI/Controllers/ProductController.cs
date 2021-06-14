using Bookazon.Data;
using Bookazon.Models.Product;
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
    public class ProductController : ApiController
    {
        [Authorize]

        public IHttpActionResult GetAll()
        {
            ProductService productService = CreateProductService();
            var products = productService.GetAllProducts();
            return Ok(products);
        }

        public IHttpActionResult GetByTitle(string title)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetTitlePartial(title);
            return Ok(product);
        }

        public IHttpActionResult GetById(int id)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetProductById(id);
            return Ok(product);
        }

        public IHttpActionResult GetByPriceRange(decimal lowPrice, decimal highPrice)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetAllProductsWithinPriceRange(lowPrice, highPrice);
            return Ok(product);
        }

        public IHttpActionResult GetByProductsByPublisherId(int publisherId)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetProductByPublisherId(publisherId);
            return Ok(product);
        }

        public IHttpActionResult GetByProductsByStarRating(double starRating)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetProductByStarRating(starRating);
            return Ok(product);
        }

        public IHttpActionResult GetByProductsByAudience(Audience audience)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetProductByAudience(audience);
            return Ok(product);
        }

        public IHttpActionResult Post(ProductCreate product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProductService();

            if (!service.CreateProduct(product))
                return InternalServerError();

            return Ok("Product successfully created.");
        }

        public IHttpActionResult PostWithAuthorship(ProductCreate product, string authorLastName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProductService();

            if (!service.CreateProductWithAuthor(product, authorLastName))
                return InternalServerError();

            return Ok("Product and authorship successfully created.");
        }

        public IHttpActionResult Put(ProductEdit product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProductService();

            if (!service.UpdateProduct(product))
                return InternalServerError();

            return Ok("Product successfully edited.");
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateProductService();

            if (!service.DeleteProduct(id))
                return InternalServerError();

            return Ok("Product successfully deleted.");
        }


        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var productService = new ProductService(userId);
            return productService;
        }
    }
}
