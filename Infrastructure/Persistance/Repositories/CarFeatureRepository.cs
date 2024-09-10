using CarBook.Application.Inferfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

     

        public async Task<List<CarFeature>> GetCarFeaturesWithCarAndFeature(int id)
        {
            var values = await _context.CarFeatures
                .AsNoTracking()
                .Include(x => x.Car)
                .ThenInclude(x => x.Brand)
                .Include(x => x.Feature)
                .Where(x => x.CarId == id)
                .ToListAsync();
            return values;
        }
    }
}
