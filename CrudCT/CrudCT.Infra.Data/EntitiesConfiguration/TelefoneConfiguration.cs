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
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(t => t.TelefoneId);
            builder.Property(p => p.NumeroTelefone).HasMaxLength(15).IsRequired();
            builder.Property(p => p.Operadora).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Ativo).IsRequired();
            builder.Property(p => p.DataInsercao).HasDefaultValue(DateTime.Now);
            builder.Property(p => p.UsuarioId).IsRequired();
            builder.Property(p => p.ClienteId).IsRequired();
            builder.HasOne(t => t.TipoTelefone)
                .WithMany()
                .HasForeignKey(t => t.TipoTelefoneId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("Telefones");
        }
    }
}
