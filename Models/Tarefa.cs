using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_tarefas1.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "O campo Título é obrigatório")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Titulo { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public required string Nome { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public required string Descricao { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public DateTime? DataConclusao { get; set; }

        public bool Concluida { get; set; }

        [ForeignKey("Tipo")]
        public int TipoId { get; set; }
        public required Tipo Tipo { get; set; }
    }
}
