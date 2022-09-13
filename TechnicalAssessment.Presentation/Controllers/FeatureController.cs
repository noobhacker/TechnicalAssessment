using Microsoft.AspNetCore.Mvc;
using TechnicalAssessment.Core.Features.Commands.UpdateFeature;
using TechnicalAssessment.Core.Features.Queries.GetFeature;

namespace TechnicalAssessment.Presentation.Controllers
{
    public class FeatureController : ControllerBase
    {
        private readonly GetFeatureQueryHandler _getHandler;
        private readonly UpdateFeatureCommandHandler _updateHandler;

        public FeatureController(GetFeatureQueryHandler getHandler, 
            UpdateFeatureCommandHandler updateHandler)
        {
            _getHandler = getHandler;
            _updateHandler = updateHandler;
        }

        public ActionResult<GetFeatureResponse> Get(string email, string featureName)
        {
            return Ok(_getHandler.Handle(new GetFeatureQuery
            {
                 email = email,
                 featureName = featureName
            }));
        }

        public ActionResult Post(UpdateFeatureCommand request)
        {
            _updateHandler.Handle(request);

            return Ok();
        }
    }
}
