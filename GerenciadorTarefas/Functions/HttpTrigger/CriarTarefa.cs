using FunctionsApp.Models;
using FunctionsApp.Models.CRUD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace FunctionsApp.Functions
{
    public static class CriarTarefa
    {
        /// <summary>
        /// Recebe uma tarefa por parâmetro e insere na fila de criação de tarefas
        /// </summary>
        [FunctionName("CriarTarefa")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "tarefa")] HttpRequest req,
            [Queue("tarefas", Connection = "AzureWebJobsStorage")] IAsyncCollector<CriarTarefaFila> tarefasQueue,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<CriarTarefaModel>(requestBody);

            await tarefasQueue.AddAsync(new CriarTarefaFila
            {
                Descricao = input.Descricao
            });

            return new OkResult();
        }
    }
}
