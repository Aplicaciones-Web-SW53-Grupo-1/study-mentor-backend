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
    public DbSet<Tutor> Tutors { get; set; }
    public DbSet<Student> Students { get; set; }
    // db set reviews

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=admin;Database=StudyMentorDB;", serverVersion);
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
        
        
        //Students
        builder.Entity<Student>().ToTable("Student");
        builder.Entity<Student>().HasKey(p => p.Id);
        builder.Entity<Student>().Property(c => c.Name).IsRequired().HasMaxLength(45);
        builder.Entity<Student>().Property(q => q.Lastname).IsRequired().HasMaxLength(45);
        builder.Entity<Student>().Property(q => q.Email).IsRequired().HasMaxLength(45);
        builder.Entity<Student>().Property(q => q.Password).IsRequired().HasMaxLength(45);
        builder.Entity<Student>().OwnsOne(q => q.Genre, genre =>
        {
            genre.Property(g => g.NameGenre).IsRequired().HasMaxLength(10);
            genre.Property(g => g.Code).IsRequired().HasMaxLength(1);
        });
        builder.Entity<Student>().Property(q => q.Birthday).IsRequired().HasColumnType("date");
        builder.Entity<Student>().Property(q => q.Cellphone).IsRequired().HasMaxLength(9);
        builder.Entity<Student>().Property(q => q.Image).IsRequired().HasMaxLength(248);
        
        //Tutors
        builder.Entity<Tutor>().ToTable("Tutor");
        builder.Entity<Tutor>().HasKey(p => p.Id);
        builder.Entity<Tutor>().Property(c => c.Name).IsRequired().HasMaxLength(45);
        builder.Entity<Tutor>().Property(q => q.Lastname).IsRequired().HasMaxLength(45);
        builder.Entity<Tutor>().Property(q => q.Email).IsRequired().HasMaxLength(45);
        builder.Entity<Tutor>().Property(q => q.Password).IsRequired().HasMaxLength(45);
        builder.Entity<Tutor>().Property(q => q.Cellphone).IsRequired().HasMaxLength(9);
        builder.Entity<Tutor>().Property(q => q.Specialty).IsRequired().HasMaxLength(45);
        builder.Entity<Tutor>().Property(q => q.Cost).IsRequired();
        builder.Entity<Tutor>().Property(q => q.Image).IsRequired().HasMaxLength(248);
    }
}