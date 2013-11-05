using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using DdnsViaYandexApi.Services;
using log4net;

namespace DdnsViaYandexApi
{
    public class DdnsViaYandexApi
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DdnsViaYandexApi));

        public static string Start(string appPath)
        {
            Log.Info("Start application");

            var currentIp = GetCurrentIp();
            Log.Info("Your IP is: " + currentIp);

            ChangeIpForDomainInfoCsv(currentIp, appPath);

            Log.Info("Stop application");
            return currentIp;
        }

        private static string GetCurrentIp()
        {
            var client = new WebClient();

            var result = string.Empty;
            try
            {
                result = client.DownloadString("http://dns-ip.ru/services/getipservice.asmx/GetIp");
            }
            catch (Exception ex)
            {
                try
                {
                    result = client.DownloadString("http://israspa.ru/getip/getip.php");
                }
                catch (Exception)
                {
                    Log.Error("Oops! We couldn't get an IP address:" + ex);
                    return result;
                }
                Log.Error("Oops! We couldn't get an IP address:" + ex);
                return result;
            }

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(result);
            var myCurrentIp = xmlDocument.GetElementsByTagName("string")[0].InnerText;

            return myCurrentIp;
        }

        public static string GetLatestVersion()
        {
            var client = new WebClient();

            var result = string.Empty;
            try
            {
                result = client.DownloadString("http://dns-ip.ru/services/getversionddns.asmx/GetAppVersion");
            }
            catch (Exception ex)
            {
                Log.Error("Oops! We couldn't get a version for updating:" + ex);
                return result;
            }

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(result);
            var latestVersion = xmlDocument.GetElementsByTagName("string")[0].InnerText;

            return latestVersion;
        }

        private static void ChangeIpForDomainInfoCsv(string myIp, string appPath)
        {
            var query = "SELECT * FROM DomainInfo";
            var dataTable = DatabaseService.ExecuteSql(appPath, query);

            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                var row = dataTable.Rows[i];
                var subdomain = string.IsNullOrWhiteSpace((string)row["SubDomain"]) ? "@" : (string)row["SubDomain"];

                Thread.Sleep(300);
                var recordId = GetDomainRecord(
                    "https://pddimp.yandex.ru/nsapi/get_domain_records.xml?" +
                    "token=" + (string)row["Token"] +
                    "&domain=" + (string)row["Domain"], subdomain);

                Thread.Sleep(300);
                EditARecord("https://pddimp.yandex.ru/nsapi/edit_a_record.xml?" +
                            "token=" + (string)row["Token"] +
                            "&domain=" + (string)row["Domain"] +
                            "&subdomain=" + subdomain +
                            "&record_id=" + recordId +
                            //"&[ttl=<время жизни записи>]" +
                            "&content=" + myIp);
            }
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

        private static void EditARecord(string uri)
        {
            var client = new WebClient();
            try
            {
                var result = client.DownloadString(uri);

                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(result);
                var isOk = xmlDocument.GetElementsByTagName("error")[0].InnerText;
                if (isOk.Equals("ok")) 
                    Log.Info("A-record successfully edited");
                else 
                    Log.Warn("Attempt to edited A-record was unsuccessful");

            }
            catch (Exception ex)
            {
               Log.Error("Oops! We couldn't edit A-record" + ex);
            }
        }
    }
}