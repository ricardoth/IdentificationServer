using IdentificationServer.Core.Entities;
using IdentificationServer.Core.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationServer.Infraestructure.Data.Configurations
{
    public class AutenticationConfiguration : IEntityTypeConfiguration<Autentication>
    {
        public void Configure(EntityTypeBuilder<Autentication> entity)
        {
            entity.ToTable("Autenticacion");

            entity.HasKey(e => e.Id); 

            entity.Property(e => e.Id)
                .HasColumnName("IdAutenticacion");


            entity.Property(e => e.User)
                .HasColumnName("Usuario")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.UserName)
                .HasColumnName("NombreUsuario")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Password)
                .HasColumnName("Contrasena")
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.Role)
               .HasColumnName("Rol")
               .IsRequired()
                .HasMaxLength(15)
                .HasConversion(
                x => x.ToString(),
                x => (RoleType)Enum.Parse(typeof(RoleType), x));

        }
    }
}
