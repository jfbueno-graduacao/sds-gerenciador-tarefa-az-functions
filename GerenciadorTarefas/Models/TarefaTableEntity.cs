using Microsoft.WindowsAzure.Storage.Table;

namespace FunctionsApp.Models
{
    public class TarefaTableEntity : TableEntity
    {
        public string Descricao { get; set; }
        public bool Finalizada { get; set; }
    }
}
