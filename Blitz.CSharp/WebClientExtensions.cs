using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Blitz.CSharp
{
    public static class WebClientExtensions
    {
        public static T DownLoadJsonObject<T>(this WebClient webClient, string url)
        {
            var resultString = webClient.DownloadString(url);
            return JsonConvert.DeserializeObject<T>(resultString);
        }

        public static T PostObjectAsJson<T>(this WebClient webClient, string url, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var bytes = Encoding.Default.GetBytes(json);
            var response = webClient.UploadData(url, "POST", bytes);
            var responseString = Encoding.Default.GetString(response);
            return JsonConvert.DeserializeObject<T>(responseString);

        }
    }
}