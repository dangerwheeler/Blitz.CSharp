using System;
using System.Threading;
using Blitz.CSharp.JsonModels.CurlRequests;
using Blitz.CSharp.JsonModels.SprintStatus;

namespace Blitz.CSharp
{
    public class Sprint : BlitzBase
    {
        public event Action<Sprint, SprintStatusResult> SprintStatusChanged;

        public Sprint(string userName, string apiKey) : base(userName,apiKey)
        {
            
        }

        public CurlResponse Execute(SprintRequest sprintRequest)
        {
            var wc = GetAuthenticatedWebClient();

            var curlResponse = wc.PostObjectAsJson<CurlResponse>(executeUrl, sprintRequest);
            if (SprintStatusChanged != null)
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
                var jobStatusResult = this.GetSprintStatus(curlResponse.job_id);
                completed = jobStatusResult.status != "running" && jobStatusResult.status != "queued";
                SprintStatusChanged(this, jobStatusResult);
                Thread.Sleep(2000);
            }
        }

        public SprintStatusResult GetSprintStatus(string jobId)
        {
            var wc = GetAuthenticatedWebClient();
            var statusUrl = jobsUrl + jobId + "/status";
            var sprintStatusResult = wc.DownLoadJsonObject<SprintStatusResult>(statusUrl);

            return sprintStatusResult;
        }
        
    }
}