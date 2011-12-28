using System;
using System.Threading;
using Blitz.CSharp.JsonModels.CurlRequests;
using Blitz.CSharp.JsonModels.Rush;

namespace Blitz.CSharp
{
    public class Rush : BlitzBase
    {

        public event Action<Rush, RushStatusResult> RushStatusChanged;

        public Rush(string userName, string apiKey) : base(userName, apiKey)
        {
            
        }

        public CurlResponse Execute(RushRequest request)
        {
            var wc = this.GetAuthenticatedWebClient();
            var curlResponse = wc.PostObjectAsJson<CurlResponse>(executeUrl, request);

            if (RushStatusChanged != null)
            {
                PollStatus(curlResponse);
            }

            return curlResponse;
        }

        private void PollStatus(CurlResponse curlResponse)
        {
            var completed = false;
            while (!completed)
            {
                var jobStatusResult = this.GetRushStatus(curlResponse.job_id);
                completed = jobStatusResult.status != "running" && jobStatusResult.status != "queued";
                RushStatusChanged(this, jobStatusResult);
                Thread.Sleep(2000);
            }
        }


        public RushStatusResult GetRushStatus(string jobId)
        {
            var wc = GetAuthenticatedWebClient();
            var statusUrl = jobsUrl + jobId + "/status";
            var rushStatusResult = wc.DownLoadJsonObject<RushStatusResult>(statusUrl);

            return rushStatusResult;
        }
    }
}