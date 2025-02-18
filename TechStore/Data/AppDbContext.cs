using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechStore.Models;

namespace TechStore.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<ProdutoFoto> ProdutoFoto { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region [ Definição dos Nomes do Entity ]
        builder.Entity<Usuario>().ToTable("usuario");
        builder.Entity<IdentityRole>().ToTable("perfil");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("perfil_regra");
        builder.Entity<IdentityUserRole<string>>().ToTable("usuario_perfil");
        builder.Entity<IdentityUserClaim<string>>().ToTable("usuario_regra");
        builder.Entity<IdentityUserToken<string>>().ToTable("usuario_token");
        builder.Entity<IdentityUserLogin<string>>().ToTable("usuario_login");
        builder.Entity<Categoria>().ToTable("categoria");
        builder.Entity<Produto>().ToTable("Produto");
        builder.Entity<ProdutoFoto>().ToTable("ProdutoFoto");
        #endregion

        #region [ Popular Categorias ]
        List<Categoria> categorias = new() {
            new() {
                Id = 1,
                Nome = "Jogos"
            },
            new() {
                Id = 2,
                Nome = "Periféricos"
            },
            new() {
                Id = 3,
                Nome = "Consoles"
            },
            new() {
                Id = 4,
                Nome = "Computadores"
            },
            new() {
                Id = 5,
                Nome = "Gift Cards"
            }
        };
        builder.Entity<Categoria>().HasData(categorias);
        #endregion

        #region [ Popular Perfil ]
        List<IdentityRole> perfis = new() {
            new() {
                Id = Guid.NewGuid().ToString(),
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR",
            },
            new() {
                Id = Guid.NewGuid().ToString(),
                Name = "Funcionario",
                NormalizedName = "FUNCIONARIO",
            },
            new() {
                Id = Guid.NewGuid().ToString(),
                Name = "Cliente",
                NormalizedName = "CLIENTE",
            },
        };
        builder.Entity<IdentityRole>().HasData(perfis);
        #endregion

        #region [Popular Usuario ]
        Usuario usuario = new()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "HenryFelipe",
            NormalizedUserName = "HENRYFELIPE",
            Email = "zoiohenry5@gmail.com",
            NormalizedEmail = "ZOIOHENRY5@GMAIL.COM",
            EmailConfirmed = true,
            Nome = "Henry Felipe Bense de Oliveira",
            DataNascimento = DateTime.Parse("15/03/2005"),
            LockoutEnabled = true
        };
        PasswordHasher<Usuario> password = new();
        password.HashPassword(usuario, "123456");
        builder.Entity<Usuario>().HasData(usuario);
        #endregion

        #region [ Popular Usuario Perfil ]
        List<IdentityUserRole<string>> userRoles = new () {
            new() {
                UserId = usuario.Id,
                RoleId = perfis[0].Id
            },
            new() {
                UserId = usuario.Id,
                RoleId = perfis[1].Id
            },
            new() {
                UserId = usuario.Id,
                RoleId = perfis[2].Id
            },
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }

}