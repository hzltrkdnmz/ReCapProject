using Business.Concreate;
using DataAccess.Concreate.EntityFramework;
using DataAccess.Concreate.InMemory;
using Entities.Concreate;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //MinPrice();

            //CarDto();
            ColorTest();

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Color addColor = new Color() { ColorId = 4, ColorName = "Mor" };
          
            colorManager.Add(addColor);

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine( "CarName: "+car.CarName+ " Color: " + car.ColorName + " Brand: " + car.BrandName+"DailyPrice: "+car.DailyPrice);


            }
        }

        private static void MinPrice()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetByDailyPrice(0))
            {
                Console.WriteLine("Description: " + car.Description + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " DailyPrice: " + car.DailyPrice + " ModelYear: " + car.ModelYear);


            }
        }
    }
}
