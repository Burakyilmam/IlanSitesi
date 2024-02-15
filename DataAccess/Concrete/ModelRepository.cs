using DataAccess.Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ModelRepository : GenericRepository<Model>
    {
        private readonly DataContext _context;
        public ModelRepository(DataContext dataContext) : base(dataContext)
        {
            _context = dataContext;
        }
    }
}
