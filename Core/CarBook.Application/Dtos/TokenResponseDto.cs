using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos;

public class TokenResponseDto
{
    public TokenResponseDto(string token,DateTime expireDate)
    {
        ExpireDate = expireDate;
        Token = token;
    }
    public string Token { get; set; }
    public DateTime ExpireDate { get; set; }
}
