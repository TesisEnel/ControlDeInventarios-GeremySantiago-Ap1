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

        public async Task<Usuario> LoginAsync(string correo, string clave)
        {
            return await _context.Usuario
                .FirstOrDefaultAsync(u => u.Correo == correo && u.Clave == clave);
        }

        public async Task RegistrarAsync(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CorreoExisteAsync(string correo)
        {
            return await _context.Usuario.AnyAsync(u => u.Correo == correo);
        }
    }
}
