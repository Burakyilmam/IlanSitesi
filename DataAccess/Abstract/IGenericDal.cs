using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGenericDal<T>
    {
        void Add(T t);
        void Update(T t);
        void Delete(T t);
        List<T> ListAll();
        T Get(int id);
        bool Check(Func<T, bool> predicate);
    }
}
