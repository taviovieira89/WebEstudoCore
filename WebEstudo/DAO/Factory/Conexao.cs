using System.Linq.Expressions;
using WebEstudo.DAO.InterFaces;

namespace WebEstudo.DAO.Factory
{
    public class Conexao : IRepository
    {
        private readonly DaoContext _context;
        public Conexao(DaoContext contexto)
        {
            _context = contexto;
        }

        public T Adicionar<T>(T entidade) where T : class
        {
            var entity = _context.Add<T>(entidade).Entity;
            Comitar();
            return entity;
        }

        public T Atualizar<T>(T entidade) where T : class
        {
            var entity = _context.Update<T>(entidade).Entity;
            Comitar();
            return entity;
        }

        public void Comitar()
        {
            _context.SaveChanges();
        }

        public List<T> Listar<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return _context.Set<T>().Where(expression).ToList();
        }

        public void Remover(object entidade)
        {
            _context.Remove(entidade);
            Comitar();
        }
    }
}
