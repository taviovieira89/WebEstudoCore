using WebEstudo.DTO.Entidades;

namespace WebEstudo.DTO.Interfaces
{
    public interface IProdutoDTO
    {
        ProdutoDTO Salvar(ProdutoDTO prod);

        void Excluir(ProdutoDTO user);

        List<ProdutoDTO> GetAll();

        List<ProdutoDTO> GetId(int IdProduto);

    }
}
