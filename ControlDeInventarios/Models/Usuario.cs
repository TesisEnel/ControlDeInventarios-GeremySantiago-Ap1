using System.ComponentModel.DataAnnotations;

namespace ControlDeInventarios.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; } = string.Empty;

    public string Apellido { get; set; } = string.Empty;

    [Required(ErrorMessage = "La cédula es obligatoria")]
    public string Cedula { get; set; } = string.Empty;

    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress(ErrorMessage = "El formato del correo no es válido")]
    public string Correo { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    public string Clave { get; set; } = string.Empty;

    [Required(ErrorMessage = "El rol es obligatorio")]
    public string Rol { get; set; } = "Usuario";
}
