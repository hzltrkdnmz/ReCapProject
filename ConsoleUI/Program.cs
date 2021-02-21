using Business.Concreate;
using DataAccess.Concreate.EntityFramework;
using DataAccess.Concreate.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            MinPrice();

            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Description: " + car.Description + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " DailyPrice: " + car.DailyPrice + " ModelYear: " + car.ModelYear);


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
