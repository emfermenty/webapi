using api.Controllers;
using api.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class AuthorControllerTests
    {
        private readonly Mock<IAuthorService> _mockservice;
        private readonly AuthorController _controller;
        public AuthorControllerTests()
        {
            _mockservice = new Mock<IAuthorService>();
            _controller = new AuthorController(_mockservice.Object);
        }
        [Fact]
        public async Task GetAllAuthors_ReturnsOkResult()
        {
            //Arrange
            var authors = new List<Author>() { new Author(), new Author() };
            _mockservice.Setup(x => x.GetAllAuthors(It.IsAny<CancellationToken>()))
                .ReturnsAsync(authors);
            //Act
            var result = await _controller.GetAllAuthors(CancellationToken.None);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedResult = Assert.IsAssignableFrom<List<Author>>(okResult.Value);
            Assert.Equal(2, returnedResult.Count);
        }
        [Fact]
        public async Task GetById_ReturnOkResult_WhenAuthorExists()
        {
            var author = new Author { id = 1 };
            _mockservice.Setup(x => x.GetAuthorByIdAsync(1, It.IsAny<CancellationToken>()))
                .ReturnsAsync(author);

            var result = await _controller.GetById(1, CancellationToken.None);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(author, okResult.Value);
        }
        [Fact]
        public async Task GetById_ReturnNotFound_WhenAuthorDoesNotExist()
        {
            _mockservice.Setup(x => x.GetAuthorByIdAsync(1, It.IsAny<CancellationToken>()));

            var result = await _controller.GetById(1, CancellationToken.None);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
