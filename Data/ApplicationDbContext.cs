using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace app_tarefas1.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<app_tarefas1.Models.Tipo> Tipo { get; set; }
    public DbSet<app_tarefas1.Models.Tarefa> Tarefa { get; set; }
}
