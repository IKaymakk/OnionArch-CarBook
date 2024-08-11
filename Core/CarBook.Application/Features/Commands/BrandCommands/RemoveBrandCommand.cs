using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.BrandCommands
{
    public class RemoveBrandCommand
    {
        public int  id { get; set; }

        public RemoveBrandCommand(int id)
        {
            this.id = id;
        }
    }
}
