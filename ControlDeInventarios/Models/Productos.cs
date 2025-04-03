using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlDeInventarios.Models;

public class Productos
{
    public int Id { get; set; }

    [Required]
    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? ImagenUrl { get; set; }

    [Required]
    public int? CategoriaId { get; set; }

    [ForeignKey("CategoriaId")]
    public Categorias? Categorias { get; set; }

    public int Stock { get; set; }
    [Precision(18, 2)]
    public decimal PrecioCompra { get; set; }
    [Precision(18, 2)]
    public decimal PrecioVenta { get; set; }

    public ICollection<EntradaProductos>? EntradaProductos { get; set; }
    public ICollection<SalidaProductos>? SalidaProductos { get; set; }
}
