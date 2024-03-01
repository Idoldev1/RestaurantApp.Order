﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantApp.Order.Data.DataAccess;

#nullable disable

namespace RestaurantApp.Order.API.Migrations
{
    [DbContext(typeof(OrderDb))]
    [Migration("20240228150605_NewMigration")]
    partial class NewMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("RestaurantApp.Order.Domain.Entities.OrderItem", b =>
                {
                    b.Property<string>("FoodId")
                        .HasColumnType("TEXT")
                        .HasColumnName("Food Id");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrdersOrderId")
                        .HasColumnType("TEXT");

                    b.HasKey("FoodId");

                    b.HasIndex("OrdersOrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("RestaurantApp.Order.Domain.Entities.Orders", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("TEXT")
                        .HasColumnName("Order Id");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RestaurantApp.Order.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("RestaurantApp.Order.Domain.Entities.Orders", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrdersOrderId");
                });

            modelBuilder.Entity("RestaurantApp.Order.Domain.Entities.Orders", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
