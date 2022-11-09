using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RAShop.Backend.Data;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;
using RAShop.Backend.Extensions;
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
        public async Task<PagingDTO<ProductDTO>> GetProductAdmin(string search,  string sortOrder, int pageNumber, int pageSize)
        {
            //Query product
            var productQuery = _context.Products.AsQueryable();
            if(search != "")
            {
                productQuery = productQuery.Where(x => x.ProductName.ToUpper().Contains(search.ToUpper()));
            }
           
            //Sort 
            productQuery = SortProduct.Sorting(productQuery, sortOrder);

            var countProduct = await productQuery.CountAsync();
            //Paging
            var products = await productQuery.Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .Include(x => x.SubCategory)
                                    .Include(x => x.Category)
                                    .Include(r => r.Ratings)
                                    .ToListAsync();
            var listProdDTO = _mapper.Map<List<ProductDTO>>(products);
            var totalPages = (int)Math.Ceiling((double)countProduct / pageSize);
            return new PagingDTO<ProductDTO> { TotalPages = totalPages, items = listProdDTO };
        }
        public async Task<PagingDTO<ProductDTO>> GetAllProduct(string sortOrder, int pageNumber, int pageSize)
        {
            //Query product
            var productQuery = _context.Products.AsQueryable();
            //Sort 
            productQuery = SortProduct.Sorting(productQuery, sortOrder);

            var countProduct = await productQuery.CountAsync();
            //Paging
            var products = await productQuery.Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .Include(x => x.SubCategory)
                                    .Include(x => x.Category)
                                    .Include(r => r.Ratings)
                                    .ToListAsync();
            var listProdDTO = _mapper.Map<List<ProductDTO>>(products);
            var totalPages = (int)Math.Ceiling((double)countProduct / PagingDTO<ProductDTO>.PAGESIZE);
            return new PagingDTO<ProductDTO> { TotalPages = totalPages, items = listProdDTO };
        }

        public async Task<PagingDTO<ProductDTO>> GetProductByCateId(int cateid, string sortOrder, int pageNumber, int pageSize)
        {
            //Query product
            var productQuery = _context.Products.Where(x => x.Category.CategoryId == cateid);
            //Sort 
            productQuery = SortProduct.Sorting(productQuery, sortOrder);
            var countProduct = await productQuery.CountAsync();
            //Paging
            var products = await productQuery
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .Include(x => x.SubCategory)
                                    .Include(x => x.Category)
                                    .Include(r => r.Ratings)
                                    .ToListAsync();
            var listProdDTO = _mapper.Map<List<ProductDTO>>(products);
            var totalPages = (int)Math.Ceiling((double)countProduct / PagingDTO<ProductDTO>.PAGESIZE);
            return new PagingDTO<ProductDTO> { TotalPages = totalPages, items = listProdDTO };
        }
        public async Task<PagingDTO<ProductDTO>> GetProductBySubCateId(int cateid, string sortOrder, int pageNumber, int pageSize)
        {
            //Query product
            var productQuery = _context.Products.Where(x => x.SubCategory.SubCategoryId == cateid);
            //Sort 
            productQuery = SortProduct.Sorting(productQuery, sortOrder);
            //Paging
            var products = await productQuery
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .Include(x => x.SubCategory)
                                    .Include(x => x.Category)
                                    .Include(r => r.Ratings)
                                    .ToListAsync();
            var countProduct = await productQuery.CountAsync();
            var listProdDTO = _mapper.Map<List<ProductDTO>>(products);
            var totalPages = (int)Math.Ceiling((double)countProduct / PagingDTO<ProductDTO>.PAGESIZE);
            return new PagingDTO<ProductDTO> { TotalPages = totalPages, items = listProdDTO };
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            //Query product
            var product = await _context.Products.Include(x => x.SubCategory).Include(r => r.Ratings).FirstOrDefaultAsync(x => x.ProductId == id);
            ProductDTO productDto = _mapper.Map<ProductDTO>(product);
            return productDto;
        }
        public async Task<PagingDTO<ProductDTO>> SearchProducts(string searchString, string sortOrder, int pageNumber, int pageSize)
        {
            //Query product
            var productQuery = _context.Products.Where(x => x.ProductName.ToUpper().Contains(searchString.ToUpper()));
            if (searchString != "")
            {
                //Sort 
                productQuery = SortProduct.Sorting(productQuery, sortOrder);
            }
            else
                return new PagingDTO<ProductDTO>{TotalPages = 1, items = null};
            //Paging
            var products = await productQuery
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .Include(x => x.SubCategory)
                                    .Include(x => x.Category)
                                    .Include(r => r.Ratings)
                                    .ToListAsync();
            var countProduct = await productQuery.CountAsync();
            List<ProductDTO> listProdDTO = _mapper.Map<List<ProductDTO>>(products);
            var totalPages = (int)Math.Ceiling((double)countProduct / PagingDTO<ProductDTO>.PAGESIZE);
            return new PagingDTO<ProductDTO> { TotalPages = totalPages, items = listProdDTO };
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

        public async Task<ProductDTO> CreateProduct(CreateProductDTO newProduct)
        {
            var product = _mapper.Map<Product>(newProduct);
            product.DateCreated = DateTime.Now;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<ProductDTO>(product);
            return result;
        }

        public async Task<ProductDTO> DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            var result = _mapper.Map<ProductDTO>(product);
            return result;
        }

        public async Task<ProductDTO> EditProduct(EditProductDTO newProduct)
        {
            var product = _context.Products.Include(c => c.Category).Include(s => s.SubCategory).FirstOrDefault(x => x.ProductId == newProduct.ProductId);
            if (product != null)
            {
                _context.Products.Update(product);
                _mapper.Map(newProduct, product);
                product.DateUpdated = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            var result = _mapper.Map<ProductDTO>(product);
            return result;
        }


    }
}