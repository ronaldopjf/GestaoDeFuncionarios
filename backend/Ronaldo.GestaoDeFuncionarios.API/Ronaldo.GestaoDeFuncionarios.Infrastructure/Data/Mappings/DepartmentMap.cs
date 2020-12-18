using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Entities;

namespace Ronaldo.GestaoDeFuncionarios.Infrastructure.Data.Mappings
{
    public class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("TB_DEPARTAMENTO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_DEPARTAMENTO");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("NM_DEPARTAMENTO");

            builder.Property(x => x.Active)
                .HasDefaultValue(true)
                .HasColumnName("FL_ATIVO");

            builder.HasMany(o => o.Employees)
                .WithOne(c => c.Department)
                .HasForeignKey(c => c.IdDepartment);
        }
    }
}
