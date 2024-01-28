using Bibliocine.Domain;
using Bibliocine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bibliocine.Infra.Context;

public class DataContext : DbContext
{
    public DbSet<Obra> Obras { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
}