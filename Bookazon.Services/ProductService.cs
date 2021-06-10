using Bookazon.Data;
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
                    TypeOfFormat = model.TypeOfFormat,
                    TypeofGenre = model.TypeofGenre,
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
<<<<<<< HEAD
                            Authors = e.Authors.ToArray(),
=======
                            Authors = e.Authors.Select(a => a.AuthorId).ToList(),
>>>>>>> d318452872a406ec625342b2a66037581b60e9cb
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
                        TypeOfFormat = entity.TypeOfFormat,
                        TypeofGenre = entity.TypeofGenre,
                        PublisherId = entity.PublisherId,
                        PublishYear = entity.PublishYear,
                        Price = entity.Price,
                        TypeOfCondition = entity.TypeOfCondition
                    };
            }
        }

        public bool UpdateProduct (ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.Id == model.Id && e.ManagerId == _managerId);

                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.TypeofGenre = model.TypeofGenre;
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
    

