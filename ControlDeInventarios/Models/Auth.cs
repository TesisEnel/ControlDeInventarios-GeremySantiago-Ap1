using System.ComponentModel.DataAnnotations;

namespace ControlDeInventarios.Models;

public class Auth
{
    public int UsuarioId { get; set; }
    public string? Nombre { get; set; }
    public string? Correo { get; set; }
    public string? Rol { get; set; }
    public bool EstaAutenticado { get; set; }
}
