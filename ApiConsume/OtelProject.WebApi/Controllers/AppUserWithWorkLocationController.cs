using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtelProject.WebApi.Models;

namespace OtelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserWithWorkLocationController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserWithWorkLocationController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        //İNCLUDE METODU KULLANDIK
        [HttpGet]
        public IActionResult Index()
        {
            //var values = _appUserService.TUsersListWithWorkLocaitons();
            Context context = new Context();
            var values = context.Users.Include(x => x.WorkLocation).Select(y => new AppUserWorkLocationViewModel
            {
                Name=y.Name,
                Surname=y.Surname,
                WorkLocationId=y.WorkLocationId,
                WorkLocationName=y.WorkLocation.WorkLocationName,
                ImageUrl=y.ImageUrl,
                City=y.City
            }).ToList();
            return Ok(values);
        }
    }
}
