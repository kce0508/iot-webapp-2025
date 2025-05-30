using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DbFirstWebApp.Models;

public partial class SmarthomeContext : DbContext
{
    public SmarthomeContext()
    {
    }

    public SmarthomeContext(DbContextOptions<SmarthomeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fakedata> Fakedatas { get; set; }

    public virtual DbSet<Sensingdata> Sensingdatas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=smarthome;Uid=root;Pwd=12345;Charset=utf8;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fakedata>(entity =>
        {
            entity.HasKey(e => new { e.SensingDt, e.PubId }).HasName("PRIMARY");

            entity.ToTable("fakedatas");

            entity.Property(e => e.SensingDt)
                .HasColumnType("datetime")
                .HasColumnName("sensing_dt");
            entity.Property(e => e.PubId)
                .HasMaxLength(10)
                .HasColumnName("pub_id");
            entity.Property(e => e.Count)
                .HasPrecision(10)
                .HasColumnName("count");
            entity.Property(e => e.Human)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("human");
            entity.Property(e => e.Humid)
                .HasPrecision(5, 1)
                .HasColumnName("humid");
            entity.Property(e => e.Light)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("light");
            entity.Property(e => e.Temp)
                .HasPrecision(5, 1)
                .HasColumnName("temp");
        });

        modelBuilder.Entity<Sensingdata>(entity =>
        {
            entity.HasKey(e => e.Idx).HasName("PRIMARY");

            entity.ToTable("sensingdatas");

            entity.Property(e => e.Idx).HasColumnName("idx");
            entity.Property(e => e.ChaimBell)
                .HasMaxLength(3)
                .HasColumnName("chaim_bell");
            entity.Property(e => e.Fan)
                .HasMaxLength(3)
                .HasColumnName("fan");
            entity.Property(e => e.Humid).HasColumnName("humid");
            entity.Property(e => e.Light).HasColumnName("light");
            entity.Property(e => e.Rain).HasColumnName("rain");
            entity.Property(e => e.RealLight)
                .HasMaxLength(3)
                .HasColumnName("real_light");
            entity.Property(e => e.SensingDt)
                .HasColumnType("datetime")
                .HasColumnName("sensing_dt");
            entity.Property(e => e.Temp).HasColumnName("temp");
            entity.Property(e => e.Vul)
                .HasMaxLength(3)
                .HasColumnName("vul");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
