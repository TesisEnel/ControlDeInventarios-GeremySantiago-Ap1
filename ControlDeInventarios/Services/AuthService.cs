using ControlDeInventarios.Models;
using ControlDeInventarios.DAL;
using Microsoft.EntityFrameworkCore;

namespace ControlDeInventarios.Services
{
    public class AuthService
    {
        private readonly Contexto _context;

        public AuthService(Contexto context)
        {
            _context = context;
        }

        public async Task<Auth> LoginAsync(string correo, string clave)
        {
            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(u => u.Correo == correo.Trim() && u.Clave == clave.Trim());

            if (usuario == null)
                return new Auth { EstaAutenticado = false };

            return new Auth
            {
                UsuarioId = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Rol = usuario.Rol,
                EstaAutenticado = true
            };
        }

        public async Task RegistrarAsync(Usuario usuario)
        {
            // Opcional: validaciones básicas
            if (string.IsNullOrWhiteSpace(usuario.Nombre) || string.IsNullOrWhiteSpace(usuario.Correo))
                throw new ArgumentException("Datos de usuario inválidos");

            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CorreoExisteAsync(string correo)
        {
            return await _context.Usuario.AnyAsync(u => u.Correo == correo);
        }
    }
}
