using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.BrandCommands
{
    public class UpdateBrandCommand
    {
        public int id { get; set; }
        public string name { get; set; }

        public UpdateBrandCommand(int id)
        {
            this.id = id;
        }
    }
}
