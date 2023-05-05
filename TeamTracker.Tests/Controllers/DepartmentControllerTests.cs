using Microsoft.AspNetCore.Mvc;
using Moq;
using TeamTracker.Controllers;
using TeamTracker.Data.Repositories;
using TeamTracker.Models;
using Xunit;

namespace TeamTracker.Tests.Controllers
{
    public class DepartmentControllerTests
    {
        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfDepartments()
        {
            // Arrange
            var mockRepo = new Mock<IDepartmentRepository>();
            mockRepo.Setup(repo => repo.GetDepartments())
                .Returns(TestData.GetDepartments());
            var controller = new DepartmentController(mockRepo.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Department>>(
                viewResult.ViewData.Model);
            Assert.Equal(TestData.GetDepartments().Count, model.Count);
        }

        [Fact]
        public void Create_ReturnsAViewResult()
        {
            // Arrange
            var controller = new DepartmentController(null);

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_ReturnsARedirectToIndex_WhenModelStateIsValid()
        {
            // Arrange
            var mockRepo = new Mock<IDepartmentRepository>();
            var controller = new DepartmentController(mockRepo.Object);
            var department = new Department
            {
                Name = "IT",
                Floor = 2
            };

            // Act
            var result = controller.Create(department);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepo.Verify(repo => repo.AddDepartment(department), Times.Once);
        }

        [Fact]
        public void Create_ReturnsAViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var controller = new DepartmentController(null);
            var department = new Department
            {
                Name = "",
                Floor = 2
            };
            controller.ModelState.AddModelError("Name", "Required");

            // Act
            var result = controller.Create(department);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<Department>(
                viewResult.ViewData.Model);
        }
        

        [Fact]
        public void Edit_ReturnsANotFoundResult_WhenDepartmentIsNull()
        {
            // Arrange
            var mockRepo = new Mock<IDepartmentRepository>();
            mockRepo.Setup(repo => repo.GetDepartmentById(1))
                .Returns((Department)null);
            var controller = new DepartmentController(mockRepo.Object);

            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Edit_ReturnsAViewResult_WithDepartment()
        {
            // Arrange
            var mockRepo = new Mock<IDepartmentRepository>();
            mockRepo.Setup(repo => repo.GetDepartmentById(1))
                .Returns(TestData.GetDepartments()[0]);
            var controller = new DepartmentController(mockRepo.Object);

            // Act
            var result = controller.Edit(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Department>(
                viewResult.ViewData.Model);
            Assert.Equal("HR", model.Name);
            Assert.Equal(1, model.Floor);
        }

        [Fact]
        public void Edit_ReturnsARedirectToIndex_WhenModelStateIsValid()
        {
            // Arrange
            var mockRepo = new Mock<IDepartmentRepository>();
            var controller = new DepartmentController(mockRepo.Object);
            var department = new Department
            {
                DepartmentID = 1,
                Name = "IT",
                Floor = 2
            };

            // Act
            var result = controller.Edit(1, department);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepo.Verify(repo => repo.UpdateDepartment(department), Times.Once);
        }

        [Fact]
        public void Edit_ReturnsAViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var controller = new DepartmentController(null);
            var department = new Department
            {
                Name = "",
                Floor = 2
            };
            controller.ModelState.AddModelError("Name", "Required");

            // Act
                       var result = controller.Edit(1, department);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<Department>(
                viewResult.ViewData.Model);
        }


        [Fact]
        public void Delete_ReturnsANotFoundResult_WhenDepartmentIsNull()
        {
            // Arrange
            var mockRepo = new Mock<IDepartmentRepository>();
            mockRepo.Setup(repo => repo.GetDepartmentById(1))
                .Returns((Department)null);
            var controller = new DepartmentController(mockRepo.Object);

            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_ReturnsAViewResult_WithDepartment()
        {
            // Arrange
            var mockRepo = new Mock<IDepartmentRepository>();
            mockRepo.Setup(repo => repo.GetDepartmentById(1))
                .Returns(TestData.GetDepartments()[0]);
            var controller = new DepartmentController(mockRepo.Object);

            // Act
            var result = controller.Delete(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Department>(
                viewResult.ViewData.Model);
            Assert.Equal("HR", model.Name);
            Assert.Equal(1, model.Floor);
        }

        [Fact]
        public void DeleteConfirmed_ReturnsARedirectToIndex()
        {
            // Arrange
            var mockRepo = new Mock<IDepartmentRepository>();
            var controller = new DepartmentController(mockRepo.Object);

            // Act
            var result = controller.DeleteConfirmed(1);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepo.Verify(repo => repo.DeleteDepartment(1), Times.Once);
        }
    }
}
