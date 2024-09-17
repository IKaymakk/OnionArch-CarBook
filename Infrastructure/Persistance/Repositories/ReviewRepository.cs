using CarBook.Application.Inferfaces;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CarBookContext _context;
        public ReviewRepository(CarBookContext context)
        {
            _context = context;
        }
        public async Task<Rezervasyon> UserReservationCheck(int id, int carid)
        {
            var value = await _context.Rezervasyons.Where(x => x.CarId == carid && x.AppUserId == id).FirstOrDefaultAsync();
            if (value == null)
            {
                throw new Exception("Rezervasyon Kaydı Bulunamadı");
            }
            else
            {
                return value;
            }
        }

    }
}
