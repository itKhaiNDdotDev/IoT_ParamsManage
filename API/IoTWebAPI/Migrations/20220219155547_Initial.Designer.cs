﻿// <auto-generated />
using System;
using IoTWebAPI.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IoTWebAPI.Migrations
{
    [DbContext(typeof(IoTDbContext))]
    [Migration("20220219155547_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IoTWebAPI.Models.Data", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("a_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("update_time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 2, 19, 22, 55, 46, 913, DateTimeKind.Local).AddTicks(1644));

                    b.Property<float>("value")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("a_id");

                    b.ToTable("Datas");
                });

            modelBuilder.Entity("IoTWebAPI.Models.Device", b =>
                {
                    b.Property<string>("d_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("create_time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 2, 19, 22, 55, 46, 902, DateTimeKind.Local).AddTicks(239));

                    b.Property<string>("device_description")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300)
                        .IsUnicode(true);

                    b.Property<string>("device_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<string>("img_url")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<bool>("is_active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("u_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("d_id");

                    b.HasIndex("u_id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("IoTWebAPI.Models.DvAttribute", b =>
                {
                    b.Property<string>("a_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("a_description")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300)
                        .IsUnicode(true);

                    b.Property<int>("a_name")
                        .HasColumnType("int");

                    b.Property<DateTime>("create_time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 2, 19, 22, 55, 46, 911, DateTimeKind.Local).AddTicks(4888));

                    b.Property<string>("d_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("is_active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("last_update")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("a_id");

                    b.HasIndex("d_id");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("IoTWebAPI.Models.User", b =>
                {
                    b.Property<string>("u_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("create_time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 2, 19, 22, 55, 46, 898, DateTimeKind.Local).AddTicks(5834));

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60)
                        .IsUnicode(true);

                    b.Property<bool>("is_active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.HasKey("u_id");

                    b.HasIndex("email")
                        .IsUnique()
                        .HasFilter("[email] IS NOT NULL");

                    b.ToTable("User");
                });

            modelBuilder.Entity("IoTWebAPI.Models.Data", b =>
                {
                    b.HasOne("IoTWebAPI.Models.DvAttribute", "dv_attribute")
                        .WithMany("data_values")
                        .HasForeignKey("a_id");
                });

            modelBuilder.Entity("IoTWebAPI.Models.Device", b =>
                {
                    b.HasOne("IoTWebAPI.Models.User", "owner")
                        .WithMany("my_devices")
                        .HasForeignKey("u_id");
                });

            modelBuilder.Entity("IoTWebAPI.Models.DvAttribute", b =>
                {
                    b.HasOne("IoTWebAPI.Models.Device", "device")
                        .WithMany("list_attributes")
                        .HasForeignKey("d_id");
                });
#pragma warning restore 612, 618
        }
    }
}
