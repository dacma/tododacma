using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using tododacma.common.Models;
using tododacma.Functions.Entities;
using tododacma.Functions.Functions;
using tododacma.Test.Helpers;
using Xunit;

namespace tododacma.Test.Tests
{
    public class TodoApiTest
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public async void CreateTodo_Should_Return_200()
        {
            // Arrenge
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo todoRequest = TestFactory.GetTodoRequest();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(todoRequest);

            // Act
            IActionResult response = await TodoApi.CreateTodo(request, mockTodos, logger);

            // Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public async void UpdateTodo_Should_Return_200()
        {
            // Arrenge
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo todoRequest = TestFactory.GetTodoRequest();
            Guid todoId = Guid.NewGuid();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(todoId, todoRequest);

            // Act
            IActionResult response = await TodoApi.UpdateTodo(request, mockTodos, todoId.ToString(), logger);

            // Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }


        [Fact]
        public void GetInOutEmployeeById_Should_Return_200()
        {
            //Arrange
            //MockCloudTableInOutEmployees mockCloudTableInOutEmployees = new MockCloudTableInOutEmployees(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            TodoEntity todoEntity = TestFactory.GetTodoEntity();
            Todo todoRequest = TestFactory.GetTodoRequest();
 
            Guid inOutEmployeeEntityId = Guid.NewGuid();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(inOutEmployeeEntityId, todoRequest);

            //Act
            IActionResult response = TodoApi.GetTodoById(request, todoEntity, inOutEmployeeEntityId.ToString(), logger);

            //Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }


    }
}

