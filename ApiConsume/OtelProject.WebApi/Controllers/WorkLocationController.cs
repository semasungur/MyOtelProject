using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OtelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService _workLocation;

        public WorkLocationController(IWorkLocationService workLocationService)
        {
            _workLocation = workLocationService;
        }


        /* Swagger yapısı*/
        [HttpGet] /*listeleme*/
        public IActionResult WorkLocationList()
        {
            var values = _workLocation.TGetList();
            return Ok(values);
        }
        [HttpPost]/*ekleme*/
        public IActionResult AddWorkLocation(WorkLocation workLocation)
        {
            _workLocation.TInsert(workLocation);
            return Ok();
        }
        [HttpDelete("{id}")]/*silme*/
        public IActionResult DeleteWorkLocation(int id)
        {
            var values = _workLocation.TGetByID(id);
            _workLocation.TDelete(values);
            return Ok();
        }
        [HttpPut]/*güncelleme*/
        public IActionResult UpdateWorkLocation(WorkLocation workLocation)
        {
            _workLocation.TUpdate(workLocation);
            return Ok();
        }
        [HttpGet("{id}")] /*id ile listeleme*/
        public IActionResult GetWorkLocation(int id)
        {
            var values = _workLocation.TGetByID(id);
            return Ok(values);
        }
    }
}
