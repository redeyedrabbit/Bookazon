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
    /// Controller for Products and Product Services.
    /// </summary>
    public class ProductController : ApiController
    {
        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var productService = new ProductService(userId);
            return productService;
        }

        /// <summary>
        /// Create a new product and add it to the database.
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// Allows a user to create a new product. It will require entering in all of the required fields correctly. Before creating a product, be sure to create a Publisher and Author first in their respective tables. If the product is successfully created, returns the message "Product successfully created."
        /// </returns>
        [ResponseType(typeof(string))]
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
        /// Create a new product and add Authorship in one step.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="authorFirstName"></param>
        /// <param name="authorLastName"></param>
        /// <returns>
        /// Allows a user to create a new product, and add the Authorship through the joining table, in one step. Before creating the product, be sure to create a Publisher and Author first in their respective tables. If the product is successfully created, returns the message "Product and Authorship successfully created."
        /// </returns>
        [ResponseType(typeof(string))]
        public IHttpActionResult PostWithAuthorship(ProductCreate product, string authorFirstName, string authorLastName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProductService();

            if (!service.CreateProductWithAuthor(product, authorFirstName, authorLastName))
                return InternalServerError();

            return Ok("Product was added with Author and authorship successfully.");
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>
        /// Returns the product information for each product in the database with the ProductId, Title, AuthorId, StarRating, and TypeOfGenre.
        /// </returns>
        [ResponseType(typeof(ProductListItem))]
        public IHttpActionResult GetAll()
        {
            ProductService productService = CreateProductService();
            var products = productService.GetAllProducts();
            return Ok(products);
        }

        /// <summary>
        /// Get a range of products within a range of prices.
        /// </summary>
        /// <param name="lowPrice"></param>
        /// <param name="highPrice"></param>
        /// <returns>
        /// Allows a user to search for products within a price range by setting the low-end and high-end limits. Returns all products that fit the criteria with their ProductId, Title, AuthorId, StarRating, and Price.
        /// </returns>
        [ResponseType(typeof(ProductListItem))]
        public IHttpActionResult GetByPriceRange(decimal lowPrice, decimal highPrice)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetAllProductsWithinPriceRange(lowPrice, highPrice);
            return Ok(product);
        }

        /// <summary>
        /// Get a range of products within a range of star ratings.
        /// </summary>
        /// <param name="lowestStarRating"></param>
        /// <param name="highestStarRating"></param>
        /// <returns>
        /// Allows a user to search for products within a star rating range by setting the low-end and high-end limits. Returns all products that fit the criteria with their ProductId, Title, AuthorId, StarRating, and Price.
        /// </returns>
        [ResponseType(typeof(ProductListItem))]
        public IHttpActionResult GetByStarRatingRange(double lowestStarRating, double highestStarRating)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetAllProductsWithinStarRatingRange(lowestStarRating, highestStarRating);
            return Ok(product);
        }

        /// <summary>
        /// Get a product by partial Title.
        /// </summary>
        /// <param name="title"></param>
        /// <returns>
        /// Allows a user to search via a partial title (string) and each item in the database that matches the criteria will be returned with its ProductId, Title, AuthorId, StarRating and TypeOfGenre.
        /// </returns>
        [ResponseType(typeof(ProductListItem))]
        public IHttpActionResult GetByTitle(string title)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetTitlePartial(title);
            return Ok(product);
        }

        /// <summary>
        /// Get a product by its ProductId.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Allows a user to search for a product via that product's ID, and returns the ProductID, Title, Description, AuthorId, StarRating, TypeOfFormat, TypeOfGenre, TypeOfAudience, PublisherId, PublishYear, Price, and TypeOfCondition if a match is found.
        /// </returns>
        [ResponseType(typeof(ProductListItem))]
        public IHttpActionResult GetById(int id)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetProductById(id);
            return Ok(product);
        }

        /// <summary>
        /// Get all products from a publisher by PublisherId.
        /// </summary>
        /// <param name="publisherId"></param>
        /// <returns>
        /// Allows a user to search for products that are tied to one publisher. Returns all product that fit the criteria with their ProductId, Title, AuthorId, and StarRating.
        /// </returns>
        [ResponseType(typeof(ProductListItem))]
        public IHttpActionResult GetByProductsByPublisherId(int publisherId)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetProductByPublisherId(publisherId);
            return Ok(product);
        }

        /// <summary>
        /// Get a product by its StarRating.
        /// </summary>
        /// <param name="starRating"></param>
        /// <returns>
        /// Allows a user to search for a product via that product's star rating, and returns the ProductID, Title, AuthorId, and StarRating if a match is found.
        /// </returns>
        [ResponseType(typeof(ProductListItem))]
        public IHttpActionResult GetProductByStarRating(double starRating)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetProductByStarRating(starRating);
            return Ok(product);
        }

        /// <summary>
        /// Get a product by its TypeOfAudience.
        /// </summary>
        /// <param name="audience"></param>
        /// <returns>
        /// Allows a user to search for a product via that product's audience, and returns the ProductID, Title, AuthorId, and StarRating if a match is found.
        /// </returns>
        [ResponseType(typeof(ProductListItem))]
        public IHttpActionResult GetProductByAudience(Audience audience)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetProductByAudience(audience);
            return Ok(product);
        }

        /// <summary>
        /// Get a product by its TypeOfGenre.
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>
        /// Allows a user to search for a product via that product's genre, and returns the ProductID, Title, AuthorId, and StarRating if a match is found.
        /// </returns>
        [ResponseType(typeof(ProductListItem))]
        public IHttpActionResult GetProductByGenre(Genre genre)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetProductByGenre(genre);
            return Ok(product);
        }

        /// <summary>
        /// Edit an existing product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// Allows a user to edit an existing product by that product's ProductId. Each field must be confirmed or changed. Be sure follow the fields in the API to ensure you have all fields edited or remain unchanged. If successful, returns the message "Product successfully edited."
        /// </returns>
        [ResponseType(typeof(string))]
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
        /// Delete an existing product.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Allows a user to delete an existing product by that product's ProductId. If successful, returns the message "Product successfully deleted."
        /// </returns>
        [ResponseType(typeof(string))]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateProductService();

            if (!service.DeleteProduct(id))
                return InternalServerError();

            return Ok("Product successfully deleted.");
        }

    }
}
