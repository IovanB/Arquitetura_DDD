using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(p => p.Id); /*have primaria*/
            builder.HasIndex(p => p.Email)
                .IsUnique();  /* sera unico na plataforma*/
            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(60);
            builder.Property(e => e.Email)
                .HasMaxLength(100);
        }
    }
}
