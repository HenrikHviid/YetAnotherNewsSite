using System.Net;

namespace YetAnotherNewsSite.Models
{
    public class Fetch
    {
        private const string API_KEY = "307546ea-92f0-406e-bff9-891ef14289b0";
        public string GetNews(string searchCriteria)
        {
            string data = "";
            
            using (WebClient wc = new WebClient())
            {
                data = wc.DownloadString($"http://webhose.io/filterWebContent?token={API_KEY}&format=json&sort=crawled&q={searchCriteria}");
            }

            return data;
        }

    }
}
