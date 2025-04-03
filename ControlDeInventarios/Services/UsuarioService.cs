using ControlDeInventarios.Models;  
using ControlDeInventarios.DAL;
using Microsoft.EntityFrameworkCore;

namespace ControlDeInventarios.Services;

public class UsuarioService
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public UsuarioService(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<List<Usuario>> ObtenerUsuariosAsync()
    {
        using var context = _dbFactory.CreateDbContext();
        return await context.Usuario.ToListAsync();
    }

    public async Task<Usuario?> ObtenerUsuarioPorIdAsync(string id)
    {
        using var context = _dbFactory.CreateDbContext();
        return await context.Usuario.FindAsync(id);
    }

    public async Task<bool> EliminarUsuarioAsync(string id)
    {
        using var context = _dbFactory.CreateDbContext();
        var user = await context.Usuario.FindAsync(id);
        if (user == null) return false;

        context.Usuario.Remove(user);
        await context.SaveChangesAsync();
        return true;
    }
}
