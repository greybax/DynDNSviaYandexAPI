using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using log4net;

namespace YandexDynDNS
{
    public class DdnsViaYandexApi
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DdnsViaYandexApi));

        public static void Main(string[] args)
        {
            Log.Info("Start application");
            var currentIp = GetCurrentIp();
            Log.Info("Your IP is: " + currentIp);

            ChangeIpForDomainInfoCsv(currentIp);

            Log.Info("Stop application");
        }

        private static string GetCurrentIp()
        {
            var client = new WebClient();

            //var result = client.DownloadString("http://israspa.ru/getip/getip.php");
            //return result;

            var result = string.Empty;
            try
            {
                result = client.DownloadString("http://dns-ip.ru/services/getipservice.asmx/GetIp");
            }
            catch (Exception ex)
            {
                Log.Error("Oops! We couldn't get an IP address:" + ex);
                return result;
            }

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
                var subdomain = string.IsNullOrWhiteSpace(domainList[1]) ? "@" : domainList[1];

                Thread.Sleep(300);
                var recordId = GetDomainRecord(
                    "https://pddimp.yandex.ru/nsapi/get_domain_records.xml?" +
                    "token=" + domainList[0] +
                    "&domain=" + domainList[2], subdomain);

                Thread.Sleep(300);
                EditARecord("https://pddimp.yandex.ru/nsapi/edit_a_record.xml?" +
                            "token=" + domainList[0] +
                            "&domain=" + domainList[2] +
                            "&subdomain=" + subdomain +
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

        private static string GetDomainRecord(string uri, string subdomain)
        {
            var client = new WebClient();
            try
            {
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
                    let subdomainXml = item.Attribute("subdomain").Value
                    where type.Equals("A") && subdomainXml == subdomain
                    select item)
                {
                    var recordId = item.Attribute("id").Value;
                    Log.Info("URI: " + uri + " Subdomain: " + subdomain + " RecordId: " + recordId);
                    return recordId;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Oops! We couldn't get domain record by recordId" + ex);
                return string.Empty;
            }

            return string.Empty;
        }

        private static bool EditARecord(string uri)
        {
            var client = new WebClient();
            try
            {
                var result = client.DownloadString(uri);

                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(result);
                var isOk = xmlDocument.GetElementsByTagName("error")[0].InnerText;
                var isSuccessfull = isOk.Equals("ok");
                if (isSuccessfull) 
                    Log.Info("A-record successfully edited");
                else 
                    Log.Warn("Attempt to edited A-record was unsuccessful");

                return isSuccessfull;
            }
            catch (Exception ex)
            {
               Log.Error("Oops! We couldn't edit A-record" + ex);
               return false;
            }
        }
    }
}
