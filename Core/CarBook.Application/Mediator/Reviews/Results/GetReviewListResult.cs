using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Reviews.Results
{
    public class GetReviewListResult
    {
        public int ReviewId { get; set; }
        public int CarId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerImage { get; set; }
        public string Comment { get; set; }
        public int RatingValue { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
