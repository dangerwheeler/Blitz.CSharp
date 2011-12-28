using System;
using Blitz.CSharp;

namespace Blitz.Console
{
    public class Program
    {
        private const string apiKey = "xxx-xxx-xxx-xxx";
        private const string userName = "jon.doe@foo.com";
        const string url = "http://foo.com";

        private static void Main()
        {

            var sprintRequest = new SprintBuilder()
                .FromRegion("virginia")
                .WithStep(url)
                .AsSprintRequest();

            var rushRequest = new RushBuilder()
                .FromRegion("oregon")
                .WithStep(url)
                .WithInterval(1, 10, TimeSpan.FromSeconds(10))
                .WithInterval(10, 250, TimeSpan.FromSeconds(50))
                .AsRushRequest();


            var sprint = new Sprint(userName, apiKey);
            sprint.SprintStatusChanged += (s, sprintStatus) =>
            {
                System.Console.Out.WriteLine(sprintStatus.status);
            };
            sprint.Execute(sprintRequest);
          
            
            var rush = new Rush(userName, apiKey);
            rush.RushStatusChanged += (r, rushStatus) =>
            {
                System.Console.Out.WriteLine(rushStatus.status);
            };
            rush.Execute(rushRequest);

          
        }

    }
}
