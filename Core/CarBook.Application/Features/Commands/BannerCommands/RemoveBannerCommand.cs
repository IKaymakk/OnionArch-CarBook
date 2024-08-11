using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.BannerCommands
{
    public class RemoveBannerCommand
    {
        public int id { get; set; }

        public RemoveBannerCommand(int id)
        {
            this.id = id;
        }
    }
}
