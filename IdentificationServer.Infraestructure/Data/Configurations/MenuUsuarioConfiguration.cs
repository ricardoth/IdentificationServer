using IdentificationServer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentificationServer.Infraestructure.Data.Configurations
{
    public class MenuUsuarioConfiguration : IEntityTypeConfiguration<MenuUsuario>
    {
        public void Configure(EntityTypeBuilder<MenuUsuario> entity)
        {
            entity.HasKey(e => e.IdMenuUsuario);

            entity.ToTable("MenuUsuario");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdMenuNavigation)
                .WithMany(p => p.MenuUsuarios)
                .HasForeignKey(d => d.IdMenu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MenuUsuario_Menu");

            entity.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.MenuUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MenuUsuario_Usuario");
        }
    }
}
