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

namespace tododacma.Functions.Functions
{
    public static class ConsolidatedRegister
    {

        /*
        [FunctionName(nameof(GetConsolidated))]
        public static async Task<IActionResult> GetConsolidated(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "consolidated")] HttpRequest req,
           [Table("consolidated", Connection = "AzureWebJobsStorage")] CloudTable consolidatedTable,
           ILogger log)
        {
            log.LogInformation("Get all employee received.");

            TableQuery<TodoConsolidated> query = new TableQuery<TodoConsolidated>();
            TableQuerySegment<TodoConsolidated> consolidated = await consolidatedTable.ExecuteQuerySegmentedAsync(query, null);

            string message = "received all consolidated.";
            log.LogInformation(message);

            return new OkObjectResult(new Response
            {
                IsSuccess = true,
                Message = message,
                Result = consolidated
            });
        }

        [FunctionName(nameof(GetTodoByIdConsolidated))]
        public static IActionResult GetTodoByIdConsolidated(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "consolidated/{date}")] HttpRequest req,
            [Table("consolidated", "{date}", Connection = "AzureWebJobsStorage")] TodoEntity todoEntity,
            string date,
            ILogger log)
        {
            log.LogInformation($"Get todo by date: {date}, received.");

            if (todoEntity == null)
            {
                return new BadRequestObjectResult(new Response
                {
                    IsSuccess = false,
                    Message = "Employee not found."
                });
            }

            string message = $"Todo: {date}, retrieved.";
            log.LogInformation(message);

            return new OkObjectResult(new Response
            {
                IsSuccess = true,
                Message = message,
                Result = todoEntity
            });
        }

        */

    }
}
