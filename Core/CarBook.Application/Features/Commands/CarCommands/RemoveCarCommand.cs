using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.CarCommands
{
    public class RemoveCarCommand
    {
        public int CarId { get; set; }

        public RemoveCarCommand(int id)
        {
            CarId = id;
        }
    }
}
