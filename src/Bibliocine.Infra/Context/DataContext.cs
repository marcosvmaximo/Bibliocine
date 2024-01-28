using Bibliocine.Core;
using Bibliocine.Core.Data;
using Bibliocine.Core.Messages.Common;
using Bibliocine.Domain;
using Bibliocine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bibliocine.Infra.Context;

public class DataContext  : DbContext, IUnityOfWork
{
    public DataContext(DbContextOptions<DataContext> opt) : base(opt)
    {
    }
    
    public DbSet<Livro> Livros { get; set; }
    public DbSet<Filme> Filmes { get; set; }
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
    
    //
    // public async Task<bool> Commit()
    // {
    //     bool result = await SaveChangesAsync() > 0;
    //     
    //     if (result)
    //     {
    //         await _bus.PublishEvents(this);
    //     }
    //     else
    //     {
    //         await _bus.PublishNotification(
    //             new DomainNotification("Evento", "Falha ao salvar a entidade, eventos não foram enviados."));
    //     }
    //
    //     return result;
    // }
    
    public Task<bool> Commit()
    {
        throw new NotImplementedException();
    }
}