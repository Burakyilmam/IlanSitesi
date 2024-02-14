using DataAccess.Abstract;
using DataAccess.Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CarRepository : GenericRepository<Car> , ICarDal
    {
        private readonly DataContext _context;
        public CarRepository(DataContext dataContext) : base(dataContext)
        {
            _context = dataContext;
        }
        public List<Car> Include()
        {
            return _context.Cars.Include(x=>x.Category).Where(x => x.Status == true).ToList();
        }
    }
}
