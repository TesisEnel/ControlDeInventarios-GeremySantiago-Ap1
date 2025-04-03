using ControlDeInventarios.DAL;
using ControlDeInventarios.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlDeInventarios.Services;

public class ProductosService
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public ProductosService(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<List<Productos>> ObtenerTodosAsync()
    {
        using var context = _dbFactory.CreateDbContext();
        return await context.Productos
            .Include(p => p.Categorias)
            .ToListAsync();
    }

    public async Task<Productos?> ObtenerPorIdAsync(int id)
    {
        using var context = _dbFactory.CreateDbContext();
        return await context.Productos
            .Include(p => p.Categorias)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AgregarAsync(Productos producto)
    {
        using var context = _dbFactory.CreateDbContext();
        await context.Productos.AddAsync(producto);
        await context.SaveChangesAsync();
    }

    public async Task ActualizarAsync(Productos producto)
    {
        using var context = _dbFactory.CreateDbContext();
        context.Productos.Update(producto);
        await context.SaveChangesAsync();
    }

    public async Task EliminarAsync(int id)
    {
        using var context = _dbFactory.CreateDbContext();
        var producto = await context.Productos.FindAsync(id);
        if (producto is not null)
        {
            context.Productos.Remove(producto);
            await context.SaveChangesAsync();
        }
    }
}
