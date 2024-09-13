using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.AppUser.Results
{
    public class GetCheckAppUserQueryResult
    {
        public int AppUserId { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
        public bool IsExist { get; set; }
    }
}
