using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Entities;

namespace Ronaldo.GestaoDeFuncionarios.Infrastructure.Data.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("TB_FUNCIONARIO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_FUNCIONARIO");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("NM_FUNCIONARIO");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("DS_EMAIL");

            builder.Property(x => x.IdDepartment)
                .IsRequired()
                .HasColumnName("ID_DEPARTAMENTO");

            builder.Property(x => x.DateOfBirth)
                .HasMaxLength(50)
                .HasColumnName("DT_NASCIMENTO");

            builder.Property(x => x.PrimaryPhone)
                .HasMaxLength(50)
                .HasColumnName("DS_TELEFONEPRIMARIO");

            builder.Property(x => x.SecondaryPhone)
                .HasMaxLength(50)
                .HasColumnName("DS_TELEFONESECUNDARIO");

            builder.Property(x => x.Login)
                .HasMaxLength(50)
                .HasColumnName("DS_LOGIN");

            builder.Property(x => x.Password)
                .HasMaxLength(50)
                .HasColumnName("DS_SENHA");

            builder.Property(x => x.Access)
                .HasDefaultValue(false)
                .HasColumnName("FL_ACESSO");

            builder.Property(x => x.Active)
                .HasDefaultValue(false)
                .HasColumnName("FL_ATIVO");

            builder.HasOne(c => c.Department)
                .WithMany(o => o.Employees)
                .HasForeignKey(c => c.IdDepartment);
        }
    }
}
