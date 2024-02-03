using Microsoft.EntityFrameworkCore;
using FilmesApi.Models;

namespace FilmesApi.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> options)
        : base(options)
    {
        
    }
    //propriedade de acesso aos dados do banco de dados
    public DbSet<Filme> Filme { get; set; }
}
