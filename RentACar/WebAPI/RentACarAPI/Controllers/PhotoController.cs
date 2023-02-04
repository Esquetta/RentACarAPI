using Application.Featues.Photos.Commands.CreatePhoto;
using Application.Featues.Photos.Commands.DeletePhoto;
using Application.Featues.Photos.Commands.UpdatePhoto;
using Application.Featues.Photos.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace RentACarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PhotoController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreatePhotoCommand createPhotoCommand)
        {
            CreatedPhotoDto createdPhotoDto = await Mediator.Send(createPhotoCommand);
            return Created("", createdPhotoDto);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePhotoCommand updatePhotoCommand)
        {
            UpdatedPhotoDto updatedPhotoDto = await Mediator.Send(updatePhotoCommand);
            return Ok(updatedPhotoDto);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletePhotoCommand deletePhotoCommand)
        {
            DeletedPhotoDto deletedPhotoDto = await Mediator.Send(deletePhotoCommand);
            return Ok(deletedPhotoDto);

        }
    }
}
