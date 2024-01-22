using Cataas.Model;
using System.Net.Http.Json;
using System.Security.AccessControl;

namespace Cataas.Services
{
    public class API
    {
        // main URL
        private string Address = "https://cataas.com/cat";

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