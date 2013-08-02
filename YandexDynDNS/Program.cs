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
            var domain = GetDomainFromFile();
            var token = GetTokenFromFile();

            var recordId = GetDomainRecord(
                            "https://pddimp.yandex.ru/nsapi/get_domain_records.xml?" +
                            "token=" + token +
                            "&domain=" + domain);

            EditARecord("https://pddimp.yandex.ru/nsapi/edit_a_record.xml?" +
                           "token=" + token +
                           "&domain=" + domain +
                           //"&subdomain=www." + domain +
                           "&record_id=" + recordId +
                           //"&[ttl=<время жизни записи>]" +
                           "&content=" + currentIp);
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

        private static string GetDomainFromFile()
        {
            return GetValueFromFile("domain.txt");
        }

        private static string GetTokenFromFile()
        {
            return GetValueFromFile("token.txt");
        }

        private static string GetValueFromFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                var value = reader.ReadToEnd();

                return value;
            }
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
