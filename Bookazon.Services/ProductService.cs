using Bookazon.Data;
using Bookazon.Models.Author;
using Bookazon.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookazon.Services
{
    public class ProductService
    {
        private readonly Guid _managerId;

        public ProductService(Guid managerId)
        {
            _managerId = managerId;
        }
        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {
                    ManagerId = _managerId,
                    Title = model.Title,
                    Description = model.Description,
                    StarRating = model.StarRating,
                    TypeOfFormat = model.TypeOfFormat,
                    TypeOfGenre = model.TypeOfGenre,
                    TypeOfAudience = model.TypeOfAudience,
                    PublisherId = model.PublisherId,
                    PublishYear = model.PublishYear,
                    Price = model.Price,
                    TypeOfCondition = model.TypeOfCondition
                };

            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Products.Any(e => e.Title == entity.Title && e.Description == entity.Description))
                    return false;
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool CreateProductWithAuthor(ProductCreate model, string authorFirstName, string authorLastName)
        {
            var entity =
                new Product()
                {
                    ManagerId = _managerId,
                    Title = model.Title,
                    Description = model.Description,
                    StarRating = model.StarRating,
                    TypeOfFormat = model.TypeOfFormat,
                    TypeOfGenre = model.TypeOfGenre,
                    TypeOfAudience = model.TypeOfAudience,
                    PublisherId = model.PublisherId,
                    PublishYear = model.PublishYear,
                    Price = model.Price,
                    TypeOfCondition = model.TypeOfCondition
                };

            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Products.Any(e => e.Title == entity.Title && e.Description == entity.Description))
                    return false;
                
                ctx.Products.Add(entity);
                bool productWasAdded = ctx.SaveChanges() == 1;
                bool hasAuthor = ctx.Authors.Any(e => e.LastName == authorLastName && e.FirstName == authorFirstName);
                if (hasAuthor)
                {
                    var foundAuthorId =
                        ctx
                        .Authors
                        .Single(e => e.LastName == authorLastName && e.FirstName == authorFirstName);

                    AuthorshipService connecter = new AuthorshipService(_managerId);
                    var findNewProductId = ctx.Products.Single(e => e.Title == model.Title);
                    bool authorshipWasAdded = connecter.ConnectAuthorToBook(findNewProductId.Id, foundAuthorId.AuthorId);
                    if (productWasAdded == true && authorshipWasAdded == true) return true;
                }
                else
                {
                    AuthorService authorService = new AuthorService(_managerId);
                    AuthorCreate newAuthor = new AuthorCreate();
                    newAuthor.FirstName = authorFirstName;
                    newAuthor.LastName = authorLastName;
                    bool authorWasAdded = authorService.CreateAuthor(newAuthor);
                    var findNewAuthorId = ctx.Authors.Single(e => e.LastName == authorLastName && e.FirstName == authorFirstName);
                    var findNewProductId = ctx.Products.Single(e => e.Title == model.Title);
                    AuthorshipService connecter = new AuthorshipService(_managerId);
                    bool authorshipWasAdded = connecter.ConnectAuthorToBook(findNewProductId.Id, findNewAuthorId.AuthorId);
                    if (productWasAdded && authorshipWasAdded && authorshipWasAdded) return true;
                }
                return false;
            }


        }

        public IEnumerable<ProductListItem> GetAllProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Products
                    .Select(
                        e =>
                        new ProductListItem
                        {
                            ProductId = e.Id,
                            Title = e.Title,
                            Authors = e.Authors.Select(a => a.Author.FirstName + " " + a.Author.LastName).ToList(),
                            StarRating = e.StarRating,
                            TypeOfGenre = e.TypeOfGenre
                        }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<ProductPriceRangeItem> GetAllProductsWithinPriceRange(decimal lowestPrice, decimal highestPrice)
        {
            using (var ctx = new ApplicationDbContext())
            {                               
                var query =
                    ctx
                    .Products
                    .Where(e => e.Price >= lowestPrice && e.Price <= highestPrice)
                    .Select(
                        e =>
                        new ProductPriceRangeItem
                        {
                            ProductId = e.Id,
                            Title = e.Title,
                            Authors = e.Authors.Select(a => a.Author.FirstName + " " + a.Author.LastName).ToList(),
                            StarRating = e.StarRating,
                            Price = e.Price
                        }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<ProductStarRatingRangeItem> GetAllProductsWithinStarRatingRange(double lowestStarRating, double highestStarRating)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Products
                    .Where(e => e.StarRating >= lowestStarRating && e.StarRating <= highestStarRating)
                    .Select(
                        e =>
                        new ProductStarRatingRangeItem
                        {
                            ProductId = e.Id,
                            Title = e.Title,
                            Authors = e.Authors.Select(a => a.Author.FirstName + " " + a.Author.LastName).ToList(),
                            StarRating = e.StarRating,
                            Price = e.Price
                        }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<ProductListItem> GetTitlePartial(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Products
                    .Where(e => e.Title.Contains(title))
                    .Select(
                        e =>
                        new ProductListItem
                        {
                            ProductId = e.Id,
                            Title = e.Title,
                            Authors = e.Authors.Select(a => a.Author.FirstName + " " + a.Author.LastName).ToList(),
                            StarRating = e.StarRating,
                            TypeOfGenre = e.TypeOfGenre
                        }
                        );
                return query.ToArray();
            }
        }

        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.Products.Any(e => e.Id == id))
                    return null;
                
                var entity =
                    ctx
                    .Products
                    .Single(e => e.Id == id);
                return
                    new ProductDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Description = entity.Description,
                        Authors = entity.Authors.Select(a => a.Author.FirstName + " " + a.Author.LastName).ToList(),
                        StarRating = entity.StarRating,
                        TypeOfFormat = entity.TypeOfFormat,
                        TypeOfGenre = entity.TypeOfGenre,
                        TypeOfAudience = entity.TypeOfAudience,
                        PublisherId = entity.PublisherId,
                        PublishYear = entity.PublishYear,
                        Price = entity.Price,
                        TypeOfCondition = entity.TypeOfCondition
                    };
            }
        }

        public IEnumerable<ProductDetail> GetProductByPublisherId(int publisherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.Products.Any(e => e.PublisherId == publisherId))
                    return null;

                var query =
                    ctx
                    .Products
                    .Where(e => e.PublisherId == publisherId)
                    .Select(
                        e =>
                        new ProductDetail
                        {
                            Id = e.Id,
                            Title = e.Title,
                            Authors = e.Authors.Select(a => a.Author.FirstName + " " + a.Author.LastName).ToList(),
                            StarRating = e.StarRating
                        }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<ProductListItem> GetProductByStarRating(double starRating)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.Products.Any(e => e.StarRating == starRating))
                    return null;

                var query =
                    ctx
                    .Products
                    .Where(e => e.StarRating == starRating)
                    .Select(
                        e =>
                        new ProductListItem
                        {
                            ProductId = e.Id,
                            Title = e.Title,
                            Authors = e.Authors.Select(a => a.Author.FirstName + " " + a.Author.LastName).ToList(),
                            StarRating = e.StarRating
                        }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<ProductListItem> GetProductByAudience(Audience audience)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.Products.Any(e => e.TypeOfAudience == audience))
                    return null;

                var query =
                    ctx
                    .Products
                    .Where(e => e.TypeOfAudience == audience) 
                    .Select(
                        e =>
                        new ProductListItem
                        {
                            ProductId = e.Id,
                            Title = e.Title,
                            Authors = e.Authors.Select(a => a.Author.FirstName + " " + a.Author.LastName).ToList(),
                            StarRating = e.StarRating
                        }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<ProductListItem> GetProductByGenre(Genre genre)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.Products.Any(e => e.TypeOfGenre == genre))
                    return null;

                var query =
                    ctx
                    .Products
                    .Where(e => e.TypeOfGenre == genre)
                    .Select(
                        e =>
                        new ProductListItem
                        {
                            ProductId = e.Id,
                            Title = e.Title,
                            Authors = e.Authors.Select(a => a.Author.FirstName + " " + a.Author.LastName).ToList(),
                            StarRating = e.StarRating
                        }
                        );

                return query.ToArray();
            }
        }

        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.Products.Any(e => e.Id == model.Id))
                    return false;

                var entity =
                    ctx
                    .Products
                    .Single(e => e.Id == model.Id && e.ManagerId == _managerId);

                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.StarRating = model.StarRating;
                entity.TypeOfGenre = model.TypeOfGenre;
                entity.TypeOfAudience = model.TypeOfAudience;
                entity.PublisherId = model.PublisherId;
                entity.PublishYear = model.PublishYear;
                entity.Price = model.Price;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProduct(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.Products.Any(e => e.Id == productId))
                    return false;

                var entity =
                    ctx
                    .Products
                    .Single(e => e.Id == productId && e.ManagerId == _managerId);

                ctx.Products.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}


