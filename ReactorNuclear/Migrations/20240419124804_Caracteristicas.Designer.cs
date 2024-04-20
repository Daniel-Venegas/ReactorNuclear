﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactorNuclear.Context;

#nullable disable

namespace ReactorNuclear.Migrations
{
    [DbContext(typeof(REDbContext))]
    [Migration("20240419124804_Caracteristicas")]
    partial class Caracteristicas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReactorNuclear.Model.CaracteristicasI", b =>
                {
                    b.Property<int>("IdCaracteristicas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCaracteristicas"));

                    b.Property<string>("CaracteristicasRequired")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCaracteristicas");

                    b.ToTable("Caract");
                });

            modelBuilder.Entity("ReactorNuclear.Model.DetalleDispositivo", b =>
                {
                    b.Property<int>("IdDetalleDispositivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleDispositivo"));

                    b.Property<string>("Caracteristicas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CaracteristicasIIdCaracteristicas")
                        .HasColumnType("int");

                    b.Property<int>("IdCaracteristicas")
                        .HasColumnType("int");

                    b.Property<int>("IdDispositivo")
                        .HasColumnType("int");

                    b.HasKey("IdDetalleDispositivo");

                    b.HasIndex("CaracteristicasIIdCaracteristicas");

                    b.ToTable("DetalleD");
                });

            modelBuilder.Entity("ReactorNuclear.Model.Dispositivo", b =>
                {
                    b.Property<int>("IdDispositivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDispositivo"));

                    b.Property<int?>("DetalleDispositivoIdDetalleDispositivo")
                        .HasColumnType("int");

                    b.Property<string>("Dispo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDispositivo");

                    b.HasIndex("DetalleDispositivoIdDetalleDispositivo");

                    b.ToTable("Dispositivo");
                });

            modelBuilder.Entity("ReactorNuclear.Model.MonitoreoXDispo", b =>
                {
                    b.Property<int>("IdVariableXDispositivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVariableXDispositivo"));

                    b.Property<int?>("DispositivoIdDispositivo")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDispositivo")
                        .HasColumnType("int");

                    b.Property<int>("IdVariableMonitoreo")
                        .HasColumnType("int");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.Property<int?>("VariableMonitoreoIdVariableMonitoreo")
                        .HasColumnType("int");

                    b.HasKey("IdVariableXDispositivo");

                    b.HasIndex("DispositivoIdDispositivo");

                    b.HasIndex("VariableMonitoreoIdVariableMonitoreo");

                    b.ToTable("monitoreoXDispos");
                });

            modelBuilder.Entity("ReactorNuclear.Model.TipoVariable", b =>
                {
                    b.Property<int>("IdTipoVariable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoVariable"));

                    b.Property<string>("Variable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoVariable");

                    b.ToTable("TipoV");
                });

            modelBuilder.Entity("ReactorNuclear.Model.VariableMonitoreo", b =>
                {
                    b.Property<int>("IdVariableMonitoreo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVariableMonitoreo"));

                    b.Property<int>("IdTipoVariable")
                        .HasColumnType("int");

                    b.Property<int?>("TipoVariableIdTipoVariable")
                        .HasColumnType("int");

                    b.Property<string>("VarMonitoreo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdVariableMonitoreo");

                    b.HasIndex("TipoVariableIdTipoVariable");

                    b.ToTable("VarMo");
                });

            modelBuilder.Entity("ReactorNuclear.Model.DetalleDispositivo", b =>
                {
                    b.HasOne("ReactorNuclear.Model.CaracteristicasI", "CaracteristicasI")
                        .WithMany()
                        .HasForeignKey("CaracteristicasIIdCaracteristicas");

                    b.Navigation("CaracteristicasI");
                });

            modelBuilder.Entity("ReactorNuclear.Model.Dispositivo", b =>
                {
                    b.HasOne("ReactorNuclear.Model.DetalleDispositivo", "DetalleDispositivo")
                        .WithMany()
                        .HasForeignKey("DetalleDispositivoIdDetalleDispositivo");

                    b.Navigation("DetalleDispositivo");
                });

            modelBuilder.Entity("ReactorNuclear.Model.MonitoreoXDispo", b =>
                {
                    b.HasOne("ReactorNuclear.Model.Dispositivo", "Dispositivo")
                        .WithMany()
                        .HasForeignKey("DispositivoIdDispositivo");

                    b.HasOne("ReactorNuclear.Model.VariableMonitoreo", "VariableMonitoreo")
                        .WithMany()
                        .HasForeignKey("VariableMonitoreoIdVariableMonitoreo");

                    b.Navigation("Dispositivo");

                    b.Navigation("VariableMonitoreo");
                });

            modelBuilder.Entity("ReactorNuclear.Model.VariableMonitoreo", b =>
                {
                    b.HasOne("ReactorNuclear.Model.TipoVariable", "TipoVariable")
                        .WithMany()
                        .HasForeignKey("TipoVariableIdTipoVariable");

                    b.Navigation("TipoVariable");
                });
#pragma warning restore 612, 618
        }
    }
}
