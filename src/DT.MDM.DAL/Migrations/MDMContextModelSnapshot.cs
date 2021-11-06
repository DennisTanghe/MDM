﻿// <auto-generated />
using System;
using DT.MDM.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DT.MDM.DAL.Migrations
{
    [DbContext(typeof(MDMContext))]
    partial class MDMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChoiceFieldChoiceValue", b =>
                {
                    b.Property<int>("ChoiceFieldsId")
                        .HasColumnType("int");

                    b.Property<int>("ChoiceValuesId")
                        .HasColumnType("int");

                    b.HasKey("ChoiceFieldsId", "ChoiceValuesId");

                    b.HasIndex("ChoiceValuesId");

                    b.ToTable("ChoiceFieldChoiceValue");
                });

            modelBuilder.Entity("DT.MDM.Models.ChoiceValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChoiceValues");
                });

            modelBuilder.Entity("DT.MDM.Models.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("DT.MDM.Models.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DataType")
                        .HasColumnType("int");

                    b.Property<string>("DefaultValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Modified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Fields");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Field");
                });

            modelBuilder.Entity("EntityField", b =>
                {
                    b.Property<int>("AttributesId")
                        .HasColumnType("int");

                    b.Property<int>("EntitiesId")
                        .HasColumnType("int");

                    b.HasKey("AttributesId", "EntitiesId");

                    b.HasIndex("EntitiesId");

                    b.ToTable("EntityField");
                });

            modelBuilder.Entity("DT.MDM.Models.ChoiceField", b =>
                {
                    b.HasBaseType("DT.MDM.Models.Field");

                    b.HasDiscriminator().HasValue("ChoiceField");
                });

            modelBuilder.Entity("ChoiceFieldChoiceValue", b =>
                {
                    b.HasOne("DT.MDM.Models.ChoiceField", null)
                        .WithMany()
                        .HasForeignKey("ChoiceFieldsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DT.MDM.Models.ChoiceValue", null)
                        .WithMany()
                        .HasForeignKey("ChoiceValuesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityField", b =>
                {
                    b.HasOne("DT.MDM.Models.Field", null)
                        .WithMany()
                        .HasForeignKey("AttributesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DT.MDM.Models.Entity", null)
                        .WithMany()
                        .HasForeignKey("EntitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
