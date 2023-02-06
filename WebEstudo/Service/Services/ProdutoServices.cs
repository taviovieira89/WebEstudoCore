using AutoMapper;
using WebEstudo.DAO.InterFaces;
using WebEstudo.DTO.Entidades;
using WebEstudo.DTO.Interfaces;
using WebEstudo.Entidades;

namespace WebEstudo.DTO.Services
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IProdutoRepository _prodDAO;
        private readonly IMapper _mapper;
        public ProdutoServices(IProdutoRepository prodDAO, IMapper mapper)
        {
            _mapper = mapper;
            _prodDAO = prodDAO;
        }
        public void Excluir(ProdutoDTO user)
        {
            var prod = _mapper.Map<Produtos>(user);
            _prodDAO.Excluir(prod);
        }

        public List<ProdutoDTO> GetAll()
        {
            var Lista = _prodDAO.GetAll();
            var ListaDTO = _mapper.Map<List<Produtos>, List<ProdutoDTO>>(Lista);
            return ListaDTO;
        }

        public List<ProdutoDTO> GetId(int IdProdutos)
        {
            var Lista = _prodDAO.GetId(IdProdutos);
            var ListaDTO = _mapper.Map<List<Produtos>, List<ProdutoDTO>>(Lista);
            return ListaDTO;
        }

        public ProdutoDTO Salvar(ProdutoDTO prod)
        {
            var Produtos = _mapper.Map<Produtos>(prod);
            var prods = _prodDAO.Salvar(Produtos);
            prod = _mapper.Map<ProdutoDTO>(prods);
            return prod;
        }
    }
}
