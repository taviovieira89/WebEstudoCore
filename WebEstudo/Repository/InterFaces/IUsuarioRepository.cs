using WebEstudo.Entidades;

namespace WebEstudo.DAO.InterFaces
{
    public interface IUsuarioRepository
    {
        Usuario Salvar(Usuario user);

        void Excluir(Usuario user);

        List<Usuario> GetAll();

        List<Usuario> GetId(int IdUsuario);

    }
}
