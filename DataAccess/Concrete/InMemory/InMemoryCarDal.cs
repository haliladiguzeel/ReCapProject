using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        //Bellekten data'ları alıyoruz normalde serverden almamız gerekiyor (Sql server gibi)
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,Brandld=1,ColorId=1,ModelYear=1998,DailyPrice=1000,Description="Nissan GTR R34"},
                new Car{Id=2,Brandld=1,ColorId=1,ModelYear=1994,DailyPrice=1250,Description="Toyota Supra"},
                new Car{Id=3,Brandld=2,ColorId=1,ModelYear=2020,DailyPrice=300,Description="Renault Clio"},
                new Car{Id=4,Brandld=2,ColorId=1,ModelYear=2020,DailyPrice=500,Description="BMW M4"},
                new Car{Id=5,Brandld=3,ColorId=1,ModelYear=2019,DailyPrice=470,Description="Mercedes C180"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }



        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.Brandld = car.Brandld;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
        public List<Car> GetByld(int brandId)
        {
            return _cars.Where(c => c.Brandld == brandId).ToList();
        }
    }
}
