using ControlDeInventarios.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlDeInventarios.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Productos> Productos { get; set; }
    public DbSet<Categorias> Categorias { get; set; }
    public DbSet<EntradaProductos> Entradas { get; set; }
    public DbSet<SalidaProductos> Salidas { get; set; }
}
