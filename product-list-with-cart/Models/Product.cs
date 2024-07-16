using Newtonsoft.Json;

namespace product_list_with_cart.Models
{
    public class Product
    {
        [JsonProperty("image")]
        public ImageUrls Image { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    public class ImageUrls
    {
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
        [JsonProperty("mobile")]
        public string Mobile { get; set; }
        [JsonProperty("tablet")]
        public string Tablet { get; set; }
        [JsonProperty("desktop")]
        public string Desktop { get; set; }
    }    
}