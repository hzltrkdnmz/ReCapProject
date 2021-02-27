using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concreate
{
    public class BrandManager : IBrandService
    {
        IBrandDal brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            this.brandDal = brandDal;
        }

        public List<Brand> GetAll()
        {
            return brandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return brandDal.Get(b => b.BrandId == brandId);
        }
    }
}
