using CarBook.DTO.StatsDtos;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace CarBook.WebApi.Hubs;

public class CarHub : Hub
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CarHub(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task SendCarCount()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7149/api/Stats/CarCount");
        if (response.IsSuccessStatusCode)
        {
            var jsondata = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<CountStatsDto>(jsondata);
            await Clients.All.SendAsync("ReceiveCarCount", value.count);
        }
        else
        {
            await Clients.All.SendAsync("ReceiveCarCount", "Hata");
        }
    }
}
