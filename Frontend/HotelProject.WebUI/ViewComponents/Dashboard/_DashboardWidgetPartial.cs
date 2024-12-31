using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();//istemci oluştur
            var responseMessage = await client.GetAsync("http://localhost:5048/api/DashboardWidgets/StaffCount");//swaggerdaki URL. listeleme için GetAsync
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.staffcount = jsonData;

            var client2 = _httpClientFactory.CreateClient();//istemci oluştur
            var responseMessage2 = await client2.GetAsync("http://localhost:5048/api/DashboardWidgets/BookingCount");//swaggerdaki URL. listeleme için GetAsync
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.bookingcount = jsonData2;

            var client3 = _httpClientFactory.CreateClient();//istemci oluştur
            var responseMessage3 = await client3.GetAsync("http://localhost:5048/api/DashboardWidgets/AppUserCount");//swaggerdaki URL. listeleme için GetAsync
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.appusercount = jsonData3;

            var client4 = _httpClientFactory.CreateClient();//istemci oluştur
            var responseMessage4 = await client4.GetAsync("http://localhost:5048/api/DashboardWidgets/RoomCount");//swaggerdaki URL. listeleme için GetAsync
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.roomcount = jsonData4;
            return View();

        }
    }
}
