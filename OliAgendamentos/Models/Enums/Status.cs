using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OliAgendamentos.Models.Enum
{
    public enum Status
    {
        Pendente,

        [Display(Name = "Em Progresso")]
        EmProgresso,


        Concluída,


        Cancelada,
    }
}
