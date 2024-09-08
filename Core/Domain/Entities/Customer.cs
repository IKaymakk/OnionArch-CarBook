using Domain.Entities;

namespace CarBook.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public List<RentACarProcess> RentACarProcesses { get; set; }

    }
}