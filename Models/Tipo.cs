using System.ComponentModel.DataAnnotations;

namespace app_tarefas1.Models
{
    public class Tipo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public required string Nome { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public required string Descricao { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
    }
}
