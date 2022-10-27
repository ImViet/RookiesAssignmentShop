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
        private readonly IProductRepo _productRepo;
        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        //Lay tat ca san pham
        [HttpGet]
        public async Task<PagingDTO> GetAllProduct([FromQuery(Name = "pageCurrent")] int pageNumber = 1)
        {
            return await _productRepo.GetAllProduct(pageNumber, PagingDTO.PAGESIZE);
        }

        //Lay san pham theo id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            return await _productRepo.GetProductById(id);
        }

        //Lay san pham theo category id
        [HttpGet("{cateid}")]
        public async Task<ActionResult<List<ProductDTO>>> GetProductByCateId(int cateid)
        {
            return await _productRepo.GetProductByCateId(cateid);
        }
        //Tim kiem san pham theo ten
        [HttpGet("{searchString}")]
        public async Task<ActionResult<List<ProductDTO>>> SearchProducts(string searchString, int pageNumber, int pageSize)
        {
            return await _productRepo.SearchProducts(searchString, pageNumber, pageSize);
        }

        //Lay so sao trung binh
        [HttpGet("{id}")]
        public async Task<double> RatingAVG(int id)
        {
            return await _productRepo.RatingAVG(id);
        }

        //Tao moi san pham
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product newProduct)
        {
            return await _productRepo.CreateProduct(newProduct);
        }

        //Sua mot san pham
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> EditProduct(int id, Product newProduct)
        {
            return await _productRepo.EditProduct(id, newProduct);
        }

        //Xoa san pham
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            return await _productRepo.DeleteProduct(id);
        }
    }
}
