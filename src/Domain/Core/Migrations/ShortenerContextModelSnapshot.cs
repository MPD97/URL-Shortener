﻿// <auto-generated />
using Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Migrations
{
    [DbContext(typeof(ShortenerContext))]
    partial class ShortenerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RedirectId");

                    b.HasIndex("ShortcutId");

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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RedirectExtendedId");

                    b.HasIndex("ShortcutId");

                    b.ToTable("RedirectExtended");
                });

            modelBuilder.Entity("Core.Entities.Shortcut", b =>
                {
                    b.Property<long>("ShortcutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RedirectExtendedId")
                        .HasColumnType("bigint");

                    b.Property<long>("RedirectId")
                        .HasColumnType("bigint");

                    b.HasKey("ShortcutId");

                    b.ToTable("Shortcut");
                });

            modelBuilder.Entity("Core.Entities.Redirect", b =>
                {
                    b.HasOne("Core.Entities.Shortcut", "Shortcut")
                        .WithMany("Redirects")
                        .HasForeignKey("ShortcutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.RedirectExtended", b =>
                {
                    b.HasOne("Core.Entities.Shortcut", "Shortcut")
                        .WithMany("RedirectsExtended")
                        .HasForeignKey("ShortcutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
