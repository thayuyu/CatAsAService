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
        public async Task<Cat?> GetCat(string Filter, int? Brightness, int? Saturation, int? Hue, int? Red, int? Green, int? Blue) 
        {
            Cat? cat = new();

            HttpClient client = new();

            client.BaseAddress = new Uri(Address);

            string uri = $"?type={type}&width={width}&height={height}&json=true";

            if (Filter == "custom")
            {
                uri += $"&filter={Filter}";

                if (Red == null || Green == null || Blue == null)
                {
                    uri += $"&brightness={Brightness}&saturation={Saturation}&hue={Hue}";
                }
                else if (Brightness == null || Saturation == null || Hue == null)
                {
                    uri += $"&r={Red}&g={Green}&b={Blue}";
                }
            }
            else if (Filter == "mono" || Filter == "negate")
            {
                uri += $"&filter={Filter}";
            }

            HttpResponseMessage response = await client.GetAsync(requestUri: uri);

            if (response.IsSuccessStatusCode) 
            { 
                cat = await response.Content.ReadFromJsonAsync<Cat>();
            }

            return cat;
        }
    }
}