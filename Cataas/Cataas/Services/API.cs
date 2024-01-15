using Cataas.Model;
using System.Net.Http.Json;
using System.Security.AccessControl;

namespace Cataas.Services
{
    public class API
    {
        // main URL
        private string Address = "https://cataas.com/cat";
        // constant variables
        // type of the picture
        private const string type = "square";
        // width and height 
        private int width = 500;
        private const int height = 500;

        // Constructor
        public API() { }

        public async Task<Cat?> GetCat() 
        {
            Cat? cat = new();

            HttpClient client = new();

            client.BaseAddress = new Uri(Address);
                        
            HttpResponseMessage response = await client.GetAsync(requestUri: "?json=true");

            if (response.IsSuccessStatusCode) 
            { 
                cat = await response.Content.ReadFromJsonAsync<Cat>();
            }

            return cat;
        }
    }
}