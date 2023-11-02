using _3._Data.Model;
using Microsoft.EntityFrameworkCore;
namespace _3._Data.Context;

public class StudyMentorDB : DbContext
{
    public StudyMentorDB() {}
    
    public StudyMentorDB(DbContextOptions<StudyMentorDB> options) : base(options){}
    
    public DbSet<Student> Students { get; set; }

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

    }
}