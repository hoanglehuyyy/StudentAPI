using System;
using Application.Dtos.ClassDtos;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Web.Controllers;

namespace UnitTest.Web.Tests.Controllers
{
	public class ClassControllerTest
	{
		private readonly ClassController _controller;
		private readonly Mock<IClassService> _mockClassService;
		public ClassControllerTest()
		{
			_mockClassService = new Mock<IClassService>();
			_controller = new ClassController(_mockClassService.Object);
		}
		[Fact]
		public async Task GetAllClasses_ReturnAllClasses()
		{
			// Arrange
			List<ClassViewDto> validResult = new List<ClassViewDto>() { new ClassViewDto { Id = 1, ClassName = "6A", Grade = 6, NumOfStudents = 5 } };
			_mockClassService.Setup(s => s.GetAllClasses())
				.ReturnsAsync(validResult);

			// Act
			ActionResult<List<ClassViewDto>> actionResult = await _controller.Index();

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
			Assert.Equal(validResult, okResult.Value);
		}
	}
}

