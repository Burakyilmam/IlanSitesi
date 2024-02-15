using DataAccess.Abstract;
using DataAccess.Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class BrandRepository : GenericRepository<Brand>, IBrandDal
    {
        private readonly DataContext _context;
        public BrandRepository(DataContext dataContext) : base(dataContext)
        {
            _context = dataContext;
        }

    }
}
