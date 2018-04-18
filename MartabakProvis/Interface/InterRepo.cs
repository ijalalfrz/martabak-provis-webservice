using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartabakProvis.Interface
{
    public interface InterRepo<T>
    {
        bool Insert(T dt);
        bool Update(T dt);
        bool Delete(T dt);
        T GetById(int id);
        List<T> GetAll();
    }
}
