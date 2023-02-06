using WebEstudo.DTO.Entidades;

namespace WebEstudo.DTO.Interfaces
{
    public interface IProdutoServices
    {
        ProdutoDTO Salvar(ProdutoDTO prod);

        void Excluir(ProdutoDTO user);

        List<ProdutoDTO> GetAll();

        List<ProdutoDTO> GetId(int IdProduto);

    }
}
