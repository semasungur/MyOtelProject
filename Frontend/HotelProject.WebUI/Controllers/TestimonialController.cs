using HotelProject.WebUI.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//istemci oluştur
            var responseMessage = await client.GetAsync("http://localhost:5048/api/Testimonial");//swaggerdaki URL. listeleme için GetAsync
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsonData);//Modeli burada çağır. json türündeki datayı deserilize edilir
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(AddTestimonialViewModel model)
        {
            var client = _httpClientFactory.CreateClient();//istemci oluştur
            var jsonData = JsonConvert.SerializeObject(model);//modelden gelen veriyi jsona dönüştür yani serilize et
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//utf8 formatına dönüştür
            var responseMessage = await client.PostAsync("http://localhost:5048/api/Testimonial", stringContent);//eklemek için PostAsync
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();//istemci oluştur
            var responseMessage = await client.DeleteAsync($"http://localhost:5048/api/Testimonial/{id}");//silmek  için DeleteAsync
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]//güncellenecek veriyi getirme
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();//istemci oluştur
            var responseMessage = await client.GetAsync($"http://localhost:5048/api/Testimonial/{id}");//güncellenecek veriyi getirmek için GetAsync
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTestimonialViewModel>(jsonData);//Modeli burada çağır. json türündeki datayı deserilize edilir
                return View(values);
            }
            return View();
        }
        [HttpPost]//veriyi güncelleme
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialViewModel model)
        {
            var client = _httpClientFactory.CreateClient();//istemci oluştur
            var jsonData = JsonConvert.SerializeObject(model);//modelden gelen veriyi jsona dönüştür yani serilize et
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//utf8 formatına dönüştür
            var responseMessage = await client.PutAsync("http://localhost:5048/api/Staff/", stringContent);//güncellemek  için PutAsync
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
