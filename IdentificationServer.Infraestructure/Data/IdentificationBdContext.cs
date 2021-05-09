using System;
using System.Reflection;
using IdentificationServer.Core.Entities;
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
        public virtual DbSet<MenuPerfil> MenuPerfils { get; set; }
        public virtual DbSet<Perfil> Perfils { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioPerfil> UsuarioPerfils { get; set; }
        public virtual DbSet<Autentication> Autentications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
   
    }
}
