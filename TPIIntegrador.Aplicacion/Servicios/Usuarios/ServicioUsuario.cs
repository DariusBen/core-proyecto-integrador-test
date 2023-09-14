
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using TPIIntegrador.Aplicacion.Modelos;

namespace TPIIntegrador.Aplicacion.Servicios
{
    public class ServicioUsuario : IServicioUsuario
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuracion;

        public ServicioUsuario(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuracion = configuration;
        }

        public async Task<RespuestaLogin> Autenticar(Login login)
        {
            var usuario = await _userManager.FindByNameAsync(login.Usuario);
            
            if (usuario != null && await _userManager.CheckPasswordAsync(usuario,login.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(usuario);

                var token = this.GenerarJWT(usuario);

                return new RespuestaLogin { Id = 1, Usuario = login.Usuario, Token = token };

            }

            return new RespuestaLogin { Id = 0, Mensaje = "Credenciales Inválidas"}; 

        }


        private string GenerarJWT(IdentityUser usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuracion["JWT:Secret"]);

            var authClaims = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, usuario.UserName),
                    new Claim("IdUsuario", usuario.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = authClaims,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}