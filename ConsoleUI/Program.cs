using Business.Concreate;
using Core.Utilities.Results;
using DataAccess.Concreate.EntityFramework;
using DataAccess.Concreate.InMemory;
using Entities.Concreate;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //MinPrice();

            //CarDto();
            //ColorTest();

            //AddUser();

            //GetUser();

            AddCustomer();

            GetCustomer();
        }

        private static void GetCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            if (result.Success)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine(customer.UserId + " " + customer.CompanyName);

                }
            }
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            Customer customer = new Customer() { CustomerId = 2, CompanyName = "Company1", UserId = 1 };
            customerManager.Add(customer);
        }

        private static void GetUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            if (result.Success)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.FirstName + " " + user.LastName);
                }

            }

           
        }

        private static void AddUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User() { UserId = 1, FirstName = "Hazel", LastName = "Türkdönmez", Email = "hzl@hzl.com", Password = "1234" };
            userManager.Add(user);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Color addColor = new Color() { ColorId = 5, ColorName = "Yeşil" };
          
            colorManager.Add(addColor);

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("CarName: " + car.CarName + " Color: " + car.ColorName + " Brand: " + car.BrandName + "DailyPrice: " + car.DailyPrice);


                }

            }
           
        }

        private static void MinPrice()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetByDailyPrice(0).Data)
            {
                Console.WriteLine("Description: " + car.Description + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " DailyPrice: " + car.DailyPrice + " ModelYear: " + car.ModelYear);


            }
        }
    }
}
