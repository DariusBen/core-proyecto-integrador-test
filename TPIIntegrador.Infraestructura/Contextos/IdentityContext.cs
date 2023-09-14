using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TPIIntegrador.Infraestructura.Contextos
{
    public class IdentityContext : IdentityDbContext<IdentityUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable(name: "Usuario");
                entity.Property(e => e.UserName).HasColumnName("NombreUsuario");
                entity.Property(e => e.PasswordHash).HasColumnName("Password");
                entity.Property(e => e.EmailConfirmed).HasColumnName("MailConfirmado");
                entity.Property(e => e.PhoneNumber).HasColumnName("Telefono");

                //Ignoramos estos campos de Identity porque no interesan en este momento
                entity.Ignore(e => e.AccessFailedCount);
                entity.Ignore(e => e.ConcurrencyStamp);
                entity.Ignore(e => e.LockoutEnabled);
                entity.Ignore(e => e.LockoutEnd);
                entity.Ignore(e => e.NormalizedEmail);
                entity.Ignore(e => e.PhoneNumberConfirmed);
                entity.Ignore(e => e.SecurityStamp);
                entity.Ignore(e => e.TwoFactorEnabled);
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Rol");
                entity.Property(e => e.Name).HasColumnName("NombreRol");
                entity.Ignore(e => e.ConcurrencyStamp);
            });

            builder.Entity<IdentityUserClaim<string>>().ToTable("UsuarioClaims");
            builder.Entity<IdentityUserRole<string>>().ToTable("UsuarioRoles");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UsuarioLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RolClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UsuarioTokens");

        }
    }
}