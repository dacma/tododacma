using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage.Table;
using tododacma.Functions.Entities;
using tododacma.common.Responses;
using tododacma.common.Models;

namespace tododacma.Functions.Functions
{
    public static class ConsolidatedRegister
    {

        [FunctionName(nameof(CreateConsolidated))]
        public static async Task<IActionResult> CreateConsolidated(
             [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "consolidated")] HttpRequest req,
             [Table("consolidated", Connection = "AzureWebJobsStorage")] CloudTable consolidatedTable,
             ILogger log)
        {
            log.LogInformation("Recieved a new consolidated.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            TodoConsolidated employee = JsonConvert.DeserializeObject<TodoConsolidated>(requestBody);



            if (employee.Id == null)
            {
                return new BadRequestObjectResult(new Response
                {
                    IsSuccess = false,
                    Message = "invalid employee ID."
                });
            }


            if (employee.Id <= 0)
            {
                return new BadRequestObjectResult(new Response
                {
                    IsSuccess = false,
                    Message = "invalid employee ID."
                });
            }



            if (employee.CurrentDate == null)
            {
                return new BadRequestObjectResult(new Response
                {
                    IsSuccess = false,
                    Message = "The request must be have a valid Date."
                });
            }



            if (employee.Minutes == null)
            {
                return new BadRequestObjectResult(new Response
                {
                    IsSuccess = false,
                    Message = "invalid employee ID."
                });
            }


            if (employee.Minutes <= 0)
            {
                return new BadRequestObjectResult(new Response
                {
                    IsSuccess = false,
                    Message = "invalid employee ID."
                });
            }



            TodoConsolidated todoConsolidated = new TodoConsolidated
            {
                Id = 123,
                CurrentDate = DateTime.UtcNow,
                Minutes = 0,
                PartitionKey = "TODO",
                ETag = "*",
                RowKey = Guid.NewGuid().ToString(),
            };

            TableOperation addOperation = TableOperation.Insert(todoConsolidated);
            await consolidatedTable.ExecuteAsync(addOperation);

            string message = "New todo stored in table";
            log.LogInformation(message);

            return new OkObjectResult(new Response
            {
                IsSuccess = true,
                Message = message,
                Result = todoConsolidated
            });
        }


        [FunctionName(nameof(GetAllConsolidated))]
        public static async Task<IActionResult> GetAllConsolidated(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "consolidated")] HttpRequest req,
           [Table("consolidated", Connection = "AzureWebJobsStorage")] CloudTable consolidatedTable,
           ILogger log)
        {
            log.LogInformation("Get all todos received.");

            TableQuery<TodoConsolidated> query = new TableQuery<TodoConsolidated>();
            TableQuerySegment<TodoConsolidated> consolidateds = await consolidatedTable.ExecuteQuerySegmentedAsync(query, null);

            string message = "Retrieved all todos.";
            log.LogInformation(message);

            return new OkObjectResult(new Response
            {
                IsSuccess = true,
                Message = message,
                Result = consolidateds
            });
        }


        [FunctionName(nameof(GetTodoByIdConsol))]
        public static IActionResult GetTodoByIdConsol(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "consolidated/{id}")] HttpRequest req,
            [Table("consolidated", "TODO", "{id}", Connection = "AzureWebJobsStorage")] TodoConsolidated consolidatedEntity,
            string id,
            ILogger log)
        {
            log.LogInformation($"Get todo by id: {id}, received.");

            if (consolidatedEntity == null)
            {
                return new BadRequestObjectResult(new Response
                {
                    IsSuccess = false,
                    Message = "Todo not found."
                });
            }

            string message = $"Todo: {id}, retrieved.";
            log.LogInformation(message);

            return new OkObjectResult(new Response
            {
                IsSuccess = true,
                Message = message,
                Result = consolidatedEntity
            });
        }





    }
}
