using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace XlsxDoJson
{
    public static class PrevodJson
    {
        public static void DataDoJson(List<Klient> data)
        {
            try
            {
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText("zakazky.json", json);
                Console.WriteLine("Uloženo do zakazky.json");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Chyba při ukládání dat do JSON: {ex.Message}");
            }
        }
    }
}