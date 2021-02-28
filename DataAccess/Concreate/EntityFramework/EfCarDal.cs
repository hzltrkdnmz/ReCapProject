using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentalContext context=new RentalContext())
            {
                var result = from cr in context.Cars
                             join cl in context.Colors
                             on cr.ColorId equals cl.ColorId
                             join br in context.Brands
                             on cr.BrandId equals br.BrandId
                             select new CarDetailDto 
                             {  
                                 CarId = cr.CarId, CarName = cr.CarName, 
                                 ColorId = cl.ColorId, ColorName = cl.ColorName,
                                 BrandId=br.BrandId, BrandName=br.BrandName,
                                 DailyPrice=cr.DailyPrice

                             };
                return result.ToList();
            }
        }
    }
}
