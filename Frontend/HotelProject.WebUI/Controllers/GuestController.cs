using HotelProject.WebUI.Dtos.GuestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{

    public class GuestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GuestController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//istemci oluştur
            var responseMessage = await client.GetAsync("http://localhost:5048/api/Guest");//swaggerdaki URL. listeleme için GetAsync
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);//Modeli burada çağır. json türündeki datayı deserilize edilir
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddGuest()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGuest(CreateGuestDto model)
        {

            //Fluent valdiation kuralı sağlanıyorsa;
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();//istemci oluştur
            var jsonData = JsonConvert.SerializeObject(model);//modelden gelen veriyi jsona dönüştür yani serilize et
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//utf8 formatına dönüştür
            var responseMessage = await client.PostAsync("http://localhost:5048/api/Guest", stringContent);//eklemek için PostAsync
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
                return View();
            }
            else { return View(); }

        }
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();//istemci oluştur
            var responseMessage = await client.DeleteAsync($"http://localhost:5048/api/Guest/{id}");//silmek  için DeleteAsync
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]//güncellenecek veriyi getirme
        public async Task<IActionResult> UpdateGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();//istemci oluştur
            var responseMessage = await client.GetAsync($"http://localhost:5048/api/Guest/{id}");//güncellenecek veriyi getirmek için GetAsync
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateGuestDto>(jsonData);//Modeli burada çağır. json türündeki datayı deserilize edilir
                return View(values);
            }
            return View();
        }
        [HttpPost]//veriyi güncelleme
        public async Task<IActionResult> UpdateGuest(UpdateGuestDto model)
        {
            //Fluent valdiation kuralı sağlanıyorsa;
            if (ModelState.IsValid)
            {

                var client = _httpClientFactory.CreateClient();//istemci oluştur
                var jsonData = JsonConvert.SerializeObject(model);//modelden gelen veriyi jsona dönüştür yani serilize et
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//utf8 formatına dönüştür
                var responseMessage = await client.PutAsync("http://localhost:5048/api/Guest/", stringContent);//güncellemek  için PutAsync
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            else { return View(); }
        }
    }
}
