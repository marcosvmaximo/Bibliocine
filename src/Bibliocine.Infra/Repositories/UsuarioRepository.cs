using Bibliocine.Business.Entities;
using Bibliocine.Business.Services.Interfaces;
using Bibliocine.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Bibliocine.Infra.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DataContext _context;

    public UsuarioRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task Salvar(Usuario user)
    {
        await _context.Usuarios.AddAsync(user);
    }

    public async Task<Usuario?> ObterPorId(Guid id)
    {
        return await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }
}