namespace Blitz.CSharp.JsonModels.CurlRequests
{
    public class LoginResponse
    {
        public bool ok { get; set; }
        public string api_key { get; set; }
    }

    public class Variables
    {
    }

    public class Step
    {
        public object[] headers { get; set; }
        public object[] cookies { get; set; }
        public Variables variables { get; set; }
        public string url { get; set; }
    }

    
    public class CurlResponse
    {
        public bool ok { get; set; }
        public string job_id { get; set; }
        public string status { get; set; }
        public string region { get; set; }
    }
    
    public class Interval
    {
        public int iterations { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public int duration { get; set; }
    }

    public class Pattern
    {
        public int iterations { get; set; }
        public Interval[] intervals { get; set; }
    }

    public class RushRequest 
    {
        public Pattern pattern { get; set; }
        public Step[] steps { get; set; }
        public string text { get; set; }
        public string region { get; set; }
     
    }
    
    public class SprintRequest 
    {
        public Step[] steps { get; set; }
        public string text { get; set; }
        public string region { get; set; }
    }


}
