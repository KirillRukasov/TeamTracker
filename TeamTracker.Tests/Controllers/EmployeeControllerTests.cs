using Microsoft.AspNetCore.Mvc;
using Moq;
using TeamTracker.Controllers;
using TeamTracker.Data.Repositories;
using TeamTracker.Models;
using Xunit;

namespace TeamTracker.Tests.Controllers;

public class EmployeeControllerTests
{
    [Fact]
    public void Index_ReturnsAViewResult_WithAEmployeesList()
    {
        // Arrange
        var mockRepo = new Mock<IEmployeeRepository>();
        mockRepo.Setup(repo => repo.GetAllEmployees())
            .Returns(TestData.GetAllEmployees());
        var controller = new EmployeeController(mockRepo.Object, null, null);

        // Act
        var result = controller.Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<List<EmployeeViewModel>>(
            viewResult.ViewData.Model);
        Assert.Equal(TestData.GetAllEmployees().Count, model.Count);
    }
    
        [Fact]
    public void Create_ReturnsAViewResult_WithAViewModelContainingDepartmentsAndProgrammingLanguages()
    {
        // Arrange
        var mockDepartmentRepo = new Mock<IDepartmentRepository>();
        mockDepartmentRepo.Setup(repo => repo.GetDepartments())
            .Returns(TestData.GetDepartments());

        var mockLanguageRepo = new Mock<IProgrammingLanguageRepository>();
        mockLanguageRepo.Setup(repo => repo.GetProgrammingLanguages())
            .Returns(TestData.GetProgrammingLanguages());

        var controller = new EmployeeController(null, mockLanguageRepo.Object, mockDepartmentRepo.Object);

        // Act
        var result = controller.Create();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<EmployeeEditViewModel>(
            viewResult.ViewData.Model);
        Assert.NotNull(model.Departments);
        Assert.Equal(3, model.Departments.Count());
        Assert.NotNull(model.ProgrammingLanguages);
        Assert.Equal(2, model.ProgrammingLanguages.Count());
    }

    [Fact]
    public void Create_ReturnsARedirectToIndex_WhenModelStateIsValid()
    {
        // Arrange
        var mockRepo = new Mock<IEmployeeRepository>();
        var controller = new EmployeeController(mockRepo.Object, null, null);

        // Act
        var result = controller.Create(new Employee
        {
            Name = "John",
            Surname = "Doe",
            Age = 33,
            DepartmentID = 1,
            Gender = "M",
            ProgrammingLanguageID = 1
        });

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Null(redirectToActionResult.ControllerName);
        Assert.Equal("Index", redirectToActionResult.ActionName);
    }
}
