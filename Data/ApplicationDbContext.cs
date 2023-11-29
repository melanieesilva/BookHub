using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookHub.Models;
using System.Linq;

namespace BookHub.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<AnotacaoModel> Anotacoes { get; set; }
    public DbSet<LivroModel> Livros { get; set; }
}
