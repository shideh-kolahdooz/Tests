using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace RandomScenarios
{
    public static class Greetings
    {
        [FunctionName("Greetings")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var greetingMessage = "Two things are infinite: the universe and human stupidity; and I'm not sure about the universe.";

            return greetingMessage != null
                ? (ActionResult)new OkObjectResult($"Hello, {greetingMessage}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
