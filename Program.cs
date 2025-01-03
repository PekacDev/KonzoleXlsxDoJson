﻿using ClosedXML.Excel;
using Newtonsoft.Json;

namespace XlsxDoJson
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Náčtení xlsx

                string xlsxCesta = "Priklad-zakazky_do_JSON.xlsx";
                var workbook = new XLWorkbook(xlsxCesta);
                var worksheet = workbook.Worksheet(1);

                var dataXlsx = ExcelData.NacteniDat(worksheet);

                // Vytvoření a uložení do JSON
                PrevodJson.DataDoJson(dataXlsx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba při spuštění aplikace: {ex.Message}");
            }
        }
    }
}