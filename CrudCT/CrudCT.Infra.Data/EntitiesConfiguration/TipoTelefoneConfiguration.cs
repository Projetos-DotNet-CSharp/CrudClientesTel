using CrudCT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCT.Infra.Data.EntitiesConfiguration
{
    public class TipoTelefoneConfiguration : IEntityTypeConfiguration<TipoTelefone>
    {
        public void Configure(EntityTypeBuilder<TipoTelefone> builder)
        {
            builder.HasKey(t => t.TipoTelefoneId);
            builder.Property(p => p.DescricaoTipoTelefone)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(p => p.DataInsercao)
                .HasDefaultValue(DateTime.Now);
            builder.Property(p => p.UsuarioId)
                .IsRequired();
            builder.ToTable("TiposTelefones");

            builder.HasData(
              new TipoTelefone(1, "RESIDENCIAL"),
              new TipoTelefone(2, "COMERCIAL"),
              new TipoTelefone(3, "WHATSAPP")
             );
        }
    }
}
