﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ronaldo.GestaoDeFuncionarios.Infrastructure.Data;

namespace Ronaldo.GestaoDeFuncionarios.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200917183758_EmployeeMap Changed thre")]
    partial class EmployeeMapChangedthre
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_DEPARTAMENTO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FL_ATIVO")
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NM_DEPARTAMENTO")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("TB_DEPARTAMENTO");
                });

            modelBuilder.Entity("Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_FUNCIONARIO")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Access")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FL_ACESSO")
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FL_ATIVO")
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnName("DT_NASCIMENTO")
                        .HasColumnType("datetime2")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("DS_EMAIL")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("IdDepartment")
                        .HasColumnName("ID_DEPARTAMENTO")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnName("DS_LOGIN")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NM_FUNCIONARIO")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .HasColumnName("DS_SENHA")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PrimaryPhone")
                        .HasColumnName("DS_TELEFONEPRIMARIO")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SecondaryPhone")
                        .HasColumnName("DS_TELEFONESECUNDARIO")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("IdDepartment");

                    b.ToTable("TB_FUNCIONARIO");
                });

            modelBuilder.Entity("Ronaldo.GestaoDeFuncionarios.Core.Aggregates.EmployeeAggregate.Entities.Employee", b =>
                {
                    b.HasOne("Ronaldo.GestaoDeFuncionarios.Core.Aggregates.DepartmentAggregate.Entities.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("IdDepartment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
