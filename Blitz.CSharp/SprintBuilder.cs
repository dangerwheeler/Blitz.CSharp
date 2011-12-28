using System.Collections.Generic;
using Blitz.CSharp.JsonModels.CurlRequests;

namespace Blitz.CSharp
{
    public class SprintBuilder
    {
        private List<Step> steps;
        private string region;
        
        public SprintBuilder FromRegion(string region)
        {
            this.region = region;
            return this;
        }
        
        public SprintBuilder WithStep(string url)
        {
            var step = new Step { url = url };
            this.steps.Add(step);
            return this;
        }

        public SprintBuilder()
        {
            steps = new List<Step>();
        }

        public SprintRequest AsSprintRequest()
        {
            var request = new SprintRequest
                              {
                                  region = this.region,
                                  steps = this.steps.ToArray()
                              };
            return request;
        }
    }
}