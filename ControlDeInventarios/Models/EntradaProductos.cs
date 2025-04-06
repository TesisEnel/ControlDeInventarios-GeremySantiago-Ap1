using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControlDeInventarios.Models
{
    public class EntradaProductos
    {
        public int Id { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public Productos? Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public int? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }
    }
}
