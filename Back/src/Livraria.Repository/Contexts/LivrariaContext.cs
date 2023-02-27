using Livraria.Model;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Repository.Contexts
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext(DbContextOptions<LivrariaContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<AutorLivro> AutoresLivros { get; set; }
        public DbSet<Editora> Editoras { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AutorLivro>()
                .HasKey(al => new { al.AutorId, al.LivroId });

            builder.Entity<Livro>()
                .HasOne(l => l.Editora)
                .WithMany(e => e.Livros)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
