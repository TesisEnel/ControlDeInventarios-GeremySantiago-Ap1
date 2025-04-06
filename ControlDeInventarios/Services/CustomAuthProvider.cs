using System.Security.Claims;
using System.Threading.Tasks;
using ControlDeInventarios.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace ControlDeInventarios.Services
{
    public class CustomAuthProvider : AuthenticationStateProvider
    {
        private Auth? _usuarioActual;

        public void EstablecerUsuario(Auth usuario)
        {
            _usuarioActual = usuario;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public void CerrarSesion()
        {
            _usuarioActual = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (_usuarioActual == null || !_usuarioActual.EstaAutenticado)
            {
                var anonimo = new ClaimsPrincipal(new ClaimsIdentity());
                return Task.FromResult(new AuthenticationState(anonimo));
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, _usuarioActual.Nombre),
                new Claim(ClaimTypes.Email, _usuarioActual.Correo),
                new Claim(ClaimTypes.Role, _usuarioActual.Rol)
            }, "CustomAuth");

            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }
    }
}
