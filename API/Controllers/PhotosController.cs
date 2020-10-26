using System.Threading.Tasks;
using Core.PhotoUpload;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PhotosController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Photo>> UploadPhoto([FromForm] AddOnePhoto.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("{id}/setavatar")]
        public async Task<ActionResult<Unit>> SetAvatar(string id)
        {
            return await Mediator.Send(new SetAvatar.Command() {Id = id});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeletePhoto(string id)
        {
            return await Mediator.Send(new DeleteOnePhoto.Command() {Id = id});
        }
    }
}
