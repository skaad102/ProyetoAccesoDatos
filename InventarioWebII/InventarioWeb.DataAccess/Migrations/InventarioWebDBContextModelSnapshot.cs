﻿// <auto-generated />
using System;
using InventarioWeb.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventarioWeb.DataAccess.Migrations
{
    [DbContext(typeof(InventarioWebDBContext))]
    partial class InventarioWebDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InventarioWeb.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("dir_cli");

                    b.Property<string>("nombre_cli");

                    b.Property<string>("num_cli");

                    b.Property<string>("tel_cli");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("InventarioWeb.Models.Compra", b =>
                {
                    b.Property<int>("CompraId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductoId");

                    b.Property<int>("ProveedorId");

                    b.Property<int>("cant_compra");

                    b.Property<DateTime>("fecha_compra");

                    b.HasKey("CompraId");

                    b.HasIndex("ProductoId");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("InventarioWeb.Models.Producto", b =>
                {
                    b.Property<int>("ProductoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre_producto");

                    b.Property<int>("total_producto");

                    b.Property<double>("val_producto");

                    b.HasKey("ProductoID");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("InventarioWeb.Models.Proveedor", b =>
                {
                    b.Property<int>("ProveedorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("act_prov");

                    b.Property<string>("nom_prov");

                    b.Property<string>("tel_prov");

                    b.HasKey("ProveedorId");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("InventarioWeb.Models.Venta", b =>
                {
                    b.Property<int>("VentaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<int>("ProductoId");

                    b.Property<int>("cantidad_prodictos");

                    b.Property<DateTime>("fecha_venta");

                    b.Property<double>("total_venta");

                    b.HasKey("VentaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("InventarioWeb.Models.Compra", b =>
                {
                    b.HasOne("InventarioWeb.Models.Producto", "Producto")
                        .WithMany("compras")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InventarioWeb.Models.Proveedor", "Proveedor")
                        .WithMany("Proveedores")
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InventarioWeb.Models.Venta", b =>
                {
                    b.HasOne("InventarioWeb.Models.Cliente", "Cliente")
                        .WithMany("Ventas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InventarioWeb.Models.Producto", "Producto")
                        .WithMany("ventas")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
