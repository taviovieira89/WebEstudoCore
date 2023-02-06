using WebEstudo.DTO.Entidades;

namespace WebEstudo.DTO.Interfaces
{
    public interface IUsuarioServices
    {
        UsuarioDTO Salvar(UsuarioDTO user);

        void Excluir(UsuarioDTO user);

        List<UsuarioDTO> GetAll();

        List<UsuarioDTO> GetId(int IdUsuario);
    }
}
