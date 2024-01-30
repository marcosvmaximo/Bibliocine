using Bibliocine.Business.Entities;
using Bibliocine.Business.Services.Interfaces;
using Bibliocine.Core.Data;
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
    
    public IUnityOfWork UnityOfWork => _context;
    
    public async Task Salvar(Usuario user)
    {
        try
        {
            await _context.Usuarios.AddAsync(user);
        }
        catch (Exception ex)
        {
            // logging
            throw;
        }
    }

    public async Task Atualizar(Usuario user)
    {
        try
        {
            _context.Entry(user).State = EntityState.Modified;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task AdicionarFavorito(Favorito favorito)
    {
        try
        {
            await _context.Favoritos.AddAsync(favorito);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task DeletarFavorito(Favorito favorito)
    {
        try
        {
            _context.Favoritos.Remove(favorito);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<Usuario?> ObterPorId(Guid id)
    {
        try
        {
            return await _context.Usuarios.AsNoTracking()
                .Include(x => x.Favoritos)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (Exception ex)
        {
            // logging
            throw;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

}