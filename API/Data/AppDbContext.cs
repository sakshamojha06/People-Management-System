using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Person> People => Set<Person>();

    public DbSet<EducationLevel> EducationLevels => Set<EducationLevel>();

    public DbSet<Degree> Degrees => Set<Degree>();

    public DbSet<Specialization> Specializations => Set<Specialization>();
}