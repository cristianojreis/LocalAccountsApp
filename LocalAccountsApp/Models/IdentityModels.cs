using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;

namespace LocalAccountsApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            OnModelCreatingSegurancaIdentity(modelBuilder);

            OnModelCreatingGeral(modelBuilder);
        }

        private static void OnModelCreatingSegurancaIdentity(DbModelBuilder modelBuilder)
        {
            // Usuários - ApplicationUser do Identity
            modelBuilder.Entity<IdentityUser>()
                .ToTable("SegurancaUsuario")
                .Property(p => p.Id)
                .HasColumnName("UsuarioId");

            modelBuilder.Entity<IdentityUser>()
                .ToTable("SegurancaUsuario")
                .Property(p => p.EmailConfirmed)
                .HasColumnName("EmailConfirmado");

            modelBuilder.Entity<IdentityUser>()
                .ToTable("SegurancaUsuario")
                .Property(p => p.PasswordHash)
                .HasColumnName("SenhaCriptografada");

            modelBuilder.Entity<IdentityUser>()
                .ToTable("SegurancaUsuario")
                .Property(p => p.PhoneNumber)
                .HasColumnName("Telefone");

            modelBuilder.Entity<IdentityUser>()
                .ToTable("SegurancaUsuario")
                .Property(p => p.PhoneNumberConfirmed)
                .HasColumnName("TelefoneConfirmado");

            modelBuilder.Entity<IdentityUser>()
                .ToTable("SegurancaUsuario")
                .Property(p => p.UserName)
                .HasColumnName("Login");

            // Usuários - ApplicationUser do Identity
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("SegurancaUsuario")
                .Property(p => p.Id)
                .HasColumnName("UsuarioId");

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("SegurancaUsuario")
                .Property(p => p.EmailConfirmed)
                .HasColumnName("EmailConfirmado");

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("SegurancaUsuario")
                .Property(p => p.PasswordHash)
                .HasColumnName("SenhaCriptografada");

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("SegurancaUsuario")
                .Property(p => p.PhoneNumber)
                .HasColumnName("Telefone");

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("SegurancaUsuario")
                .Property(p => p.PhoneNumberConfirmed)
                .HasColumnName("TelefoneConfirmado");

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("SegurancaUsuario")
                .Property(p => p.UserName)
                .HasColumnName("Login");


            // Outras tabelas do Identity
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("SegurancaUsuarioPermissao");

            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("SegurancaLogin");

            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("SegurancaClaim");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("SegurancaPermissao");

            // 
        }

        private static void OnModelCreatingGeral(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Geral.Teste>()
                .ToTable("GeralTeste")
                .Property(p => p.TesteId)
                .HasColumnName("TesteId");

            modelBuilder.Entity<Geral.Teste>()
                .ToTable("GeralTeste")
                .Property(p => p.Titulo)
                .HasColumnName("Titulo");

        }

    }
}