using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using OliAgendamentos.Models.Enum;

namespace OliAgendamentos.Models
{
    public class Tarefa
    {
        public int Id {  get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        [DisplayName("Data de Criação")]
        [DataType(DataType.Date)]
        public DateTime DataCriacao { get; set; }
        [DisplayName("Data do Fim")]
        [DataType(DataType.Date)]
        public DateTime? DataFim { get; set; }
        public Status Status { get; set; }
    }
}
