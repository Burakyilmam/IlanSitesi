using DataAccess.Abstract;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly DataContext _dataContext;

        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(T t)
        {
            _dataContext.Add(t);
            _dataContext.SaveChanges();
        }
        public void Update(T t)
        {
            _dataContext.Update(t);
            _dataContext.SaveChanges();
        }
        public void Delete(T t)
        {
            _dataContext.Remove(t);
            _dataContext.SaveChanges();
        }
        public T Get(int id)
        {
            return _dataContext.Set<T>().Find(id);
        }
        public List<T> ListAll()
        {
            return _dataContext.Set<T>().ToList();
        }
        public bool Check(Func<T, bool> predicate)
        {
            return _dataContext.Set<T>().Any(predicate);
        }
    }
}
