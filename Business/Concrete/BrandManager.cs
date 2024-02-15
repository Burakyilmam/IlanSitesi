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
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand t)
        {
            _brandDal.Add(t);
        }

        public bool Check(Func<Brand, bool> predicate)
        {
           return _brandDal.Check(predicate);
        }

        public void Delete(Brand t)
        {
            _brandDal.Delete(t);
        }

        public Brand Get(int id)
        {
            return _brandDal.Get(id);
        }

        public List<Brand> ListAll()
        {
           return _brandDal.ListAll();
        }

        public void Update(Brand t)
        {
            _brandDal.Update(t);
        }
    }
}
