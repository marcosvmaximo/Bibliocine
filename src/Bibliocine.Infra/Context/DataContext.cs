using Bibliocine.Core;
using Bibliocine.Core.Data;
using Bibliocine.Core.Messages.Common;
using Bibliocine.Business;
using Bibliocine.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Bibliocine.Infra.Context;

public class DataContext : DbContext, IUnityOfWork
{
    public DataContext(DbContextOptions<DataContext> opt) : base(opt)
    {
    }
    
    public DbSet<Favorito> Favoritos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Ignore<Event>();
        modelBuilder.Ignore<Entity>();
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    
    
    public async Task<bool> Commit()
    {
        return await SaveChangesAsync() > 0;
    }
}

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        var conectString = "Server=localhost; Port=3307; Database=bibliocine; Uid=root;Pwd=8837;";

        optionsBuilder.UseMySql(conectString, ServerVersion.AutoDetect(conectString));

        return new DataContext(optionsBuilder.Options);
    }
}