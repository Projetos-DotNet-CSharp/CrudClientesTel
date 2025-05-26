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
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(t => t.ClienteId);
            builder.Property(p => p.NomeFantasia).HasMaxLength(100).IsRequired();
            builder.Property(p => p.RazaoSocial).HasMaxLength(100).IsRequired();
            builder.Property(p => p.TipoPessoa).HasMaxLength(1).IsRequired();
            builder.Property(p => p.Documento).HasMaxLength(14).IsRequired();
            builder.Property(p => p.Endereco).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Complemento).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Bairro).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Cidade).HasMaxLength(100).IsRequired();
            builder.Property(p => p.CEP).HasMaxLength(8).IsRequired();
            builder.Property(p => p.UF).HasMaxLength(2).IsRequired();
            builder.Property(p => p.DataInsercao).HasDefaultValue(DateTime.Now);
            builder.Property(p => p.UsuarioId).IsRequired();

            builder.HasMany(c => c.Telefones)
                   .WithOne(t => t.Cliente)
                   .HasForeignKey(t => t.ClienteId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Clientes");
        }
    }
}
