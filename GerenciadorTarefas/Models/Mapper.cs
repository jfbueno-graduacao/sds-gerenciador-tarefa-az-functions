namespace FunctionsApp.Models
{
    public static class Mapper
    {
        public static TarefaDto ToTarefaDto(this TarefaTableEntity tarefaEntity)
            => new TarefaDto
            {
                Id = tarefaEntity.RowKey,
                Descricao = tarefaEntity.Descricao,
                Finalizada = tarefaEntity.Finalizada
            };
    }
}
