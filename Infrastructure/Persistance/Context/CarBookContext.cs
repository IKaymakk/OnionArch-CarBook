using CarBook.Domain.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context;

public class CarBookContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=KAYMAK\\SQLEXPRESS;database=CarBookDb; integrated security=true;TrustServerCertificate=True;");
    }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarDescription> CarDescriptions { get; set; }
    public DbSet<CarFeature> CarFeatures { get; set; }
    public DbSet<CarPricing> CarPricings { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<FooterAddresses> FooterAddresses { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Pricing> Pricings { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<TagCloud> TagClouds { get; set; }
    public DbSet<Comments> Comments { get; set; }
    public DbSet<RentACar> RentACars { get; set; }
    public DbSet<Rezervasyon> Rezervasyons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Çoka çok ilişki konfigürasyonu
        modelBuilder.Entity<BlogTagCloud>()
            .HasKey(bt => new { bt.BlogId, bt.TagCloudId });

        modelBuilder.Entity<BlogTagCloud>()
            .HasOne(bt => bt.Blogs)
            .WithMany(b => b.BlogTagClouds)
            .HasForeignKey(bt => bt.BlogId);

        modelBuilder.Entity<BlogTagCloud>()
            .HasOne(bt => bt.TagClouds)
            .WithMany(t => t.BlogTagClouds)
            .HasForeignKey(bt => bt.TagCloudId);

        modelBuilder.Entity<Rezervasyon>()
            .HasOne(l => l.PickUpLocation)
            .WithMany(r => r.PickUpReservation)
            .HasForeignKey(x => x.PickUpLocationID)
            .OnDelete(DeleteBehavior.ClientSetNull);

        modelBuilder.Entity<Rezervasyon>()
          .HasOne(l => l.DropOffLocation)
          .WithMany(r => r.DropOffReservation)
          .HasForeignKey(x => x.DropOffLocationID)
          .OnDelete(DeleteBehavior.ClientSetNull);

    }

}
