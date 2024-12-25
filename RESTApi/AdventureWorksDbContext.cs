using Microsoft.EntityFrameworkCore;

public class AdventureWorksDbContext : DbContext
{
    public AdventureWorksDbContext(DbContextOptions<AdventureWorksDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}