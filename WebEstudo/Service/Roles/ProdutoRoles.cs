using WebEstudo.DTO.Entidades;
using WebEstudo.DTO.Interfaces;

namespace WebEstudo.DTO.Roles
{
    public static class ProdutoRoles
    {
        public static List<ProdutoDTO> GetProdutoName(this IProdutoServices produtoDTO, string nm_produto)
        {
            return produtoDTO.GetAll().Where(a => a.nm_produto.ToLower().Contains(nm_produto)).ToList();
        }
    }
}
