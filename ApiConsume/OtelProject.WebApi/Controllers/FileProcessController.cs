using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OtelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileProcessController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> UploadFile([FromForm] IFormFile file)
        {

            var filename = Guid.NewGuid() + Path.GetExtension(file.FileName);//dosya adı benzersiz olsun diye guid kullandık
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Files/" + filename);//dosyanın kaydedileceği yolu tanımla
            var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            return Created("", file);
        }
    }
}
