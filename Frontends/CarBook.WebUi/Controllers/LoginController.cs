using CarBook.DTO.LoginDtos;
using CarBook.WebUi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace CarBook.WebUi.Controllers;

public class LoginController : Controller
{
    IHttpClientFactory _httpClientFactory;

    public LoginController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignIn(LoginResultDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7149/api/SignIn", content);

        if (response.IsSuccessStatusCode)
        {
            var jsondata = await response.Content.ReadAsStringAsync();
            var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsondata, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            if (tokenModel != null)
            {
                JwtSecurityTokenHandler handler = new();
                var token = handler.ReadJwtToken(tokenModel.Token);
                var username = token.Claims.First(claim => claim.Type == "Username").Value;

                var claims = token.Claims.ToList();
                if (tokenModel.Token != null)
                {
                    claims.Add(new Claim("accessToken", tokenModel.Token));
                    var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                    var authProps = new AuthenticationProperties
                    {
                        ExpiresUtc = tokenModel.ExpireDate,
                        IsPersistent = true
                    };
                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    TempData["userId"] = userId;
                    TempData["userName"] = username;
                    return RedirectToAction("Index", "Car");
                }
            }
        }
        return View();
    }
}
