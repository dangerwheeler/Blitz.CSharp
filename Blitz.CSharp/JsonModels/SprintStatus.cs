namespace Blitz.CSharp.JsonModels.SprintStatus
{

    public class Response
    {
        public string line { get; set; }
        public string content { get; set; }
        public string message { get; set; }
        public int status { get; set; }
        public Headers headers { get; set; }
    }

    public class Headers
    {
        public string X_Powered_By { get; set; }
        public string Transfer_Encoding { get; set; }
        public string Date { get; set; }
        public string Content_Type { get; set; }
        public string Server { get; set; }
        public string Cache_Control { get; set; }
        public string X_AspNet_Version { get; set; }
        public string Connection { get; set; }
    }

    public class Step
    {
        public double duration { get; set; }
        public Response response { get; set; }
        public double connect { get; set; }
        public Request request { get; set; }
    }

    public class Headers2
    {
        public string X_User_ID { get; set; }
        public string X_Powered_By { get; set; }
        public string X_User_IP { get; set; }
        public string User_Agent { get; set; }
        public string Host { get; set; }
    }

    public class Request
    {
        public string line { get; set; }
        public string method { get; set; }
        public string url { get; set; }
        public string content { get; set; }
        public Headers2 headers { get; set; }
    }


    public class Result
    {
        public string region { get; set; }
        public double duration { get; set; }
        public Step[] steps { get; set; }
    }

    public class SprintStatusResult
    {
        public string _id { get; set; }
        public bool ok { get; set; }
        public string status { get; set; }
        public Result result { get; set; }
        public string created_at { get; set; }
    }
}
