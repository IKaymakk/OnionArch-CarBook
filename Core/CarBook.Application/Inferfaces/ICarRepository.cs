using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Inferfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsListWithBrand();
        Task<List<Car>> GeTLast5CarsWithBrand();
        Task<Car> GetCarByIdAsync(int carid);
    }
}
