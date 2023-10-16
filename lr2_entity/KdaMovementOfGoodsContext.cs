using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace lr2_entity;

public partial class KdaMovementOfGoodsContext : DbContext
{
    public KdaMovementOfGoodsContext()
    {
    }

    public KdaMovementOfGoodsContext(DbContextOptions<KdaMovementOfGoodsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Клиент> Клиентs { get; set; }

    public virtual DbSet<Сделка> Сделкаs { get; set; }

    public virtual DbSet<Товар> Товарs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=KOMPKARPENYCHA; Database=KDA_movement_of_goods; Trusted_Connection=True; Encrypt=False; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Клиент>(entity =>
        {
            entity.HasKey(e => e.КодКлиента).HasName("PK__Клиент__FFB6CA69CEA7A2B7");

            entity.ToTable("Клиент");

            entity.Property(e => e.Город)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Телефон)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Фамилия)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Фирма)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Сделка>(entity =>
        {
            entity.HasKey(e => e.КодСделки).HasName("PK__Сделка__A7FA78A678130015");

            entity.ToTable("Сделка");

            entity.Property(e => e.Дата)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.КодКлиентаNavigation).WithMany(p => p.Сделкаs)
                .HasForeignKey(d => d.КодКлиента)
                .HasConstraintName("fk_Клиент");

            entity.HasOne(d => d.КодТовараNavigation).WithMany(p => p.Сделкаs)
                .HasForeignKey(d => d.КодТовара)
                .HasConstraintName("fk_Товар");
        });

        modelBuilder.Entity<Товар>(entity =>
        {
            entity.HasKey(e => e.КодТовара).HasName("PK__Товар__02FE99B3D95FC56F");

            entity.ToTable("Товар");

            entity.HasIndex(e => e.Название, "UQ__Товар__38DA8035A5A8FA61").IsUnique();

            entity.Property(e => e.ГородПроизв)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Название)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.РасСчет)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Рас_счет");
            entity.Property(e => e.Сорт)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Тип)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ЦенаЗаЕд).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
