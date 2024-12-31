using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AppUserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class AdminUsersController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AdminUsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            //var client = _httpClientFactory.CreateClient();//istemci oluştur
            //var responseMessage = await client.GetAsync("http://localhost:5048/api/AppUser");//swaggerdaki URL. listeleme için GetAsync
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultAppUserDto>>(jsonData);//Modeli burada çağır. json türündeki datayı deserilize edilir
            //    return View(values);
            //}
            return View();
        }
        public async Task<IActionResult> UserList()
        {
            var client = _httpClientFactory.CreateClient();//istemci oluştur
            var responseMessage = await client.GetAsync("http://localhost:5048/api/AppUser");//swaggerdaki URL. listeleme için GetAsync
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAppUserListDto>>(jsonData);//Modeli burada çağır. json türündeki datayı deserilize edilir
                return View(values);
            }
            return View();
        }

    }
}
