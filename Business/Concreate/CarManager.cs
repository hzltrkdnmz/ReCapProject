using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concreate
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal) 
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarAdded);

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
    
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }
        public IDataResult<List<Car>> GetByDailyPrice(decimal min)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice > min));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length < 3)
            {
                return new ErrorResult();

            }
            _carDal.Add(car);
            return new SuccessResult();
           
        }

        public IResult Delete(Car car)
        {
            if (_carDal.Get(c => c.CarId ==car.CarId)==null)
            {
                return new ErrorResult();
            }
            _carDal.Delete(car);
            return new SuccessResult();
           
          
        }

        public IResult Update(Car car)
        {
            if (_carDal.Get(c => c.CarId == car.CarId) == null)
            {
                return new ErrorResult();
            }
            _carDal.Update(car);
            return new SuccessResult();
            
        }
    }


}
