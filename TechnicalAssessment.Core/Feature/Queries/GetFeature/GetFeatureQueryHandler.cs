using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Exceptions;
using TechnicalAssessment.Core.Interfaces;

namespace TechnicalAssessment.Core.Feature.Queries.GetFeature
{
    public class GetFeatureQueryHandler
    {
        private readonly IFeatureRepository _repository;

        public GetFeatureQueryHandler(IFeatureRepository repository)
        {
            _repository = repository;
        }

        public GetFeatureResponse Handle(GetFeatureQuery query)
        {
            var feature = _repository.Get(query.email, query.featureName);
            if(feature == null)
            {
                throw new NotFoundException();
            }

            return new GetFeatureResponse
            {
                canAccess = feature.Enabled
            };
        }
    }
}
