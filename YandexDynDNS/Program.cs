using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace YandexDynDNS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var currentIp = GetCurrentIp();

            ChangeIpForDomainInfoCsv(currentIp);
        }

        private static string GetCurrentIp()
        {
            var client = new WebClient();
            var result = client.DownloadString("http://dns-ip.ru/services/getipservice.asmx/GetIp");

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(result);
            var myCurrentIp = xmlDocument.GetElementsByTagName("string")[0].InnerText;

            return myCurrentIp;
        }

        private static void ChangeIpForDomainInfoCsv(string myIp)
        {
            string[] allLines = File.ReadAllLines("domainInfo.csv");

            foreach (var line in allLines)
            {
                var domainList = ParseCsvRow(line);

                var recordId = GetDomainRecord(
                "https://pddimp.yandex.ru/nsapi/get_domain_records.xml?" +
                "token=" + domainList[0] +
                "&domain=" + domainList[2]);

                EditARecord("https://pddimp.yandex.ru/nsapi/edit_a_record.xml?" +
                               "token=" + domainList[0] +
                               "&domain=" + domainList[2] +
                               (string.IsNullOrWhiteSpace(domainList[1]) ? string.Empty : "&subdomain=" + domainList[1]) +
                               "&record_id=" + recordId +
                               //"&[ttl=<время жизни записи>]" +
                               "&content=" + myIp);
            }
        }

        public static string[] ParseCsvRow(string r)
        {
            string[] c;
            var resp = new List<string>();
            bool cont = false;
            string cs = "";

            c = r.Split(new[] { ',' }, StringSplitOptions.None);

            foreach (string y in c)
            {
                string x = y;

                if (cont)
                {
                    // End of field
                    if (x.EndsWith("\""))
                    {
                        cs += "," + x.Substring(0, x.Length - 1);
                        resp.Add(cs);
                        cs = "";
                        cont = false;
                        continue;
                    }
                    // Field still not ended
                    cs += "," + x;
                    continue;
                }

                // Fully encapsulated with no comma within
                if (x.StartsWith("\"") && x.EndsWith("\""))
                {
                    if ((x.EndsWith("\"\"") && !x.EndsWith("\"\"\"")) && x != "\"\"")
                    {
                        cont = true;
                        cs = x;
                        continue;
                    }

                    resp.Add(x.Substring(1, x.Length - 2));
                    continue;
                }

                // Start of encapsulation but comma has split it into at least next field
                if (x.StartsWith("\"") && !x.EndsWith("\""))
                {
                    cont = true;
                    cs += x.Substring(1);
                    continue;
                }

                // Non encapsulated complete field
                resp.Add(x);
            }

            return resp.ToArray();
        }

        private static string GetDomainRecord(string uri)
        {
            var client = new WebClient();
            var xml = client.DownloadString(uri);

            var doc = XDocument.Parse(xml);

            var nodes = doc.Element("page")
                .Element("domains")
                .Element("domain")
                .Element("response")
                .Elements("record");

            foreach (var item in
                    from item in nodes 
                    let type = item.Attribute("type").Value 
                    where type.Equals("A") 
                    select item)
            {
                return item.Attribute("id").Value;
            }

            return string.Empty;
        }

        private static bool EditARecord(string uri)
        {
            var client = new WebClient();
            var result = client.DownloadString(uri);

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(result);
            var isOk = xmlDocument.GetElementsByTagName("error")[0].InnerText;

            return isOk.Equals("ok");
        }
    }
}
