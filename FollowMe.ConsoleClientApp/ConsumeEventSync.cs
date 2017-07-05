using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.ConsoleClientApp
{
    public class ConsumeEventSync
    {
        public void GetAllCategories()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:55390/api/"); //URI  
                Console.WriteLine(Environment.NewLine + result);
            }
        }
    }
}
