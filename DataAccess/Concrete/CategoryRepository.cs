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
    public class CategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext dataContext) : base(dataContext)
        {
            _context = dataContext;
        }
        public List<Category> True()
        {
            return _context.Categories.Where(x => x.Status == true).ToList();
        }
    }
}
