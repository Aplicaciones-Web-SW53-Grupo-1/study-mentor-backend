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
    // db set reviews

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

        // nombrar tablas
        builder.Entity<Payment>().ToTable("Payment");
        // has key definir llave primaria
        builder.Entity<Payment>().HasKey(p => p.Id);
        // definir campos requeridos
        builder.Entity<Payment>().Property(p => p.CardNumber).IsRequired().HasPrecision(16);
        builder.Entity<Payment>().Property(p => p.Cvv).IsRequired().HasPrecision(3);
        // obligatorio
        builder.Entity<Payment>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Payment>().Property(p => p.IsActive).HasDefaultValue(true);
        
        //REVIEWS
        
        
    }
}