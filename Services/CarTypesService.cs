using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CarInventoryAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CarInventoryAPI.Services
{
    public class CarTypesService: ICarTypeSercvice
    {
        private readonly CarsInventoryDbContext _dbContext;


        //Get cars list
        public async Task<IEnumerable<CarTypes>> ListCarTypeAsync()
        {
            return await _dbContext.CarTypes.ToListAsync();
        }


        //Create a car
          public async Task<Guid> CreateCarTypeAsync(string carType, int quantity, IsElectric isElectric)
        {
             // Make sure the name is unique
        if (await _dbContext.CarTypes.AnyAsync(x => x.CarType.Equals(carType)))
            throw new Exception("Car type already exist");

            var newCar= new CarTypes
            {
                Id = Guid.NewGuid(),
                CarType = carType,
                IsElectric = isElectric,
                Quantity = quantity
            };

             _dbContext.CarTypes.Add(newCar);
             await _dbContext.SaveChangesAsync();

             return newCar.Id;
        }


        //Get a car by ID
        public async Task<CarTypes> GetCarTypeAsync(Guid id)
        {
            var car = await _dbContext.CarTypes
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            
            if(car == null) throw  new Exception("Car type already exist");

            JsonSerializer.Serialize(car);

            return car;
            
        }

        //Delete a car
          public async Task DeleteCarTypeAsync(Guid id)
        {
            var foundcar = await _dbContext.CarTypes
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if(foundcar == null) throw new Exception("Car type already exist");

            _dbContext.CarTypes.Remove(foundcar);
            await _dbContext.SaveChangesAsync();

        }


        //Update a car
         public async Task UpdateCarTypeAsync(Guid id, string carType, int quantity, IsElectric isElectric)
        {
            var foundCar = await _dbContext.CarTypes
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if(foundCar == null) throw new Exception("Car type already exist");
            
            foundCar.CarType = carType;
            foundCar.Quantity = quantity;
            foundCar.IsElectric = isElectric;

            await _dbContext.SaveChangesAsync();

        }
    }
}