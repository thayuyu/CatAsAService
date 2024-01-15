using Cataas.Model;
using System.Net.Http.Json;

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

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Filter">Mono, Negate or Custom</param>
        /// <param name="Brightness">Brightness of the picture</param>
        /// <param name="Saturation">Saturation of the picture</param>
        /// <param name="Hue">Hue of the picture</param>
        /// <param name="Red">RGB option</param>
        /// <param name="Green">RGB option</param>
        /// <param name="Blue">RGB option</param>
        /// <returns>Object "Cat"</returns>
        public async Task<Cat?> GetFilterCat(string Filter, int? Brightness, int? Saturation, int? Hue, int? Red, int? Green, int? Blue) 
        {
            Cat? cat = new();
            HttpClient client = new();
            client.BaseAddress = new Uri(Address);

            if (Filter == "custom")
            { 
                if (Red == null || Green == null || Blue == null)
                { 
                    HttpResponseMessage response = await client.GetAsync(requestUri: $"?type={type}&width={width}&height={height}&filter={Filter}&brightness={Brightness}&saturation={Saturation}&hue={Hue}&json=true");
                    if (response.IsSuccessStatusCode)
                    {
                        cat = await response.Content.ReadFromJsonAsync<Cat>();
                    }
                }
                else if (Brightness == null || Saturation == null || Hue == null)
                {
                    HttpResponseMessage response = await client.GetAsync(requestUri: $"?type={type}&width={width}&height={height}&filter={Filter}&r={Red}&g={Green}&b={Blue}&json=true");
                    if (response.IsSuccessStatusCode)
                    {
                        cat = await response.Content.ReadFromJsonAsync<Cat>();
                    }
                }
            }
            else if (Filter == "mono" || Filter == "negate")
            {
                HttpResponseMessage response = await client.GetAsync(requestUri: $"?type={type}&width={width}&height={height}&filter={Filter}&json=true");

                if (response.IsSuccessStatusCode)
                {
                    cat = await response.Content.ReadFromJsonAsync<Cat>();
                }
            }
            else if (Filter == "standard")
            {
                 HttpResponseMessage response = await client.GetAsync(requestUri: $"?type={type}&width={width}&height={height}&json=true");

                 if (response.IsSuccessStatusCode)
                 {
                    cat = await response.Content.ReadFromJsonAsync<Cat>();
                 }
            }
            return cat;
        }
    }
}