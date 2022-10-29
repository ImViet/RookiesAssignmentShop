using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RAShop.Backend.Data;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;

namespace RAShop.Backend
{
    public class ProductRepository : IProductRepository
    {
        private readonly RAShopDbContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(RAShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PagingDTO> GetAllProduct(string sortOrder, int pageNumber, int pageSize)
        {

            var productQuery = _context.Products.AsQueryable();
            if (sortOrder != "0")
            {
                switch (sortOrder)
                {
                    case "price":
                        productQuery = productQuery.OrderBy(p => p.Price);
                        break;
                    case "price_desc":
                        productQuery = productQuery.OrderByDescending(p => p.Price);
                        break;
                    case "name":
                        productQuery = productQuery.OrderBy(p => p.ProductName);
                        break;
                    case "name_desc":
                        productQuery = productQuery.OrderByDescending(p => p.ProductName);
                        break;
                    default:
                        productQuery = productQuery.OrderBy(p => p.ProductId);
                        break;
                }
            }
            var countProduct = await productQuery.CountAsync();
            var products = await productQuery.Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .Include(x => x.SubCategory)
                                    .Include(x => x.Category)
                                    .Include(r => r.Ratings)
                                    .ToListAsync();
            var listProdDTO = _mapper.Map<List<ProductDTO>>(products);
            var totalPages = (int)Math.Ceiling((double)countProduct / PagingDTO.PAGESIZE);
            return new PagingDTO { TotalPages = totalPages, Products = listProdDTO };
        }

        public async Task<PagingDTO> GetProductByCateId(int cateid, string sortOrder, int pageNumber, int pageSize)
        {
            var productQuery = _context.Products.Where(x => x.Category.CategoryId == cateid);
            if (!string.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "price":
                        productQuery = productQuery.OrderBy(p => p.Price);
                        break;
                    case "price_desc":
                        productQuery = productQuery.OrderByDescending(p => p.Price);
                        break;
                    case "name":
                        productQuery = productQuery.OrderBy(p => p.ProductName);
                        break;
                    case "name_desc":
                        productQuery = productQuery.OrderByDescending(p => p.ProductName);
                        break;
                    default:
                        productQuery = productQuery.OrderBy(p => p.ProductId);
                        break;
                }
            }
            var countProduct = await productQuery.CountAsync();
            var products = await productQuery
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .Include(x => x.SubCategory)
                                    .Include(x => x.Category)
                                    .Include(r => r.Ratings)
                                    .ToListAsync();
            var listProdDTO = _mapper.Map<List<ProductDTO>>(products);
            var totalPages = (int)Math.Ceiling((double)countProduct / PagingDTO.PAGESIZE);
            return new PagingDTO { TotalPages = totalPages, Products = listProdDTO };
        }
        public async Task<PagingDTO> GetProductBySubCateId(int cateid, string sortOrder, int pageNumber, int pageSize)
        {
            var productQuery = _context.Products.Where(x => x.SubCategory.SubCategoryId == cateid);
            if (!string.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "price":
                        productQuery = productQuery.OrderBy(p => p.Price);
                        break;
                    case "price_desc":
                        productQuery = productQuery.OrderByDescending(p => p.Price);
                        break;
                    case "name":
                        productQuery = productQuery.OrderBy(p => p.ProductName);
                        break;
                    case "name_desc":
                        productQuery = productQuery.OrderByDescending(p => p.ProductName);
                        break;
                    default:
                        productQuery = productQuery.OrderBy(p => p.ProductId);
                        break;
                }
            }
            var products = await productQuery
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .Include(x => x.SubCategory)
                                    .Include(x => x.Category)
                                    .Include(r => r.Ratings)
                                    .ToListAsync();
            var countProduct = await productQuery.CountAsync();
            var listProdDTO = _mapper.Map<List<ProductDTO>>(products);
            var totalPages = (int)Math.Ceiling((double)countProduct / PagingDTO.PAGESIZE);
            return new PagingDTO { TotalPages = totalPages, Products = listProdDTO };
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var product = await _context.Products.Include(x => x.SubCategory).Include(r => r.Ratings).FirstOrDefaultAsync(x => x.ProductId == id);
            ProductDTO productDto = _mapper.Map<ProductDTO>(product);
            return productDto;
        }
        public async Task<PagingDTO> SearchProducts(string searchString, string sortOrder, int pageNumber, int pageSize)
        {
            var productQuery = _context.Products.Where(x => x.ProductName.ToUpper().Contains(searchString.ToUpper()));
            if (searchString != "")
            {
                if (!string.IsNullOrEmpty(sortOrder))
                {
                    switch (sortOrder)
                    {
                        case "price":
                            productQuery = productQuery.OrderBy(p => p.Price);
                            break;
                        case "price_desc":
                            productQuery = productQuery.OrderByDescending(p => p.Price);
                            break;
                        case "name":
                            productQuery = productQuery.OrderBy(p => p.ProductName);
                            break;
                        case "name_desc":
                            productQuery = productQuery.OrderByDescending(p => p.ProductName);
                            break;
                        default:
                            productQuery = productQuery.OrderBy(p => p.ProductId);
                            break;
                    }
                }
            }
            else
                return new PagingDTO{TotalPages = 1, Products = null};

            var products = await productQuery
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .Include(x => x.SubCategory)
                                    .Include(x => x.Category)
                                    .Include(r => r.Ratings)
                                    .ToListAsync();
            var countProduct = await productQuery.CountAsync();
            List<ProductDTO> listProdDTO = _mapper.Map<List<ProductDTO>>(products);
            var totalPages = (int)Math.Ceiling((double)countProduct / PagingDTO.PAGESIZE);
            return new PagingDTO { TotalPages = totalPages, Products = listProdDTO };
        }

        public async Task<double> RatingAVG(int id)
        {
            double ratingAvg = 0;
            var ratingProduct = await _context.Ratings.FirstOrDefaultAsync(x => x.ProductId == id);
            if (ratingProduct != null)
            {
                ratingAvg = await _context.Products.Where(p => p.ProductId == id).Select(r => r.Ratings.Average(s => s.Star)).FirstOrDefaultAsync();
            }
            else
            {
                ratingAvg = 0;
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
                MainImg = newProduct.MainImg,
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
                product.MainImg = newProduct.MainImg;
                product.SubCategory = newProduct.SubCategory;
            }
            await _context.SaveChangesAsync();
            return product;
        }


    }
}