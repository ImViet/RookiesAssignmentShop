using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RAShop.Backend.Data;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;

namespace RAShop.Backend
{
    public class ProductRepo : IProductRepo
    {
        private readonly RAShopDbContext _context;
        private readonly IMapper _mapper;
        public ProductRepo(RAShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductDTO>> GetAllProduct()
        {
            var products = await _context.Products.Include(x => x.SubCategory).Include(p => p.Image).Include(r => r.Ratings).ToListAsync();
            var listProdDTO = _mapper.Map<List<ProductDTO>>(products);
            return listProdDTO;
        }

        public async Task<List<ProductDTO>> GetProductByCateId(int cateid)
        {
            var products = await _context.Products.Include(x => x.SubCategory).Include(p => p.Image).Include(r => r.Ratings).Where(x => x.SubCategory.SubCategoryId == cateid).ToListAsync();
            var productDto = _mapper.Map<List<ProductDTO>>(products);
            return productDto;
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var product = await _context.Products.Include(x => x.SubCategory).Include(p => p.Image).Include(r => r.Ratings).FirstOrDefaultAsync(x => x.ProductId == id);
            ProductDTO productDto = _mapper.Map<ProductDTO>(product);
            return productDto;
        }
        public async Task<List<ProductDTO>> SearchProducts(string searchString)
        {
            var product = await _context.Products.Include(x => x.SubCategory).Include(p => p.Image).Include(r => r.Ratings).Where(x => x.ProductName.ToUpper().Contains(searchString.ToUpper())).ToListAsync();
            List<ProductDTO> productDto = _mapper.Map<List<ProductDTO>>(product);
            return productDto;
        }

        public async Task<double> RatingAVG(int id)
        {
              double ratingAvg = 0;
            var ratingProduct = await _context.Ratings.FirstOrDefaultAsync(x => x.ProductId == id);
            if(ratingProduct != null)
            {
                ratingAvg = await _context.Products.Where(p => p.ProductId == id).Select(r => r.Ratings.Average(s => s.Star)).FirstOrDefaultAsync();
            }
            else
            {
                ratingAvg=0;
            }
            return ratingAvg;
        }

        public async Task<Product> CreateProduct(Product newProduct)
        {
            var product = new Product()
            {
                ProductId = newProduct.ProductId,
                ProductName = newProduct.ProductName,
                Price = newProduct.Price,
                Quantity = newProduct.Quantity,
                Unit = newProduct.Unit,
                Origin = newProduct.Origin,
                Description = newProduct.Description,
                Image = newProduct.Image,
                SubCategory = newProduct.SubCategory
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return product;
        }

        public async Task<Product> EditProduct(int id, Product newProduct)
        {
             var product = _context.Products.Find(id);
            if (product != null)
            {
                product.ProductId = newProduct.ProductId;
                product.ProductName = newProduct.ProductName;
                product.Price = newProduct.Price;
                product.Quantity = newProduct.Quantity;
                product.Unit = newProduct.Unit;
                product.Origin = newProduct.Origin;
                product.Description = newProduct.Description;
                product.Image = newProduct.Image;
                product.SubCategory = newProduct.SubCategory;
            }
            await _context.SaveChangesAsync();
            return product;
        }


    }
}