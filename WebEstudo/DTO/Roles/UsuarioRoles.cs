using WebEstudo.DTO.Entidades;
using WebEstudo.DTO.Interfaces;

namespace WebEstudo.DTO.Roles
{
    public static class UsuarioRoles
    {
        public static List<UsuarioDTO> GetNomeUsuario(this IUsuarioDTO usuarioDTO, string nm_usuario)
        {
            return usuarioDTO.GetAll().Where(a => a.nm_usuario.ToLower().Contains(nm_usuario)).ToList();
        }

        public static bool ValidarLoginSenha(this IUsuarioDTO usuarioDTO, string login, string senha)
        {
            return usuarioDTO.GetAll().Where(a => a.login.ToLower() == login && a.senha.ToLower() == senha).Any();
        }

    }
}
