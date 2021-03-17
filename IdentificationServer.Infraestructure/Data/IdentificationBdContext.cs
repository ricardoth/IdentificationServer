using System;
using IdentificationServer.Core.Entities;
using IdentificationServer.Infraestructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IdentificationServer.Infraestructure.Data
{
    public partial class IdentificationBdContext : DbContext
    {
        public IdentificationBdContext()
        {
        }

        public IdentificationBdContext(DbContextOptions<IdentificationBdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<App> Apps { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuUsuario> MenuUsuarios { get; set; }
        public virtual DbSet<Perfil> Perfils { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioPerfil> UsuarioPerfils { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfiguration(new AppConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new MenuUsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new PerfilConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioPerfilConfiguration());
        }
    }
}
