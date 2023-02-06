using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using WebEstudo.DTO.Interfaces;

namespace WebEstudo.DTO.Roles
{
    public static class LoginRoles
    {
        public static string[] Login(this IUsuarioServices usuarioDto, IConfiguration _configuration, string login, string senha, bool gerarToken = false)
        {
            string[] result = new string[2];
            var userToken = usuarioDto.GetAll().ToList().Where(a => a.login.ToLower() == login.ToLower() && a.senha.ToLower() == senha.ToLower()).FirstOrDefault();
            if (userToken == null) { throw new Exception("Login ou Senha Inválidos."); }
            result[0] = userToken.id_usuario.ToString();
            if (gerarToken)
            {
                result[1] = usuarioDto.GerarToken(_configuration, userToken.id_usuario.ToString());
            }
            return result;
        }
        public static string GerarToken(this IUsuarioServices usuarioDto, IConfiguration _configuration, string idUsuarioToken)
        {
            List<Claim> claims = new()
            {
                new Claim("userId", Convert.ToString(idUsuarioToken)),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: cred
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        public static bool ValidatarToken(this IUsuarioServices usuarioDTO, IConfiguration _configuration, string token)
        {
            var mySecret = _configuration.GetSection("AppSettings:Token").Value;
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = mySecurityKey
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
