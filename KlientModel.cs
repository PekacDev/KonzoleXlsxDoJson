using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace XlsxDoJson
{
    public class Klient
    {
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Nazev { get; set; } = null;
        [DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ICO { get; set; }
        public List<Zakazka> Zakazky { get; set; }
    }

    public class Zakazka
    {
        public string Nazev { get; set; }
        public List<VyrobeneKusy> VyrobeneKusy { get; set; }

    }

    public class VyrobeneKusy
    {
        public string Obdobi { get; set; }
        public int Pocet { get; set; }

    }
}
