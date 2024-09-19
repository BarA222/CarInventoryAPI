using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarInventoryAPI.Models;

namespace CarInventoryAPI.Services
{
    public interface ICarTypeSercvice
    {
        Task<IEnumerable<CarTypes>> ListCarTypeAsync();

         Task<Guid> CreateCarTypeAsync(string carType, int quantity, IsElectric isElectric);

         Task<CarTypes> GetCarTypeAsync(Guid id);

         Task DeleteCarTypeAsync(Guid id);

         Task UpdateCarTypeAsync(Guid id, string carType, int quantity, IsElectric isElectric);
    }
}