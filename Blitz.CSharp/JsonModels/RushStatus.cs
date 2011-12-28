namespace Blitz.CSharp.JsonModels.Rush
{
    public class Step
    {
        public int a { get; set; }
        public double c { get; set; }
        public double d { get; set; }
        public int e { get; set; }
        public int t { get; set; }
    }

    public class Timeline
    {
        public Step[] steps { get; set; }
        public double duration { get; set; }
        public double timestamp { get; set; }
        public int errors { get; set; }
        public int executed { get; set; }
        public int total { get; set; }
        public int volume { get; set; }
        public double txbytes { get; set; }
        public double rxbytes { get; set; }
        public int timeouts { get; set; }
    }

    public class Result
    {
        public string region { get; set; }
        public Timeline[] timeline { get; set; }
    }

    public class RushStatusResult
    {
        public string _id { get; set; }
        public bool ok { get; set; }
        public string status { get; set; }
        public Result result { get; set; }
    }
}
