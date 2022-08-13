using Microsoft.EntityFrameworkCore;

namespace BookMarket.Data.Entities;

public class DataContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Book> Books { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigurePerson(modelBuilder);
        ConfigureAuthor(modelBuilder);
        ConfigureCategory(modelBuilder);
        ConfigureCustomer(modelBuilder);
        ConfigurePublisher(modelBuilder);
        ConfigureBook(modelBuilder);
    }
    
    //нужно ли для не nullable типов дополнительно указывать IsRequired?
    private void ConfigureBook(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(b => b.Rating)
                .HasPrecision(6, 1)
                .IsRequired();

            entity.HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .OnDelete(DeleteBehavior.Restrict);
            
            entity.HasOne(b => b.Author)
                .WithMany(c => c.Books)
                .OnDelete(DeleteBehavior.Restrict);
            
            entity.HasOne(b => b.Author)
                .WithMany(p => p.Books)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
    
    private void ConfigureAuthor(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(a => a.Rating)
                .HasPrecision(6, 1)
                .IsRequired();

            entity.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);
        });
    }
    
    private void ConfigurePublisher(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            
            entity.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(500);
        });
    }
    
    private void ConfigureCustomer(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasOne(c => c.Person)
                .WithOne(p => p.Customer)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
    
    private void ConfigureCategory(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            
            entity.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(500);
        });
    }
    
    //TODO: придумать нормальные названия
    private void ConfigurePerson(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(p => p.Age)
                .IsRequired();

            entity.Property(p => p.Name)
                .IsRequired();

            entity.Property(p => p.Surname)
                .IsRequired();
            
            entity.Property(p => p.Patronymic)
                .IsRequired();
        });
    }
}