using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class RentACar
{
    public int RentACarId { get; set; }
    [ForeignKey("Location")]
    public int PickUpLocationId { get; set; }
    public Location Location { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; }
    public bool IsAvaible { get; set; }
}
