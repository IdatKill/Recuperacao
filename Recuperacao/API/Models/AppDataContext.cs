using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class AppDataContext : DbContext
{
    public required DbSet<Aluno> Alunos { get; set; }
    public required DbSet<IMC> IMC { get; set; }

    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Getulio.db");
    }

}
