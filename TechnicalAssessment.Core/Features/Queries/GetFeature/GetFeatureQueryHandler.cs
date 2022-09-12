using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Exceptions;
using TechnicalAssessment.Core.Interfaces;

namespace TechnicalAssessment.Core.Features.Queries.GetFeature
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
            var enabled = _repository.GetEnabled(query.email, query.featureName);

            return new GetFeatureResponse
            {
                canAccess = enabled
            };
        }
    }
}
