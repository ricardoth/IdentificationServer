using IdentificationServer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentificationServer.Infraestructure.Data.Configurations
{
    public class MenuPerfilConfiguration : IEntityTypeConfiguration<MenuPerfil>
    {
        public void Configure(EntityTypeBuilder<MenuPerfil> entity)
        {
            entity.HasKey(e => e.IdMenuPerfil)
                    .HasName("PK_MenuUsuario");

            entity.ToTable("MenuPerfil");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdMenuNavigation)
                .WithMany(p => p.MenuPerfils)
                .HasForeignKey(d => d.IdMenu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MenuPerfil_Menu");

            entity.HasOne(d => d.IdPerfilNavigation)
                .WithMany(p => p.MenuPerfils)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MenuPerfil_Perfil");
        }
    }
}