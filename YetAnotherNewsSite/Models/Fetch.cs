using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webhoseio;

namespace YetAnotherNewsSite.Models
{
    public class Fetch
    {


        public void GetNews()
        {
            var client = new WebhoseClient(token: "307546ea-92f0-406e-bff9-891ef14289b0");
            var queryParams = new Dictionary { "q": "\"stock market\" language:english", "sort": "crawled" } 
        var output = await client.QueryAsync("filterWebContent", queryParams);
    
        Console.WriteLine(output["posts"][0]["text"]);
    Console.WriteLine(output["posts"][0]["published"]);

    
// Get the next batch of posts

    output = await output.GetNextAsync();
        Console.WriteLine(output["posts"][0]["thread"]["site"]);
        }
    }

