using Newtonsoft.Json;

namespace Produtos.Dominio
{
    public class Produto
    {
        public string id { get; set; }
        public string name { get; set; } = string.Empty;
        public Data data { get; set; }
    }
    public class Data
    {
        public string color { get; set; } = string.Empty;

        [JsonProperty("capacity GB")]
        public int capacityGB { get; set; }
        public double? price { get; set; }
        public string Capacity { get; set; } = string.Empty;

        [JsonProperty("Screen size")]
        public double? Screensize { get; set; }
    }
}
