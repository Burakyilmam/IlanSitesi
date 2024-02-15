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
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car t)
        {
            _carDal.Add(t);
        }

        public bool Check(Func<Car, bool> predicate)
        {
            return _carDal.Check(predicate);
        }

        public void Delete(Car t)
        {
            _carDal.Delete(t);
        }

        public Car Get(int id)
        {
            return _carDal.Get(id);
        }

        public List<Car> Include()
        {
            return _carDal.Include();
        }

        public List<Car> ListAll()
        {
            return _carDal.ListAll();
        }

        public void Update(Car t)
        {
            _carDal.Update(t);
        }
    }
}
