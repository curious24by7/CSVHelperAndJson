using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Collections;

namespace CSVHelperAndJson
{
    class ReadCSVWriteCSV
    {
        public static void ImplementCSVToJSON()
        {
            string importFilePath = @"C:\Users\soham\source\repos\CSVHelperAndJson\CSVHelperAndJson\Utility\Addresses.csv";
            string exportFilePath = @"C:\Users\soham\source\repos\CSVHelperAndJson\CSVHelperAndJson\Utility\export.csv";
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecord<AddressData>().ToList();
                Console.WriteLine("Read data successfully from addresses csv.");
                foreach (AddressData addressData in records)
                {
                    Console.WriteLine("\t" + addressData.firstname);
                    Console.WriteLine("\t" + addressData.lastname);
                    Console.WriteLine("\t" + addressData.address);
                    Console.WriteLine("\t" + addressData.city);
                    Console.WriteLine("\t" + addressData.code);
                    Console.WriteLine("\t" + addressData.state);
                }
                Console.WriteLine("*****************************Reading from csv file and write to csv file********************");
                Json.Net.JsonSerializer serializer = new Json.Net.JsonSerializer();
                using (StreamWriter sw = new StreamWriter(exportFilePath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }
            }
        }
    }
}       
