using FunctionsApp.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FunctionsApp.Functions.QueueTrigger
{
    public static class ProcessarTarefaCriada
    {
        /// <summary>
        /// Lê uma tarefa da fila e insere no serviço de tabelas (BD relacional)
        /// </summary>
        [FunctionName("ProcessarTarefaCriada")]
        public static async Task Run(
            [QueueTrigger("tarefas", Connection = "AzureWebJobsStorage")] CriarTarefaFila tarefa,
            [Table("tarefas", Connection = "AzureWebJobsStorage")] IAsyncCollector<TarefaTableEntity> tabelaTarefas,
            ILogger log)
        {
            await tabelaTarefas.AddAsync(new TarefaTableEntity
            {
                PartitionKey = "particao-1",
                RowKey = Guid.NewGuid().ToString("n"),
                Descricao = tarefa.Descricao,
                Finalizada = false
            });
        }
    }
}
