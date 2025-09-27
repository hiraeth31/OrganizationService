using Microsoft.AspNetCore.Mvc;
using OrganizationService.Application.Locations.AddLocation;
using OrganizationService.Contracts.Requests;

namespace OrganizationService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(
            [FromServices] AddLocationHandler handler,
            [FromBody] AddLocationRequest request,
            CancellationToken cancellationToken)
        {
            var command = request.ToCommand();

            var result = handler.Handle(command, cancellationToken);



            return Ok();
        }
    }
}
