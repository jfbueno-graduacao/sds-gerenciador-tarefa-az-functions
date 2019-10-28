using FunctionsApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace FunctionsApp.Functions.HttpTrigger
{
    public static class ConsultarTarefaPorId
    {
        /// <summary>
        /// Consulta uma tarefa do banco de dados
        /// </summary>
        [FunctionName("ConsultarTarefaPorId")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "tarefa/{id}")] HttpRequest req,
            [Table("tarefas", "particao-1", "{id}", Connection = "AzureWebJobsStorage")] TarefaTableEntity tarefa,
            ILogger log, string id)
        {
            log.LogInformation($"Consultando tarefa {id}");

            if (tarefa == null)
            {
                log.LogInformation($"Tarefa {id} nao encontrada.");
                return new NotFoundResult();
            }

            return new OkObjectResult(tarefa.ToTarefaDto());
        }
    }
}
