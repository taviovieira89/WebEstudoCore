using AutoMapper;
using System;
using WebEstudo.DAO.InterFaces;
using WebEstudo.DTO.Entidades;
using WebEstudo.DTO.Interfaces;
using WebEstudo.Entidades;

namespace WebEstudo.DTO.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _usuarioDAO;
        private readonly IMapper _mapper;
        public UsuarioServices(IUsuarioRepository usuarioDAO, IMapper mapper)
        {
            _mapper = mapper;
            _usuarioDAO = usuarioDAO;
        }
        public void Excluir(UsuarioDTO user)
        {
            var User = _mapper.Map<Usuario>(user);
            _usuarioDAO.Excluir(User);
        }

        public List<UsuarioDTO> GetAll()
        {
            var Lista = _usuarioDAO.GetAll();
            var ListaDTO = _mapper.Map<List<Usuario>, List<UsuarioDTO>>(Lista);
            return ListaDTO;
        }

        public List<UsuarioDTO> GetId(int IdUsuario)
        {
            var Lista = _usuarioDAO.GetId(IdUsuario);
            var ListaDTO = _mapper.Map<List<Usuario>, List<UsuarioDTO>>(Lista);
            return ListaDTO;
        }

        public UsuarioDTO Salvar(UsuarioDTO user)
        {
            var User = _mapper.Map<Usuario>(user);
            var users = _usuarioDAO.Salvar(User);
            user = _mapper.Map<UsuarioDTO>(users);
            return user;
        }
    }
}
