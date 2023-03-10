// <auto-generated />
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(AppDBcontext))]
    partial class AppDBcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Entities.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Sword"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Shield"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Potion"
                        });
                });

            modelBuilder.Entity("API.Models.Entities.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ItemID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemID = 1,
                            CategoryID = 1,
                            ItemName = "Wooden Sword",
                            ItemPrice = 1m
                        },
                        new
                        {
                            ItemID = 2,
                            CategoryID = 1,
                            ItemName = "Stone Sword",
                            ItemPrice = 5.5m
                        },
                        new
                        {
                            ItemID = 3,
                            CategoryID = 1,
                            ItemName = "Iron Sword",
                            ItemPrice = 10m
                        },
                        new
                        {
                            ItemID = 4,
                            CategoryID = 2,
                            ItemName = "Wooden Shield",
                            ItemPrice = 5m
                        },
                        new
                        {
                            ItemID = 5,
                            CategoryID = 2,
                            ItemName = "Iron Shield",
                            ItemPrice = 7.8m
                        },
                        new
                        {
                            ItemID = 6,
                            CategoryID = 3,
                            ItemName = "Regeneration potion",
                            ItemPrice = 15m
                        },
                        new
                        {
                            ItemID = 7,
                            CategoryID = 3,
                            ItemName = "Strength potion",
                            ItemPrice = 10.3m
                        });
                });

            modelBuilder.Entity("API.Models.Entities.Item", b =>
                {
                    b.HasOne("API.Models.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
