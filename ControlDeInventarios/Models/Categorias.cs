using System.ComponentModel.DataAnnotations;

namespace ControlDeInventarios.Models;

public class Categorias
{
    public int Id { get; set; }

    [Required]
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }

    public ICollection<Productos>? Productos { get; set; }
}
