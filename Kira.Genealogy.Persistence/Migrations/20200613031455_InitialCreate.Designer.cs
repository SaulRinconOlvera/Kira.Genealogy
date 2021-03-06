﻿// <auto-generated />
using System;
using Kira.Genealogy.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kira.Genealogy.Persistence.Migrations
{
    [DbContext(typeof(GenealogyContext))]
    [Migration("20200613031455_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kira.Genealogy.Model.Domain.Drawing.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("smalldatetime");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModificationDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid?>("MatePersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("NodeParentId")
                        .HasColumnType("int");

                    b.Property<int>("NodeType")
                        .HasColumnType("int");

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MatePersonId");

                    b.HasIndex("NodeParentId");

                    b.HasIndex("PersonId");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("Kira.Genealogy.Model.Domain.Tree.Branch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("smalldatetime");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("FirstFamilyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("LastModificationDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid?>("ParentBranchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SecondFamilyName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid>("TreeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TreeId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Kira.Genealogy.Model.Domain.Tree.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BornCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("BornDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("smalldatetime");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("FirstFamilyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsAlive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBornCityExactly")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsBornDateExactly")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDeathDateExactly")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModificationDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("MailAddress")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PersonalImage")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("SecondFamilyName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("ShareMailAddress")
                        .HasColumnType("bit");

                    b.Property<bool>("SharePhone")
                        .HasColumnType("bit");

                    b.Property<Guid>("TreeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TreeId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Kira.Genealogy.Model.Domain.Tree.TreeFamily", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("smalldatetime");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("FirstFamilyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("LastModificationDate")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SecondFamilyName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid>("UserOwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Trees");
                });

            modelBuilder.Entity("Kira.Genealogy.Model.Domain.Drawing.Node", b =>
                {
                    b.HasOne("Kira.Genealogy.Model.Domain.Tree.Person", "MatePerson")
                        .WithMany()
                        .HasForeignKey("MatePersonId");

                    b.HasOne("Kira.Genealogy.Model.Domain.Drawing.Node", "NodeParent")
                        .WithMany()
                        .HasForeignKey("NodeParentId");

                    b.HasOne("Kira.Genealogy.Model.Domain.Tree.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("Kira.Genealogy.Model.Domain.Tree.Branch", b =>
                {
                    b.HasOne("Kira.Genealogy.Model.Domain.Tree.TreeFamily", "TreeFamily")
                        .WithMany("Branches")
                        .HasForeignKey("TreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Kira.Genealogy.Model.Domain.Tree.Person", b =>
                {
                    b.HasOne("Kira.Genealogy.Model.Domain.Tree.TreeFamily", "TreeFamily")
                        .WithMany("TreePeople")
                        .HasForeignKey("TreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
