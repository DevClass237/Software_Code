using Microsoft.EntityFrameworkCore;
using PocheteAPI.Modelo;

namespace PocheteAPI.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Pochete> Pochetes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<DadosTemporarios> DadosTemporarios { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Chave primária de Professor
            modelBuilder.Entity<Professor>()
                .HasKey(p => p.Matricula);

            // Relacionamento Movimentacao -> Professor (1:N)
            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.Professor)
                .WithMany()
                .HasForeignKey(m => m.ProfessorMatricula)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento Movimentacao -> Pochete (1:N)
            modelBuilder.Entity<Movimentacao>()
                .HasOne(m => m.Pochete)
                .WithMany()
                .HasForeignKey(m => m.PocheteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento Pochete -> Sala (1:N)
            modelBuilder.Entity<Pochete>()
                .HasOne(p => p.Sala)
                .WithMany()
                .HasForeignKey(p => p.SalaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Curso -> Professor (1:1)
            modelBuilder.Entity<Curso>()
                .HasOne(c => c.Professor)
                .WithOne()  // se for 1:1; se for 1:N, use .WithMany()
                .HasForeignKey<Curso>(c => c.ProfessorMatricula);

            // Curso -> Turma (1:1 ou 1:N)
            modelBuilder.Entity<Curso>()
                .HasOne(c => c.Turma)
                .WithOne()  // ou .WithMany() se turma puder ter vários cursos
                .HasForeignKey<Curso>(c => c.TurmaId);
        }
    }
}