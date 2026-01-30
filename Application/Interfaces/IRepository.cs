using System.Linq;
using System.Linq.Expressions;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    IQueryable<T> GetQueryable();   // thêm dòng
    T? GetById(int id);
    IQueryable<T> Query();

    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);

    bool Any(Expression<Func<T, bool>> predicate);
}
