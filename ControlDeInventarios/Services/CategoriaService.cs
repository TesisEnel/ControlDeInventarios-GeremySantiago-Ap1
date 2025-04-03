using ControlDeInventarios.Models;
using ControlDeInventarios.DAL;
using Microsoft.EntityFrameworkCore;

namespace ControlDeInventarios.Services;

public class CategoriaService
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public CategoriaService(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<List<Categorias>> ObtenerTodasAsync()
    {
        using var context = _dbFactory.CreateDbContext();
        return await context.Categorias.ToListAsync();
    }

    public async Task<Categorias?> ObtenerPorIdAsync(int id)
    {
        using var context = _dbFactory.CreateDbContext();
        return await context.Categorias.FindAsync(id);
    }

    public async Task AgregarAsync(Categorias categoria)
    {
        using var context = _dbFactory.CreateDbContext();
        await context.Categorias.AddAsync(categoria);
        await context.SaveChangesAsync();
    }

    public async Task ActualizarAsync(Categorias categoria)
    {
        using var context = _dbFactory.CreateDbContext();
        context.Categorias.Update(categoria);
        await context.SaveChangesAsync();
    }

    public async Task EliminarAsync(int id)
    {
        using var context = _dbFactory.CreateDbContext();
        var categoria = await context.Categorias.FindAsync(id);
        if (categoria is not null)
        {
            context.Categorias.Remove(categoria);
            await context.SaveChangesAsync();
        }
    }
}
