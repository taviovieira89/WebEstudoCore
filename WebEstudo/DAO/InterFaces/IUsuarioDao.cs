using WebEstudo.Entidades;

namespace WebEstudo.DAO.InterFaces
{
    public interface IUsuarioDao
    {
        Usuario Salvar(Usuario user);

        void Excluir(Usuario user);

        List<Usuario> GetAll();

        List<Usuario> GetId(int IdUsuario);

    }
}
