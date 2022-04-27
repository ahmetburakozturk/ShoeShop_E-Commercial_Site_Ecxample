using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.Dtos;
using ShoeShop.Entities;

namespace ShoeShop.DataAccess.Concrete.Repository
{
    public class EfProductRepository : IProductRepository
    {
        private readonly ShoeShopDbContext _dbContext;

        public EfProductRepository(ShoeShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<Product> GetAll()
        {
            return _dbContext.Products.ToList(); ;
        }

        public Product GetById(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public int Add(Product entity)
        {
            entity.Discount = entity.Discount / 10;
            entity.Discount = entity.Discount / 100;
             _dbContext.Products.Add(entity);
            _dbContext.SaveChanges();
            return entity.ID;
        }

        public int Update(Product entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
            return entity.ID;
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsExists(int id)
        {
            return _dbContext.Products.Any(p => p.ID == id);
        }

        public IQueryable<ProductDto> GetProductByIdWithDetails(int id)
        {
            var innerJoin = from pdt in _dbContext.Products
                    join brd in _dbContext.Brands on pdt.BrandID equals brd.ID
                    join cat in _dbContext.Categories on pdt.CategoryID equals cat.ID
                    join clr in _dbContext.Colors on pdt.ColorID equals clr.ID
                    join gen in _dbContext.Genders on pdt.GenderID equals gen.ID
                    where pdt.ID == id
                            select new ProductDto
                    {
                        ID = pdt.ID,
                        Name = pdt.Name,
                        ImageUrl = pdt.ImageUrl,
                        ImageUrl2 = pdt.ImageUrl2,
                        ImageUrl3 = pdt.ImageUrl3,
                        ImageUrl4 = pdt.ImageUrl4,
                        Price = pdt.Price,
                        Discount = pdt.Discount,
                        BrandName = brd.Name,
                        Size = pdt.Size,
                        Material = pdt.Material,
                        CategoryName = cat.Name,
                        ColorName = clr.Name,
                        GenderName = gen.Name
                    };
            return innerJoin;
        }

        public IQueryable<ProductDto> GetProductById(int id)
        {
            var innerJoin = from pdt in _dbContext.Products
                join brd in _dbContext.Brands on pdt.BrandID equals brd.ID
                join cat in _dbContext.Categories on pdt.CategoryID equals cat.ID
                join clr in _dbContext.Colors on pdt.ColorID equals clr.ID
                join gen in _dbContext.Genders on pdt.GenderID equals gen.ID
                where pdt.ID == id
                select new ProductDto
                {
                    ID = pdt.ID,
                    Name = pdt.Name,
                    BrandID = pdt.BrandID,
                    CategoryID = pdt.CategoryID,
                    ColorID = pdt.ColorID,
                    GenderID = pdt.GenderID,
                    Size = pdt.Size,
                    ImageUrl = pdt.ImageUrl,
                    ImageUrl2 = pdt.ImageUrl2,
                    ImageUrl3 = pdt.ImageUrl3,
                    ImageUrl4 = pdt.ImageUrl4,
                    Price = pdt.Price,
                    Discount = pdt.Discount,
                    Material = pdt.Material,
                    IsActive = pdt.IsActive
                };
            return innerJoin;
        }

        public ICollection<ProductDto> GetAllActiveProductsWithBrand()
        {
            var productDtoList = new List<ProductDto>();
            var innerJoin = from pdt in _dbContext.Products
                join cat in _dbContext.Categories on pdt.CategoryID equals cat.ID
                join brd in _dbContext.Brands on pdt.BrandID equals brd.ID
                join gen in _dbContext.Genders on pdt.GenderID equals gen.ID
                join col in _dbContext.Colors on pdt.ColorID equals col.ID
                where pdt.IsActive == true
                select new
                {
                    ID = pdt.ID,
                    Name = pdt.Name,
                    ImageUrl = pdt.ImageUrl,
                    Price = pdt.Price,
                    Discount = pdt.Discount,
                    BrandName = brd.Name,
                    IsActive = pdt.IsActive,
                    CategoryName = cat.Name,
                    GenderID = gen.ID,
                    ColorID = col.ID,
                    BrandID = brd.ID
                };
            foreach (var data in innerJoin)
            {
                var poroductDto = new ProductDto
                {
                    ID = data.ID,
                    Name = data.Name,
                    BrandName = data.BrandName,
                    Discount = data.Discount,
                    ImageUrl = data.ImageUrl,
                    IsActive = data.IsActive,
                    Price = data.Price,
                    CategoryName = data.CategoryName,
                    GenderID = data.GenderID,
                    ColorID = data.ColorID,
                    BrandID = data.BrandID
                };
                productDtoList.Add(poroductDto);
            }
            return productDtoList;
        }
    }
}
