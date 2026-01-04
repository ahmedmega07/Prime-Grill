using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;


public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<User>(options)
{
    internal DbSet<Restaurant.Domain.Entities.RestaurantEntity> Restaurants { get; set; }
    internal DbSet<Restaurant.Domain.Entities.Dish> Dishes { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Restaurant.Domain.Entities.RestaurantEntity>().OwnsOne(r => r.Address);

        modelBuilder.Entity<Restaurant.Domain.Entities.RestaurantEntity>().HasMany(r => r.Dishes).WithOne()
            .HasForeignKey(d => d.RestaurantId);


    }



}
