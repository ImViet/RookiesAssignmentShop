using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RAShop.Backend.Data;
using RAShop.Backend.Models;
using RAShop.Shared.DTO;


namespace RAShop.Backend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly RAShopDbContext _context;
        private readonly IMapper _mapper;
        public ProductController(RAShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Lay tat ca san pham
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAllProduct()
        {
            var products = await _context.Products.Include(x => x.SubCategory).Include(p => p.Image).ToListAsync();
            var listProdDTO = _mapper.Map<List<ProductDTO>>(products);
            return listProdDTO;
        }

        //Lay san pham theo id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await _context.Products.Include(x => x.SubCategory).Include(p => p.Image).FirstOrDefaultAsync(x => x.ProductId == id);
            ProductDTO productDto = _mapper.Map<ProductDTO>(product);
            return productDto;
        }

         //Lay san pham theo category id
        [HttpGet("{cateid}")]
        public async Task<ActionResult<List<ProductDTO>>> GetProductByCateId(int cateid)
        {
            var products = await _context.Products.Include(x => x.SubCategory).Include(p => p.Image).Where(x => x.SubCategory.SubCategoryId == cateid).ToListAsync();
            var productDto = _mapper.Map<List<ProductDTO>>(products);
            return productDto;
        }
        //Tim kiem san pham theo ten
        [HttpGet("{searchString}")]
        public async Task<ActionResult<List<ProductDTO>>> SearchProducts(string searchString)
        {
            var product = await _context.Products.Include(x => x.SubCategory).Include(p => p.Image).Where(x => x.ProductName.ToUpper().Contains(searchString.ToUpper())).ToListAsync();
            List<ProductDTO> productDto = _mapper.Map<List<ProductDTO>>(product);
            return productDto;
        }

        //Tao moi san pham
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product newProduct)
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

        //Sua mot san pham
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> EditProduct(int id, Product newProduct)
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
            return Ok();
        }

        //Xoa san pham
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
