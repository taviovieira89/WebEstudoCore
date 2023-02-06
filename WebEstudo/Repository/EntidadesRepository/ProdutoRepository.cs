using WebEstudo.DAO.InterFaces;
using WebEstudo.Entidades;

namespace WebEstudo.DAO.EntidadesDAO
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IRepository _repository;
        public ProdutoRepository(IRepository repository)
        {
            _repository = repository;
        }
        public void Excluir(Produtos prod)
        {
            _repository.Remover(prod);
        }

        public List<Produtos> GetAll()
        {
            return _repository.Listar<Produtos>(x => true).ToList();
        }

        public List<Produtos> GetId(int IdProdutos)
        {
            return _repository.Listar<Produtos>(x => x.id_produto == IdProdutos).ToList();
        }

        public Produtos Salvar(Produtos prod)
        {
            if (prod.id_produto > 0)
            {
                return _repository.Atualizar(prod);
            }
            else
            {
                return _repository.Adicionar(prod);
            }
        }
    }
}
