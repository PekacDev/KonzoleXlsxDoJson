namespace XlsxDoJson
{
    public class Klient
    {
        public string Nazev { get; set; }
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
