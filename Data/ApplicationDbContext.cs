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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<AnotacaoModel>()
        .HasOne(a => a.Livro)
        .WithMany(l => l.Anotacoes)
        .HasForeignKey(a => a.IdLivro);


}
}
