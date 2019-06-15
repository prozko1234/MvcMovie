using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Controllers;
using MvcMovie.Data;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void MovieReturnTypeTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            var _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var controller = new MoviesController(_dbContext);
            
            var result = controller.Index();
            
            Assert.IsType<Task<IActionResult>>(result);
        }

        [Fact]
        public void HomeMessageFieldTest()
        {
            string test = "Your application description page.";

            var controller = new HomeController();

            var result = controller.message1;

            Assert.Equal(test, result);
        }

        [Fact]
        public void HomeAboutReturnTest()
        {
            var controller = new HomeController();

            var result = controller.About();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void HomeIndexReturnTest()
        {
            var controller = new HomeController();

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void MovieNotExistsTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            var _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var controller = new MoviesController(_dbContext);

            var result = controller.MovieExists(5);

            Assert.False(result);
        }
    }
}
