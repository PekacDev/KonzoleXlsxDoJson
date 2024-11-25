using ClosedXML.Excel;
using System;
using System.Collections.Generic;

namespace XlsxDoJson
{
    public static class ExcelData
    {
        public static List<Klient> NacteniDat(IXLWorksheet worksheet)
        {
            var klienti = new List<Klient>();

            for (int radek = 2; radek <= worksheet.LastRowUsed().RowNumber(); radek++)
            {
                try
                {
                    string nazevKlient = worksheet.Cell(radek, 1).Value.ToString();
                    string icoKlient = worksheet.Cell(radek, 2).Value.ToString();
                    string cisloZakazky = worksheet.Cell(radek, 3).Value.ToString();

                    var zakazka = new Zakazka
                    {
                        Nazev = cisloZakazky,
                        VyrobeneKusy = new List<VyrobeneKusy>()
                    };

                    // Počet kusů
                    for (int sloupce = 4; sloupce <= worksheet.LastColumnUsed().ColumnNumber(); sloupce++)
                    {
                        try
                        {
                            int pocetKusu;
                            if (int.TryParse(worksheet.Cell(radek, sloupce).Value.ToString(), out pocetKusu))
                            {
                                DateTime datum = DateTime.Parse(worksheet.Cell(1, sloupce).Value.ToString());
                                zakazka.VyrobeneKusy.Add(new VyrobeneKusy
                                {
                                    Obdobi = datum.ToString("MM-yyyy"),
                                    Pocet = pocetKusu
                                });
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine($"Chyba při načítání počtu kusů: {ex.Message}");
                        }
                    }

                    // Kontrola klienta
                    var klient = klienti.Find(k => k.Nazev == nazevKlient && k.ICO == icoKlient);

                    // Klient neexistuje
                    if (klient == null)
                    {
                        klient = new Klient
                        {
                            Nazev = nazevKlient,
                            ICO = icoKlient,
                            Zakazky = new List<Zakazka> { zakazka }
                        };
                        klienti.Add(klient);
                    }
                    else
                    {
                        klient.Zakazky.Add(zakazka);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Chyba při načítání řádku: {ex.Message}");
                }
            }

            return klienti;
        }
    }
}