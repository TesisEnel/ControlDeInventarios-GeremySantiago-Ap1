using System.ComponentModel.DataAnnotations;

namespace ControlDeInventarios.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    [Required]
    public string? Cedula { get; set; }

    [Required]
    public string? Correo { get; set; }

    [Required]
    public string? Clave { get; set; }

    [Required]
    public string? Rol { get; set; } // "Admin" o "Usuario"
}
