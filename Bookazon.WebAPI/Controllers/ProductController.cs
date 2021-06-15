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
using System.Web.Http.Description;

namespace Bookazon.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
            ProductService productService = CreateProductService();
            var products = productService.GetAllProducts();
            return Ok(products);
        }

        /// <summary>
        /// Get a product by Title.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public IHttpActionResult GetByTitle(string title)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetTitlePartial(title);
            return Ok(product);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetById(int id)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetProductById(id);
            return Ok(product);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lowPrice"></param>
        /// <param name="highPrice"></param>
        /// <returns></returns>
        public IHttpActionResult GetByPriceRange(decimal lowPrice, decimal highPrice)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetAllProductsWithinPriceRange(lowPrice, highPrice);
            return Ok(product);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="publisherId"></param>
        /// <returns></returns>
        public IHttpActionResult GetByProductsByPublisherId(int publisherId)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetProductByPublisherId(publisherId);
            return Ok(product);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public IHttpActionResult Post(ProductCreate product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProductService();

            if (!service.CreateProduct(product))
                return InternalServerError();

            return Ok("Product successfully created.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="authorLastName"></param>
        /// <returns></returns>

        public IHttpActionResult PostWithAuthorship(ProductCreate product, string authorFirstName, string authorLastName)

        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProductService();

            if (!service.CreateProductWithAuthor(product, authorFirstName, authorLastName))
                return InternalServerError();

            return Ok("Product and authorship successfully created.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public IHttpActionResult Put(ProductEdit product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProductService();

            if (!service.UpdateProduct(product))
                return InternalServerError();

            return Ok("Product successfully edited.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
