using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;
using System.Net.Http.Headers;
namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult> Index(string cityname)
        {
			if (!string.IsNullOrEmpty(cityname))
			{
				List<BookingApiLocationSearchViewModel> model = new List<BookingApiLocationSearchViewModel>();

				var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityname}&locale=en-gb"),
					Headers =
	{
		{ "x-rapidapi-key", "11f750908fmshbd8bd077cfe2094p1274d7jsn9c2ba2c7a449" },
		{ "x-rapidapi-host", "booking-com.p.rapidapi.com" },
	},
				};
				using (var response = await client.SendAsync(request))
				{
					response.EnsureSuccessStatusCode();
					var body = await response.Content.ReadAsStringAsync();
					model = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
					return View(model.Take(1).ToList());
				}
			}
			else
			{
				List<BookingApiLocationSearchViewModel> model = new List<BookingApiLocationSearchViewModel>();

				var client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=paris&locale=en-gb"),
					Headers =
	{
		{ "x-rapidapi-key", "11f750908fmshbd8bd077cfe2094p1274d7jsn9c2ba2c7a449" },
		{ "x-rapidapi-host", "booking-com.p.rapidapi.com" },
	},
				};
				using (var response = await client.SendAsync(request))
				{
					response.EnsureSuccessStatusCode();
					var body = await response.Content.ReadAsStringAsync();
					model = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
					return View(model.Take(1).ToList());
				}
			}
			}
			
		}
    }

