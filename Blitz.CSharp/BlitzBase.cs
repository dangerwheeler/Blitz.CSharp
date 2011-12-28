using System.Collections.Specialized;
using System.Net;
using Blitz.CSharp.JsonModels.CurlRequests;

namespace Blitz.CSharp
{
    public abstract class BlitzBase
    {
        private readonly string apiKey;
        private readonly string userName;
        private string authenticatedApiKey;
        
        protected const string executeUrl = "http://blitz.io/api/1/curl/execute";
        protected const string jobsUrl = "http://blitz.io/api/1/jobs/";

        protected BlitzBase(string userName, string apiKey)
        {
            this.apiKey = apiKey;
            this.userName = userName;
            this.authenticatedApiKey = null;
        }

        public void Abort(string jobId)
        {
            var wc = GetAuthenticatedWebClient();
            var abortUrl = jobsUrl + jobId + "/abort";
            wc.UploadData(abortUrl, "PUT", new byte[0]); 
        }

        protected WebClient GetAuthenticatedWebClient()
        {
            this.AuthenticateIfNeeded();
            var wc = new WebClient();
            wc.Headers.Add(GetHeaders());
            return wc;
        }
        
        private void AuthenticateIfNeeded()
        {
            if (IsAuthenticated()) return;
            Login();
        }
        
        private bool IsAuthenticated()
        {
            return !string.IsNullOrEmpty(authenticatedApiKey);
        }

        private void Login()
        {
            var wc = new WebClient();
            var headers = GetHeaders();
            wc.Headers.Add(headers);
            var login = wc.DownLoadJsonObject<LoginResponse>("http://blitz.io/login/api");
            this.authenticatedApiKey = login.api_key;
        }

        private NameValueCollection GetHeaders()
        {
            var headers = new NameValueCollection { { "X-API-User", userName }, { "X-API-Key", authenticatedApiKey ?? apiKey }, { "X-API-Client", "csharp" } };
            return headers;
        }
    }
}
