using Moq;
using RAShop.Backend;
using RAShop.Backend.Controllers;
using RAShop.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAShop.xUnitTest.TestBackend.Controllers
{
    public class CategoryControllerTest
    {
        private List<CategoryDTO> categories = new List<CategoryDTO>()
        {
            new CategoryDTO(){ CategoryId = 1, CategoryName = "Làm sạch", Description = "", Image = ""},
            new CategoryDTO(){ CategoryId = 2, CategoryName = "Trang điểm", Description = "", Image = ""},
            new CategoryDTO(){ CategoryId = 3, CategoryName = "Chăm sóc tóc", Description = "", Image = ""},
            new CategoryDTO(){ CategoryId = 4, CategoryName = "Dưỡng da", Description = "", Image = ""},

        };
        [Fact]
        public async Task Category_GetAllCategory_ReturnAllCategory()
        {
            //Arrange
            var mockCateRepo = new Mock<ICategoryRepository>();
            mockCateRepo.Setup(x => x.GetAllCategory()).ReturnsAsync(categories); //Set phuong thuc Getallcategory
            var controller = new CategoryController(mockCateRepo.Object); // Dua vao lop controller
            //Act
            var result = await controller.GetAllCategory();
            //Assert
            Assert.Equal(categories, result.Value);
        }
        [Fact]
        public async Task Category_GetCategoryById_ReturnCategory()
        {
            //Arrange
            var mockCateRepo = new Mock<ICategoryRepository>();
            mockCateRepo.Setup(x => x.GetCategoryById(It.IsAny<int>()))
                .ReturnsAsync(categories[0]); //Set phuong thuc Getallcategory
            var controller = new CategoryController(mockCateRepo.Object); // Dua vao lop controller
            //Act
            var result = await controller.GetCategoryById(1);
            //Assert
            Assert.Equal(categories[0], result.Value);
        }
        [Fact]
        public async Task Category_CreateCate_ReturnNewCate()
        {
            //Arrange
            var newCreateCategoryDTO = new CreateCategoryDTO() { CateName = "Abc", Description = "", Image = "" };
            var newCategory = new CategoryDTO() { CategoryId = 3, CategoryName = "Abc", Description = "", Image = "" };
            var mockCateRepo = new Mock<ICategoryRepository>();
            mockCateRepo.Setup(x => x.CreateCate(newCreateCategoryDTO)).ReturnsAsync(newCategory);
            var controller = new CategoryController(mockCateRepo.Object);
            //Act
            var result = await controller.CreateCate(newCreateCategoryDTO);

            //Assert
            Assert.Equal(newCategory, result.Value);
        }
        [Fact]
        public async Task Category_DeleteCate_ReuturnCateDeteled()
        {
            var categoryDTO = new CategoryDTO() { CategoryId = 3, CategoryName = "Abc", Description = "", Image = "" };
            var mockCateRepo = new Mock<ICategoryRepository>();
            mockCateRepo.Setup(x => x.DeleteCategory(It.IsAny<int>())).ReturnsAsync(categoryDTO);
            var controller = new CategoryController(mockCateRepo.Object);
            //Act
            var result = await controller.DeleteCategory(2);

            //Assert
            Assert.Equal(categoryDTO, result.Value);
        }
    }
}
