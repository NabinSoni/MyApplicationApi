using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplicationApi.Data
{
    public interface IBaseRepository<T> where T: class
    {
        IList<T> GetAll();
        T GetById(int id);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
