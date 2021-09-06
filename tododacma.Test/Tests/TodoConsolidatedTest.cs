using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using tododacma.common.Models;
using tododacma.Functions.Functions;
using tododacma.Test.Helpers;
using Xunit;

namespace tododacma.Test.Tests
{
    public class TodoConsolidatedTest
    {
        private readonly ILogger logger = TestsFactoryConsolidated.CreateLogger();

        [Fact]
        public async void CreateConsolidated_Should_Return_200()
        {
            // Arrenge
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Consolidated todoRequest = TestsFactoryConsolidated.GetConsolidatedRequest();
            DefaultHttpRequest request = TestsFactoryConsolidated.CreateHttpRequest(todoRequest);

            // Act
            IActionResult response = await ConsolidatedRegister.CreateConsolidated(request, mockTodos, logger);

            // Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        /*
         [Fact]
         public async void UpdateConsolidated_Should_Return_200()
         {
             // Arrenge
             MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
             Consolidated todoRequest = TestsFactoryConsolidated.GetConsolidatedRequest();
             Guid todoId = Guid.NewGuid();
             DefaultHttpRequest request = TestsFactoryConsolidated.CreateHttpRequest(todoId, todoRequest);

             // Act
             IActionResult response = await ConsolidatedRegister.UpdateConsolidated(request, mockTodos, todoId.ToString(), logger);

             // Assert
             OkObjectResult result = (OkObjectResult)response;
             Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
         }


        [Fact]
        public void GetTodoById_Should_Return_200()
        {
            //Arrange
            //MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            TodoEntity todoEntity = TestFactory.GetTodoEntity();
            Todo todoRequest = TestFactory.GetTodoRequest();

            Guid todoId = Guid.NewGuid();
            DefaultHttpRequest request = TestFactory.CreateHttpRequest(todoId, todoRequest);

            //Act
            IActionResult response = TodoApi.GetTodoById(request, todoEntity, todoId.ToString(), logger);

            //Assert
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        */

    }
}
