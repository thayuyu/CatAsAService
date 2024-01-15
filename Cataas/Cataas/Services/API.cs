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

        // Get a random cat without filters
        public string GetRandomCat()
        {
            
            return $"{Address}?type={type}&width={width}&height={height}";
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Filter">Mono, Negate or Custom</param>
        /// <param name="Says">Text that will be shown on the picture</param>
        /// <param name="Brightness">Brightness of the picture</param>
        /// <param name="Saturation">Saturation of the picture</param>
        /// <param name="Hue">Hue of the picture</param>
        /// <param name="Red">RGB option</param>
        /// <param name="Green">RGB option</param>
        /// <param name="Blue">RGB option</param>
        /// <returns>Link of a random filtered cat picture</returns>
        public string GetFilterCat(string Filter, string? Says, int? Brightness, int? Saturation, int? Hue, int? Red, int? Green, int? Blue) 
        {
            if (width == 500)
            {
                width = 501;
            }
            else
            {
                width = 500;
            }
            if (Says == "")
            {
                if (Filter == "custom")
                {
                    if (Red == null || Green == null || Blue == null) 
                    {
                        return Address + $"?type={type}&width={width}&height={height}&filter={Filter}&brightness={Brightness}&saturation={Saturation}&hue={Hue}";
                    }
                    else if (Brightness == null || Saturation == null || Hue == null)
                    {
                        return Address + $"?type={type}&width={width}&height={height}&filter={Filter}&r={Red}&g={Green}&b={Blue}";
                    }
                }
                else if (Filter == "mono" || Filter == "negate")
                {
                    return Address + $"?type={type}&width={width}&height={height}&filter={Filter}";
                }
                else if (Filter == "standard")
                {
                    GetRandomCat();
                }
            }
            else if (Says != "")
            {
                if (Filter == "custom")
                {
                    if (Red == null || Green == null || Blue == null)
                    {
                        return Address + $"/says/{Says}" + $"?type={type}&width={width}&height={height}&filter={Filter}&brightness={Brightness}&saturation={Saturation}&hue={Hue}";
                    }
                    else if (Brightness == null || Saturation == null || Hue == null)
                    {
                        return Address + $"/says/{Says}" + $"?type={type}&width={width}&height={height}&filter={Filter}&r={Red}&g={Green}&b={Blue}";
                    }
                }
                else if (Filter == "mono" || Filter == "negate")
                {
                    return Address + $"/says/{Says}" + $"?type={type}&width={width}&height={height}&filter={Filter}";
                }
                else if (Filter == "standard")
                {
                    GetRandomCat();
                }
            }
            return "https://i.pinimg.com/736x/24/57/04/24570452fbe5544aaf0cae82cab47449.jpg";
        }
    }
}