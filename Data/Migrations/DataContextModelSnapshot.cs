﻿// <auto-generated />
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.SubscribeEntity", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("AdvertisingUpdate")
                        .HasColumnType("bit");

                    b.Property<bool>("DailyNewsLetter")
                        .HasColumnType("bit");

                    b.Property<bool>("EventUpdates")
                        .HasColumnType("bit");

                    b.Property<bool>("Podcast")
                        .HasColumnType("bit");

                    b.Property<bool>("StartupWeekly")
                        .HasColumnType("bit");

                    b.Property<bool>("WeekinReview")
                        .HasColumnType("bit");

                    b.HasKey("Email");

                    b.ToTable("subscriber");
                });
#pragma warning restore 612, 618
        }
    }
}
