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
                    TypeofGenre = model.TypeofGenre,
                    TypeofAudience = model.TypeofAudience,
                    PublisherId = model.PublisherId,
                    PublishYear = model.PublishYear,
                    Price = model.Price,
                    TypeOfCondition = model.TypeOfCondition
                };

            using (var ctx = new ApplicationDbContext())
            {
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
                    TypeofGenre = model.TypeofGenre,
                    TypeofAudience = model.TypeofAudience,
                    PublisherId = model.PublisherId,
                    PublishYear = model.PublishYear,
                    Price = model.Price,
                    TypeOfCondition = model.TypeOfCondition
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                bool productWasAdded = ctx.SaveChanges() == 1;
                var foundAuthorId =
                    ctx
                    .Authors
                    .Single(e => e.LastName == authorFirstName && e.FirstName == authorFirstName);

                if (foundAuthorId != null)
                {
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
                    var findNewAuthorId = ctx.Authors.Single(e => e.LastName == authorFirstName && e.FirstName == authorFirstName);
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
                            Authors = e.Authors.Select(a => a.AuthorId).ToList(),
                            StarRating = e.StarRating,
                            TypeOfGenre = e.TypeofGenre
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
                            Authors = e.Authors.Select(a => a.AuthorId).ToList(),
                            StarRating = e.StarRating,
                            TypeOfGenre = e.TypeofGenre
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
                            Authors = e.Authors.Select(a => a.AuthorId).ToList(),
                            StarRating = e.StarRating,
                            TypeOfGenre = e.TypeofGenre
                        }
                        );
                return query.ToArray();
            }
        }

        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
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
                        Authors = entity.Authors.Select(a => a.AuthorId).ToList(),
                        StarRating = entity.StarRating,
                        TypeOfFormat = entity.TypeOfFormat,
                        TypeofGenre = entity.TypeofGenre,
                        TypeofAudience = entity.TypeofAudience,
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
                            Authors = e.Authors.Select(a => a.AuthorId).ToList()
                        }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<ProductListItem> GetProductByStarRating(double starRating)
        {
            using (var ctx = new ApplicationDbContext())
            {
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
                            Authors = e.Authors.Select(a => a.AuthorId).ToList(),
                            StarRating = e.StarRating
                        }
                        );

                return query.ToArray();
            }
        }

        public ProductDetail GetProductByAudience(Audience audience)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Products
                    .Where(e => e.TypeofAudience == typeOfAudience)
                    .Select(
                        e =>
                        new ProductListItem
                        {
                            ProductId = e.Id,
                            Title = e.Title,
                            Authors = e.Authors.Select(a => a.AuthorId).ToList(),
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
                var entity =
                    ctx
                    .Products
                    .Single(e => e.Id == model.Id && e.ManagerId == _managerId);

                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.StarRating = model.StarRating;
                entity.TypeofGenre = model.TypeofGenre;
                entity.TypeofAudience = model.TypeofAudience;
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


