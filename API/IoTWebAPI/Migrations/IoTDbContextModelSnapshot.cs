﻿// <auto-generated />
using System;
using IoTWebAPI.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IoTWebAPI.Migrations
{
    [DbContext(typeof(IoTDbContext))]
    partial class IoTDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IoTWebAPI.Models.Data", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("a_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("update_time")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 2, 21, 17, 53, 22, 385, DateTimeKind.Local).AddTicks(7680));

                    b.Property<float>("value")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("a_id");

                    b.ToTable("Datas");
                });

            modelBuilder.Entity("IoTWebAPI.Models.Device", b =>
                {
                    b.Property<int>("d_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("create_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 2, 21, 0, 0, 0, 0, DateTimeKind.Local));

                    b.Property<string>("device_description")
                        .HasColumnType("nvarchar(350)")
                        .HasMaxLength(350)
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

                    b.Property<int>("u_id")
                        .HasColumnType("int");

                    b.HasKey("d_id");

                    b.HasIndex("u_id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("IoTWebAPI.Models.DvAttribute", b =>
                {
                    b.Property<int>("a_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("a_description")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(true);

                    b.Property<int>("a_name")
                        .HasColumnType("int");

                    b.Property<DateTime?>("active_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("d_id")
                        .HasColumnType("int");

                    b.Property<bool>("is_active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("last_update")
                        .HasColumnType("datetime2");

                    b.HasKey("a_id");

                    b.HasIndex("d_id");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("IoTWebAPI.Models.User", b =>
                {
                    b.Property<int>("u_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("create_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 2, 21, 0, 0, 0, 0, DateTimeKind.Local));

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<bool>("is_active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("is_admin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

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
                        .HasForeignKey("a_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IoTWebAPI.Models.Device", b =>
                {
                    b.HasOne("IoTWebAPI.Models.User", "owner")
                        .WithMany("my_devices")
                        .HasForeignKey("u_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IoTWebAPI.Models.DvAttribute", b =>
                {
                    b.HasOne("IoTWebAPI.Models.Device", "device")
                        .WithMany("list_attributes")
                        .HasForeignKey("d_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
