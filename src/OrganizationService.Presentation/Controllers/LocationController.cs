using Microsoft.AspNetCore.Mvc;
using OrganizationService.Application.Locations.AddLocation;
using OrganizationService.Contracts.Requests;
using OrganizationService.Presentation.EndpointResults;

namespace OrganizationService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        [HttpPost]
        public async Task<EndpointResult<Guid>> Create(
            [FromServices] AddLocationHandler handler,
            [FromBody] AddLocationRequest request,
            CancellationToken cancellationToken)
        {
            var command = request.ToCommand();

            return await handler.Handle(command, cancellationToken);
        }
    }
}
