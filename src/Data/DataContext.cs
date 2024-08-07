using dotnetmediatrdemo.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetmediatrdemo.Data;

public class DataContext : DbContext
{ 
    public DbSet<StudentModel> Students { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        Students = Set<StudentModel>();
    }
    
    public DataContext() : base() {}

    protected override void OnConfiguring(DbContextOptionsBuilder  builder)
    {
        if (!builder.IsConfigured)
        {
            builder
                .UseSqlite("Data Source=shopping.db");
        }
    }
}