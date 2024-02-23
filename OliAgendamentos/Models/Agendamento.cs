using OliAgendamentos.Models.Enums;

namespace OliAgendamentos.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int TarefaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public Prioridade Prioridade { get; set; }
    }
}
