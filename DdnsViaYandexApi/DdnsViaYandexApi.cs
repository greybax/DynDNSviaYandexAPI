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

        public static string Start(string appPath, out string logString)
        {
            Log.Info("Start application");

            logString = string.Empty;
            logString += DateTime.Now + ": " + "Start application";
            logString += Environment.NewLine;

            var currentIp = GetCurrentIp(ref logString);
            Log.Info("Your IP is: " + currentIp);

            logString += DateTime.Now + ": " + "Your IP is: " + currentIp;
            logString += Environment.NewLine;

            ChangeIpForDomainInfoCsv(currentIp, appPath, ref logString);

            return currentIp;
        }

        private static string GetCurrentIp(ref string logString)
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

                    Log.Error("Oops! We couldn't get an IP address: " + ex);

                    logString += DateTime.Now + ": " + "Oops! We couldn't get an IP address: " + ex;
                    logString += Environment.NewLine;

                    return result;
                }
                Log.Error("Oops! We couldn't get an IP address: " + ex);

                logString += DateTime.Now + ": " + "Oops! We couldn't get an IP address: " + ex;
                logString += Environment.NewLine;
                return result;
            }

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(result);
            var myCurrentIp = xmlDocument.GetElementsByTagName("string")[0].InnerText;

            return myCurrentIp;
        }

        public static string GetLatestVersion(ref string logString)
        {
            var client = new WebClient();

            var result = string.Empty;
            try
            {
                result = client.DownloadString("http://dns-ip.ru/services/getversionddns.asmx/GetAppVersion");
            }
            catch (Exception ex)
            {
                Log.Error("Oops! We couldn't get a version for updating: " + ex);

                logString += DateTime.Now + ": " + "Oops! We couldn't get a version for updating: " + ex;
                logString += Environment.NewLine;

                return result;
            }

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(result);
            var latestVersion = xmlDocument.GetElementsByTagName("string")[0].InnerText;

            return latestVersion;
        }

        private static void ChangeIpForDomainInfoCsv(string myIp, string appPath, ref string logString)
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
                    "&domain=" + (string)row["Domain"], subdomain, ref logString);

                Thread.Sleep(300);
                EditARecord("https://pddimp.yandex.ru/nsapi/edit_a_record.xml?" +
                            "token=" + (string)row["Token"] +
                            "&domain=" + (string)row["Domain"] +
                            "&subdomain=" + subdomain +
                            "&record_id=" + recordId +
                            //"&[ttl=<время жизни записи>]" +
                            "&content=" + myIp, ref logString);
            }
        }

        private static string GetDomainRecord(string uri, string subdomain, ref string logString)
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

                    logString += DateTime.Now + ": " + "URI: " + uri + " Subdomain: " + subdomain + " RecordId: " + recordId;
                    logString += Environment.NewLine;

                    return recordId;
                }
            }
            catch (Exception ex)
            {
                Log.Error("Oops! We couldn't get domain record by recordId: " + ex);

                logString += DateTime.Now + ": " + "Oops! We couldn't get domain record by recordId: " + ex;
                logString += Environment.NewLine;

                return string.Empty;
            }

            return string.Empty;
        }

        private static void EditARecord(string uri, ref string logString)
        {
            var client = new WebClient();
            try
            {
                var result = client.DownloadString(uri);

                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(result);
                var isOk = xmlDocument.GetElementsByTagName("error")[0].InnerText;
                if (isOk.Equals("ok"))
                {
                    Log.Info("A-record successfully edited");

                    logString += DateTime.Now + ": " + "A-record successfully edited";
                    logString += Environment.NewLine;
                }
                else
                {
                    Log.Warn("Attempt to edited A-record was unsuccessful");

                    logString += DateTime.Now + ": " + "Attempt to edited A-record was unsuccessful";
                    logString += Environment.NewLine;
                }

            }
            catch (Exception ex)
            {
               Log.Error("Oops! We couldn't edit A-record: " + ex);

               logString += DateTime.Now + ": " + "Oops! We couldn't edit A-record: " + ex;
               logString += Environment.NewLine;
            }
        }
    }
}