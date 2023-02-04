using Microsoft.EntityFrameworkCore;

namespace WebEstudo.DAO.InterFaces
{
    public interface IRepository
    {
        List<T> Listar<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : class;

        T Adicionar<T>(T entidade) where T : class;

        T Atualizar<T>(T entidade) where T : class;

        void Remover(object entidade);

        void Comitar();
    }
}
