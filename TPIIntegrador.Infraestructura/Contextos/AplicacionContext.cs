using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TPIIntegrador.Dominio.Entidades;

namespace TPIIntegrador.Infraestructura.Contextos
{
    public partial class AplicacionContext : DbContext
    {
        public AplicacionContext()
        {
        }

        public AplicacionContext(DbContextOptions<AplicacionContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<Rol> Rols { get; set; } = null!;
        //public virtual DbSet<RolClaim> RolClaims { get; set; } = null!;
        public virtual DbSet<Subasta> Subastas { get; set; } = null!;
        //public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        //public virtual DbSet<UsuarioClaim> UsuarioClaims { get; set; } = null!;
        //public virtual DbSet<UsuarioLogin> UsuarioLogins { get; set; } = null!;
        //public virtual DbSet<UsuarioToken> UsuarioTokens { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Rol>(entity =>
            //{
            //    entity.ToTable("Rol");

            //    entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedName] IS NOT NULL)");

            //    entity.Property(e => e.NombreRol).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<RolClaim>(entity =>
            //{
            //    entity.HasIndex(e => e.RoleId, "IX_RolClaims_RoleId");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.RolClaims)
            //        .HasForeignKey(d => d.RoleId);
            //});

            modelBuilder.Entity<Subasta>(entity =>
            {
                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.Destino)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasMaxLength(450);

                entity.Property(e => e.Origen)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Subasta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subastas_Usuario");
            });

            //modelBuilder.Entity<Usuario>(entity =>
            //{
            //    entity.ToTable("Usuario");

            //    entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedUserName] IS NOT NULL)");

            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.NombreUsuario).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            //    entity.HasMany(d => d.Roles)
            //        .WithMany(p => p.Users)
            //        .UsingEntity<Dictionary<string, object>>(
            //            "UsuarioRole",
            //            l => l.HasOne<Rol>().WithMany().HasForeignKey("RoleId"),
            //            r => r.HasOne<Usuario>().WithMany().HasForeignKey("UserId"),
            //            j =>
            //            {
            //                j.HasKey("UserId", "RoleId");

            //                j.ToTable("UsuarioRoles");

            //                j.HasIndex(new[] { "RoleId" }, "IX_UsuarioRoles_RoleId");
            //            });
            //});

            //modelBuilder.Entity<UsuarioClaim>(entity =>
            //{
            //    entity.HasIndex(e => e.UserId, "IX_UsuarioClaims_UserId");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.UsuarioClaims)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<UsuarioLogin>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            //    entity.HasIndex(e => e.UserId, "IX_UsuarioLogins_UserId");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.UsuarioLogins)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<UsuarioToken>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.UsuarioTokens)
            //        .HasForeignKey(d => d.UserId);
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
