using WebEstudo.DAO.Factory;
using WebEstudo.DAO.InterFaces;
using WebEstudo.Entidades;

namespace WebEstudo.DAO.EntidadesDAO
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IRepository _repository;
        public UsuarioRepository(IRepository repository)
        {
            _repository = repository;
        }

        public void Excluir(Usuario user)
        {
            _repository.Remover(user);
        }

        public List<Usuario> GetAll()
        {
            return _repository.Listar<Usuario>(x => true).ToList();
        }

        public List<Usuario> GetId(int IdUsuario)
        {
            return _repository.Listar<Usuario>(x => x.id_usuario == IdUsuario).ToList();
        }

        public Usuario Salvar(Usuario user)
        {
            if (user.id_usuario > 0)
            {
               return _repository.Atualizar(user);
            }
            else
            {
                return _repository.Adicionar(user);
            }
        }
    }
}
