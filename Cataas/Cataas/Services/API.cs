namespace Cataas.Services
{
    public class API
    {
        private string Address = "https://cataas.com/cat";
        private const string type = "square";
 
        // width and height 
        private const int width = 500;
        private const int height = 500;

        // Constructor
        public API()
        {

        }

        // Get a random cat with no filters
        public string GetRandomCat()
        {
            Address = $"{Address}?type={type}&width={width}&height={height}";
            return Address;
        }


        public string GetFilterCat(string Filter, string? Says, int? Brightness, int? Saturation, int? Hue, int? Red, int? Green, int? Blue) 
        {


            if (Says == null)
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
            }
            else if (Says != null)
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
            }
            return "https://i.pinimg.com/736x/24/57/04/24570452fbe5544aaf0cae82cab47449.jpg";
        }
    }
}