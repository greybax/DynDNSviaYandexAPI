using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DdnsViaYandexApi.Services
{
    public class CsvService
    {
        public static void ImportFrom(string filePath, string appPath)
        {
            var allLines = File.ReadAllLines(filePath);

            foreach (var line in allLines)
            {
                var domainList = ParseCsvRow(line);
                var query = string.Format("INSERT INTO DomainInfo Values ('{0}','{1}','{2}', null)",
                    domainList[0], domainList[1], domainList[2]);
                DatabaseService.ExecuteSql(appPath, query);
            }
        }

        public static void ExportTo(string filePath, string appPath)
        {
            var query = string.Format("select * from DomainInfo");
            var dataTable = DatabaseService.ExecuteSql(appPath, query);
            var result = new StringBuilder();
            const string template = "{0},{1},{2}\n";

            for (var i = 0; i < dataTable.Rows.Count; i++)
            {
                var row = dataTable.Rows[i];
                result.AppendFormat(template, row["Token"], row["SubDomain"], row["Domain"]);
            }

            File.WriteAllText(filePath, result.ToString());
        }

        private static string[] ParseCsvRow(string line)
        {
            string[] words;
            var responce = new List<string>();
            bool cont = false;
            string cs = "";

            words = line.Split(new[] { ',', ';' }, StringSplitOptions.None);

            foreach (var word in words)
            {
                string item = word;

                if (cont)
                {
                    // End of field
                    if (item.EndsWith("\""))
                    {
                        cs += "," + item.Substring(0, item.Length - 1);
                        responce.Add(cs);
                        cs = "";
                        cont = false;
                        continue;
                    }
                    // Field still not ended
                    cs += "," + item;
                    continue;
                }

                // Fully encapsulated with no comma within
                if (item.StartsWith("\"") && item.EndsWith("\""))
                {
                    if ((item.EndsWith("\"\"") && !item.EndsWith("\"\"\"")) && item != "\"\"")
                    {
                        cont = true;
                        cs = item;
                        continue;
                    }

                    responce.Add(item.Substring(1, item.Length - 2));
                    continue;
                }

                // Start of encapsulation but comma has split it into at least next field
                if (item.StartsWith("\"") && !item.EndsWith("\""))
                {
                    cont = true;
                    cs += item.Substring(1);
                    continue;
                }

                // Non encapsulated complete field
                responce.Add(item);
            }

            return responce.ToArray();
        }
    }
}