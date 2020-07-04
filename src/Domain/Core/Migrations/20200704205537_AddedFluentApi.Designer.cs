﻿// <auto-generated />
using Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Migrations
{
    [DbContext(typeof(ShortenerContext))]
    [Migration("20200704205537_AddedFluentApi")]
    partial class AddedFluentApi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Redirect", b =>
                {
                    b.Property<long>("RedirectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ShortcutId")
                        .HasColumnType("bigint");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("RedirectId");

                    b.ToTable("Redirects");
                });

            modelBuilder.Entity("Core.Entities.RedirectExtended", b =>
                {
                    b.Property<long>("RedirectExtendedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ShortcutId")
                        .HasColumnType("bigint");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.HasKey("RedirectExtendedId");

                    b.ToTable("RedirectExtendeds");
                });

            modelBuilder.Entity("Core.Entities.Shortcut", b =>
                {
                    b.Property<long>("ShortcutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<long>("RedirectExtendedId")
                        .HasColumnType("bigint");

                    b.Property<long>("RedirectId")
                        .HasColumnType("bigint");

                    b.Property<long>("TimesRedirect")
                        .HasColumnType("bigint");

                    b.HasKey("ShortcutId");

                    b.HasIndex("RedirectExtendedId")
                        .IsUnique();

                    b.HasIndex("RedirectId")
                        .IsUnique();

                    b.ToTable("Shortcuts");
                });

            modelBuilder.Entity("Core.Entities.Shortcut", b =>
                {
                    b.HasOne("Core.Entities.RedirectExtended", "RedirectExtended")
                        .WithOne("Shortcut")
                        .HasForeignKey("Core.Entities.Shortcut", "RedirectExtendedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Redirect", "Redirect")
                        .WithOne("Shortcut")
                        .HasForeignKey("Core.Entities.Shortcut", "RedirectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}