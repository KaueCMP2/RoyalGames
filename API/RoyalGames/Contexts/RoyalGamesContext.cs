using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RoyalGames.Domains;

namespace RoyalGames.Contexts;

public partial class RoyalGamesContext : DbContext
{
    public RoyalGamesContext()
    {
    }

    public RoyalGamesContext(DbContextOptions<RoyalGamesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClassificacaoIndicativa> ClassificacaoIndicativa { get; set; }

    public virtual DbSet<Genero> Genero { get; set; }

    public virtual DbSet<Jogo> Jogo { get; set; }

    public virtual DbSet<JogoPromocao> JogoPromocao { get; set; }

    public virtual DbSet<Log_AlteracaoJogo> Log_AlteracaoJogo { get; set; }

    public virtual DbSet<Plataforma> Plataforma { get; set; }

    public virtual DbSet<Promocao> Promocao { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=RoyalGames;Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClassificacaoIndicativa>(entity =>
        {
            entity.HasKey(e => e.ClassificacaoId).HasName("PK__Classifi__D1D088CEA9413CC7");

            entity.Property(e => e.ClassificacaoNome)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.GeneroId).HasName("PK__Genero__A99D02483A9ADB3E");

            entity.HasIndex(e => e.Nome, "UQ__Genero__7D8FE3B232741EC6").IsUnique();

            entity.Property(e => e.Nome)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Jogo>(entity =>
        {
            entity.HasKey(e => e.JogoId).HasName("PK__Jogo__591968356CB7EBA5");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("tgr_JogoAlteracao");
                    tb.HasTrigger("tgr_Jogo_StatusJogo");
                });

            entity.HasIndex(e => e.Nome, "UQ__Jogo__7D8FE3B2B7F6646A").IsUnique();

            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.StatusJogo).HasDefaultValue(true);
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Classificacao).WithMany(p => p.Jogo)
                .HasForeignKey(d => d.ClassificacaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Jogo_ClassificacaoId");

            entity.HasMany(d => d.Genero).WithMany(p => p.Jogo)
                .UsingEntity<Dictionary<string, object>>(
                    "JogoGenero",
                    r => r.HasOne<Genero>().WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Jogo>().WithMany()
                        .HasForeignKey("JogoId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("JogoId", "GeneroId").HasName("PK_JogoGenero_JogoId_GeneroId");
                    });

            entity.HasMany(d => d.Plataforma).WithMany(p => p.Jogo)
                .UsingEntity<Dictionary<string, object>>(
                    "JogoPlataforma",
                    r => r.HasOne<Plataforma>().WithMany()
                        .HasForeignKey("PlataformaId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Jogo>().WithMany()
                        .HasForeignKey("JogoId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("JogoId", "PlataformaId").HasName("PK_JogoPlataforma_JogoId_PlataformaId");
                    });
        });

        modelBuilder.Entity<JogoPromocao>(entity =>
        {
            entity.HasKey(e => new { e.PromocaoId, e.JogoId }).HasName("PK_JogoPromocao_JogoId_PromocaoId");

            entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Jogo).WithMany(p => p.JogoPromocao)
                .HasForeignKey(d => d.JogoId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Promocao).WithMany(p => p.JogoPromocao)
                .HasForeignKey(d => d.PromocaoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Log_AlteracaoJogo>(entity =>
        {
            entity.HasKey(e => e.Log_AlteracaoJogoId).HasName("PK__Log_Alte__BB9D2C6F50735A26");

            entity.Property(e => e.DataAlteracao).HasColumnType("datetime");
            entity.Property(e => e.NomeAnterior).HasMaxLength(100);
            entity.Property(e => e.ValorAnterior).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Jogo).WithMany(p => p.Log_AlteracaoJogo)
                .HasForeignKey(d => d.JogoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Log_Alteracao_JogoId");
        });

        modelBuilder.Entity<Plataforma>(entity =>
        {
            entity.HasKey(e => e.PlataformaId).HasName("PK__Platafor__B83567ED83A2EC5C");

            entity.HasIndex(e => e.Nome, "UQ__Platafor__7D8FE3B2481FAB74").IsUnique();

            entity.Property(e => e.Nome)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Promocao>(entity =>
        {
            entity.HasKey(e => e.PromocaoId).HasName("PK__Promocao__254B581DD10D83EB");

            entity.Property(e => e.DataExpiracao).HasColumnType("datetime");
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.StatusPromocao).HasDefaultValue(true);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE7B8BB2B00C9");

            entity.ToTable(tb => tb.HasTrigger("tgr_Usuario_UsuarioStatus"));

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105345A335965").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Senha).HasMaxLength(32);
            entity.Property(e => e.StatusUsuario).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
