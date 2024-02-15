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
    public class ModelManager : IModelService
    {
        private readonly IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public void Add(Model t)
        {
            _modelDal.Add(t);
        }

        public void Delete(Model t)
        {
           _modelDal.Delete(t);
        }

        public Model Get(int id)
        {
            return _modelDal.Get(id);
        }

        public List<Model> ListAll()
        {
            return _modelDal.ListAll();
        }

        public void Update(Model t)
        {
           _modelDal.Update(t);
        }
    }
}
