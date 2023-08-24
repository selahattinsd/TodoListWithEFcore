using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using TodoWithEFCore.Models;

public class TodoAppContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }
    public DbSet<Subtask> Subtasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=104.247.162.242\MSSQLSERVER2017;Database=akadem58_sd;User Id=akadem58_sd;Password=Hfoe27!96;TrustServerCertificate=True;");
}