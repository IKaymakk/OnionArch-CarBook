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

        public async Task AddCarFeatureToCar(CarFeature carFeature)
        {
            var value = await _context.CarFeatures
                .Where(x => x.CarId == carFeature.CarId && x.FeatureId == carFeature.FeatureId)
                .FirstOrDefaultAsync();
            if(value is null)
            {
                await _context.CarFeatures.AddAsync(carFeature);
                await _context.SaveChangesAsync();
            }
        }

        public void AvaibleStatusToFalse(int id)
        {
            var values = _context.CarFeatures
                .Where(x => x.CarFeatureId == id)
                .FirstOrDefault();
            _context.Remove(values);
            _context.SaveChanges();
        }
        public void AvaibleStatusToTrue(int id)
        {
            var values = _context.CarFeatures
                .Where(x => x.CarFeatureId == id)
                .FirstOrDefault();
            values.Avaible = true;
            _context.SaveChanges();
        }
        public void CreateCarFeatureByCar(CarFeature carFeature)
        {
            _context.CarFeatures.Add(carFeature);
            _context.SaveChanges();

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
