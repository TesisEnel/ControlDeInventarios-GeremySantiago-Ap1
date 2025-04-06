using ControlDeInventarios.Models;  
using ControlDeInventarios.DAL;
using Microsoft.EntityFrameworkCore;

namespace ControlDeInventarios.Services;

public class UsuarioService
{
    private readonly IDbContextFactory<Contexto> _contextoFactory;

    public UsuarioService(IDbContextFactory<Contexto> dbFactory)
    {
        _contextoFactory = dbFactory;
    }

    public async Task<List<Usuario>> ObtenerTodosAsync()
    {
        using var context = _contextoFactory.CreateDbContext();
        return await context.Usuario.ToListAsync();
    }

    public async Task<Usuario?> ObtenerPorIdAsync(int id)
    {
        using var context = _contextoFactory.CreateDbContext();
        return await context.Usuario.FindAsync(id);
    }

    public async Task EliminarAsync(int id)
    {
        using var context = _contextoFactory.CreateDbContext();
        var user = await context.Usuario.FindAsync(id);
        if (user != null)
        {
            context.Usuario.Remove(user);
            await context.SaveChangesAsync();
        }
    }

    public async Task AgregarAsync(Usuario usuario)
    {
        using var context = _contextoFactory.CreateDbContext();
        context.Usuario.Add(usuario);
        await context.SaveChangesAsync();
    }

    public async Task EditarAsync(Usuario usuario)
    {
        using var context = _contextoFactory.CreateDbContext();
        context.Usuario.Update(usuario);
        await context.SaveChangesAsync();
    }
}
