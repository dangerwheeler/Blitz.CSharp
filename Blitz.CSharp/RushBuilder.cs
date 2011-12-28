using System;
using System.Collections.Generic;
using Blitz.CSharp.JsonModels.CurlRequests;

namespace Blitz.CSharp
{
    public class RushBuilder
    {
        private List<Step> steps;
        private List<Interval> intervals;
        private string region;
        
        public RushBuilder FromRegion(string region)
        {
            this.region = region;
            return this;
        }

        public RushBuilder WithInterval(int startUsers, int endUsers, TimeSpan duration)
        {
            var interval = new Interval
                               {
                                   duration = (int) duration.TotalSeconds, 
                                   start = startUsers, 
                                   end = endUsers,
                                   iterations = 1

                               };
            intervals.Add(interval);
            return this;
        }

        public RushBuilder WithStep(string url)
        {
            var step = new Step {url = url};
            this.steps.Add(step);
            return this;
        }    

        public RushBuilder()
        {
            steps = new List<Step>();
            intervals = new List<Interval>();
        }

        public RushRequest AsRushRequest()
        {
            var request = new RushRequest
                              {
                                  region = this.region,
                                  steps = this.steps.ToArray(),
                                  pattern = new Pattern
                                                {
                                                    intervals = this.intervals.ToArray(),
                                                    iterations = 1
                                                }
                              };
            return request;
        }
    }
}