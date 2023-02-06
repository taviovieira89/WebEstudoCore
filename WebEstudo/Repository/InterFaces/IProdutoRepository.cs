using WebEstudo.Entidades;

namespace WebEstudo.DAO.InterFaces
{
    public interface IProdutoRepository
    {
        Produtos Salvar(Produtos prod);

        void Excluir(Produtos prod);

        List<Produtos> GetAll();

        List<Produtos> GetId(int IdProdutos);
    }
}
