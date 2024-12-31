using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OtelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        /* Swagger yapısı*/
        //[HttpGet] /*listeleme*/
        //public IActionResult UserListWithLocation()
        //{

        //    var values = _appUserService.TUserListWithWorkLocaiton();
        //    return Ok(values);
        //}
        [HttpGet] /*listeleme*/
        public IActionResult AppUserList()
        {
            var values = _appUserService.TGetList();
            return Ok(values);
        }
    }
}
