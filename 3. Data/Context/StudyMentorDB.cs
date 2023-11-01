using _3._Data.Model;
using Microsoft.EntityFrameworkCore;

namespace _3._Data.Context;

public class StudyMentorDB : DbContext
{
    public StudyMentorDB()
    {
        
    }
    
    public StudyMentorDB(DbContextOptions<StudyMentorDB> options) : base(options){}
    
    public DbSet<Payment> Payments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=root;Database=StudyMentorDB;", serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Payment>().ToTable("Payment");
        builder.Entity<Payment>().HasKey(p => p.Id);
        builder.Entity<Payment>().Property(p => p.CardNumber).IsRequired().HasPrecision(16);
        builder.Entity<Payment>().Property(p => p.Cvv).IsRequired().HasPrecision(3);
        builder.Entity<Payment>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Payment>().Property(p => p.IsActive).HasDefaultValue(true);
    }
}