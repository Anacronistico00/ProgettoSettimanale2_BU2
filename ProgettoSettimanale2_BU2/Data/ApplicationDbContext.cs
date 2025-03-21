using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgettoSettimanale2_BU2.Models;
using System.Reflection.Emit;

namespace ProgettoSettimanale2_BU2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Camera> Camere { get; set; }
        public DbSet<Prenotazione> Prenotazioni { get; set; }
        public DbSet<Stato> Stati { get; set; }
        public DbSet<Tipo> TipiCamere { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ApplicationUserRole>().Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()").IsRequired(true);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(p => p.User).WithMany(p => p.ApplicationUserRoles).HasForeignKey(p => p.UserId).IsRequired(true);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(p => p.Role).WithMany(p => p.ApplicationUserRoles).HasForeignKey(p => p.RoleId).IsRequired(true);

            modelBuilder.Entity<Prenotazione>().Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()").IsRequired(true);
            modelBuilder.Entity<Prenotazione>().HasOne(p => p.Camera).WithMany(c => c.Prenotazioni).HasForeignKey(p => p.CameraId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cliente>().HasOne(p => p.User).WithMany(u => u.Clienti).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Cliente>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<Camera>().Property(c => c.Prezzo).HasColumnType("DECIMAL(10, 2)");
            modelBuilder.Entity<Camera>().HasOne(c => c.Tipo).WithMany(t => t.Camere).HasForeignKey(c => c.TipoId).OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Stato>().HasData(

                new Stato { StatoId = 1, Nome = "Prenotato" },
                new Stato { StatoId = 2, Nome = "Confermato" },
                new Stato { StatoId = 3, Nome = "Pagato" },
                new Stato { StatoId = 4, Nome = "Annullato" }
            );

            modelBuilder.Entity<Tipo>().HasData(
                new Tipo { Id = 1, Nome = "Singola" },
                new Tipo { Id = 2, Nome = "Doppia" },
                new Tipo { Id = 3, Nome = "Tripla" },
                new Tipo { Id = 4, Nome = "Quadrupla" },
                new Tipo { Id = 5, Nome = "Suite" }
            );

            modelBuilder.Entity<ApplicationRole>().HasData(

                new ApplicationRole { Id = "69e20207-7646-4b2e-a919-388c04fff968", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "69e20207-7646-4b2e-a919-388c04fff968" },
                new ApplicationRole { Id = "5fecb2ea-5a75-422f-a183-5b59bc6bfb8e", Name = "Responsabile", NormalizedName = "RESPONSABILE", ConcurrencyStamp = "5fecb2ea-5a75-422f-a183-5b59bc6bfb8e" },
                new ApplicationRole { Id = "73ec3006-1868-4363-aedb-f2b4077000a7", Name = "Dipendente", NormalizedName = "DIPENDENTE", ConcurrencyStamp = "73ec3006-1868-4363-aedb-f2b4077000a7" }
            );

            modelBuilder.Entity<Camera>().HasData(
                new Camera { CameraId = Guid.NewGuid(), Numero = 101, TipoId = 1, Prezzo = 80.00m },
                new Camera { CameraId = Guid.NewGuid(), Numero = 102, TipoId = 2, Prezzo = 120.00m },
                new Camera { CameraId = Guid.NewGuid(), Numero = 103, TipoId = 3, Prezzo = 150.00m },
                new Camera { CameraId = Guid.NewGuid(), Numero = 104, TipoId = 4, Prezzo = 180.00m },
                new Camera { CameraId = Guid.NewGuid(), Numero = 110, TipoId = 5, Prezzo = 250.00m },
                new Camera { CameraId = Guid.NewGuid(), Numero = 201, TipoId = 1, Prezzo = 85.00m },
                new Camera { CameraId = Guid.NewGuid(), Numero = 202, TipoId = 2, Prezzo = 130.00m },
                new Camera { CameraId = Guid.NewGuid(), Numero = 203, TipoId = 3, Prezzo = 160.00m },
                new Camera { CameraId = Guid.NewGuid(), Numero = 204, TipoId = 4, Prezzo = 200.00m },
                new Camera { CameraId = Guid.NewGuid(), Numero = 210, TipoId = 5, Prezzo = 270.00m }
            );
        }
    }
}
