using ControlDeInventarios.Models;
using ControlDeInventarios.DAL;
using Microsoft.EntityFrameworkCore;

namespace ControlDeInventarios.Services;

public class EntradaService
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public EntradaService(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<List<EntradaProductos>> ObtenerTodasAsync()
    {
        using var context = _dbFactory.CreateDbContext();
        return await context.Entradas
            .Include(e => e.Producto)
            .Include(e => e.Usuario)
            .ToListAsync();
    }

    public async Task AgregarAsync(EntradaProductos entrada)
    {
        using var context = _dbFactory.CreateDbContext();

        var producto = await context.Productos.FindAsync(entrada.ProductoId);
        if (producto != null)
        {
            producto.Stock += entrada.Cantidad;
        }

        await context.Entradas.AddAsync(entrada);
        await context.SaveChangesAsync();
    }
}
