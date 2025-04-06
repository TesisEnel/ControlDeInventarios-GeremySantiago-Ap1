using ControlDeInventarios.Models;
using ControlDeInventarios.DAL;
using Microsoft.EntityFrameworkCore;

namespace ControlDeInventarios.Services;

public class SalidaService
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public SalidaService(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<List<SalidaProductos>> ObtenerTodasAsync()
    {
        using var context = _dbFactory.CreateDbContext();
        return await context.Salidas
            .Include(s => s.Productos)
            .Include(s => s.Usuario)
            .ToListAsync();
    }

    public async Task AgregarAsync(SalidaProductos salida)
    {
        using var context = _dbFactory.CreateDbContext();

        var producto = await context.Productos.FindAsync(salida.ProductoId);
        if (producto != null)
        {
            if (producto.Stock < salida.Cantidad)
                throw new InvalidOperationException("No hay suficiente stock para realizar la salida.");

            producto.Stock -= salida.Cantidad;
        }

        await context.Salidas.AddAsync(salida);
        await context.SaveChangesAsync();
    }


    public async Task EliminarAsync(int id)
    {
        using var context = _dbFactory.CreateDbContext();

        var salida = await context.Salidas.FindAsync(id);
        if (salida != null)
        {
            var producto = await context.Productos.FindAsync(salida.ProductoId);
            if (producto != null)
            {
                producto.Stock += salida.Cantidad; // Revertir stock
            }

            context.Salidas.Remove(salida);
            await context.SaveChangesAsync();
        }
    }

}
