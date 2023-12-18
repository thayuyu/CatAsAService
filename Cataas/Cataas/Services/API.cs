namespace Cataas.Services
{
    public class API
    {
        private string Address = "https://cataas.com/cat";
        // text to be added to picture
        private string says { get; set; }

        private string type = "square";
        // filters (mono, negate, custom)
        private string filter { get; set; }
        // custom filters: -100 - 100
        private int brightness { get; set; }
        private int saturation { get; set; }
        // custom filters: -180 - 180
        private int hue { get; set; }
        // custom filters: 0 - 255
        private int red { get; set; }
        private int green { get; set; }
        private int blue { get; set; }
        // width and height 
        private int width = 500;
        private int height = 500;

        // Constructor
        public API()
        {

        }

        public string GetRandomCat()
        {
            return Address;
        }
    }
}
