using Microsoft.AspNetCore.Mvc;
using TechnicalAssessment.Core.Features.Commands.AddFeature;
using TechnicalAssessment.Core.Features.Queries.GetFeature;

namespace TechnicalAssessment.Presentation.Controllers
{
    [ApiController]
    [Route("feature")]
    public class FeatureController : ControllerBase
    {
        private readonly GetFeatureQueryHandler _getHandler;
        private readonly AddFeatureCommandHandler _updateHandler;

        public FeatureController(GetFeatureQueryHandler getHandler,
            AddFeatureCommandHandler updateHandler)
        {
            _getHandler = getHandler;
            _updateHandler = updateHandler;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GetFeatureResponse> Get(string email, string featureName)
        {
            return Ok(_getHandler.Handle(new GetFeatureQuery
            {
                email = email,
                featureName = featureName
            }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status304NotModified)]
        public ActionResult Post(AddFeatureCommand request)
        {
            _updateHandler.Handle(request);

            return Ok();
        }
    }
}
