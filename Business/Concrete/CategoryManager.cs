using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category t)
        {
            _categoryDal.Add(t);
        }

        public void Delete(Category t)
        {
           _categoryDal.Delete(t);
        }

        public Category Get(int id)
        {
           return _categoryDal.Get(id);
        }

        public List<Category> ListAll()
        {
            return _categoryDal.ListAll();
        }

        public void Update(Category t)
        {
            _categoryDal.Update(t);
        }

        public List<Category> True()
        {
            return _categoryDal.True();
        }
    }
}
