using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.CarDtos
{
    public class AddCarReviewDto
    {
        public int carId { get; set; }
        public int appUserId { get; set; }
        public string customerName { get; set; }
        public string? customerImage { get; set; }
        public string comment { get; set; }
        public int ratingValue { get; set; }
        public DateTime reviewDate { get; set; }

    }
}
