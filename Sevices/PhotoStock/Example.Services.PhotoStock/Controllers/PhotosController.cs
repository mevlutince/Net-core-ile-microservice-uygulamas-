using Example.Services.PhotoStock.Dtos;
using Example.Shared.BaseController;
using Example.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Example.Services.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo,CancellationToken cancellationToken)
        {// cancellationToken fotograf yüklenirken tarayıcı kapanırsa bir hata oluşmasını nleyecek
            if (photo!=null && photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);
                using(var stream =new FileStream(path, FileMode.Create))
                {
                    await photo.CopyToAsync(stream,cancellationToken);
                }

                // http://wwww.photostock.api.com/photos/xxxxx.jpg şeklinde olacak
                var returnPath = "photos/" + photo.FileName;

                PhotoDto photoDto = new PhotoDto() { Url = returnPath };
                return CreateActionResultInstance(Response<PhotoDto>.Success(photoDto, 200));
            }
            return CreateActionResultInstance(Response<PhotoDto>.Fail("photo is empty", 400));
        }
        public  IActionResult PhotoDelete(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwwroot/photos/", photoUrl);
            if (!System.IO.File.Exists(path))
            {
                return CreateActionResultInstance(Response<NoContent>.Fail("photo not gound", 404));
            }
            System.IO.File.Delete(path);
            return CreateActionResultInstance(Response<NoContent>.Success(204));
        }
    }
}
