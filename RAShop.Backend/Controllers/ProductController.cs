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
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        //Lay san pham cho Admin
        [HttpPost]
        public async Task<ActionResult<PagingDTO<ProductDTO>>> GetProductAdmin(
            [FromBody] ProductAdminSearchDTO model)
        {
            return await _productRepo.GetProductAdmin(model.Query, model.SortOrder, model.Page, model.PageSize, model.cateId, model.subCateId);
        }
        //Lay tat ca san pham
        [HttpGet]
        public async Task<ActionResult<PagingDTO<ProductDTO>>> GetAllProduct([FromQuery(Name = "sort")] string sortOrder = "0", [FromQuery(Name = "pageCurrent")] int pageNumber = 1)
        {
            return await _productRepo.GetAllProduct(sortOrder, pageNumber, PagingDTO<ProductDTO>.PAGESIZE);
        }

        //Lay san pham theo id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            return await _productRepo.GetProductById(id);
        }

        //Lay san pham theo category id
        [HttpGet()]
        public async Task<ActionResult<PagingDTO<ProductDTO>>> GetProductByCateId([FromQuery(Name = "cateid")] int cateid, [FromQuery(Name = "sort")] string sortOrder = "0", [FromQuery(Name = "pageCurrent")] int pageNumber = 1)
        {
            return await _productRepo.GetProductByCateId(cateid, sortOrder, pageNumber, PagingDTO<ProductDTO>.PAGESIZE);
        }
        //Lay san pham theo sub category id
        [HttpGet()]
        public async Task<ActionResult<PagingDTO<ProductDTO>>> GetProductBySubCateId([FromQuery(Name = "cateid")] int cateid, [FromQuery(Name = "sort")] string sortOrder = "0", [FromQuery(Name = "pageCurrent")] int pageNumber = 1)
        {
            return await _productRepo.GetProductBySubCateId(cateid, sortOrder, pageNumber, PagingDTO<ProductDTO>.PAGESIZE);
        }
        //Tim kiem san pham theo ten
        [HttpGet()]
        public async Task<ActionResult<PagingDTO<ProductDTO>>> SearchProducts([FromQuery(Name = "searchstring")] string searchString = "", [FromQuery(Name = "sort")] string sortOrder = "0", [FromQuery(Name = "pageCurrent")] int pageNumber = 1)
        {
            return await _productRepo.SearchProducts(searchString, sortOrder, pageNumber, PagingDTO<ProductDTO>.PAGESIZE);
        }

        //Lay so sao trung binh
        [HttpGet("{id}")]
        public async Task<double> RatingAVG(int id)
        {
            return await _productRepo.RatingAVG(id);
        }

        //Tao moi san pham
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody]CreateProductDTO newProduct)
        {
            return await _productRepo.CreateProduct(newProduct);
        }

        //Sua mot san pham
        [HttpPut]
        public async Task<ActionResult<ProductDTO>> EditProduct([FromBody]EditProductDTO newProduct)
        {
            return await _productRepo.EditProduct(newProduct);
        }

        //Xoa san pham
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO>> DeleteProduct(int id)
        {
            return await _productRepo.DeleteProduct(id);
        }
    }
}
