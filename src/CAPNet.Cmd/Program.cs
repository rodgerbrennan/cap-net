using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.ServiceModel.Channels;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using CAPNet.Models;

namespace CAPNet.Cmd
{
    class Program
    {
        static async Task Main()
        {
            await ReadNWS();
        }

        static async Task ReadNWS()
        {
            List<Alert> alerts = new List<Alert>();

            var uri = "http://alerts.weather.gov/cap/us.php?x=0";

            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");

                var response = await httpClient.GetAsync(uri);
                var stream = await response.Content.ReadAsStreamAsync();

                using (var reader = XmlReader.Create(stream))
                {
                    var feed = SyndicationFeed.Load(reader);

                    var items = feed.Items;

                    foreach (var item in items)
                    {
                        var alert = await GetAlerts(item.Id);
                        alerts.AddRange(alert);

                    }
                }



                if (!alerts.Any())
                    Console.WriteLine("No alerts");
                else if (alerts.Count == 1)
                    Console.WriteLine("1 alert");
                else
                    Console.WriteLine("{0} alerts", alerts.Count);

                foreach (var alert in alerts.Where(a => a.Info.Any(i => i.Severity <= Severity.Severe)))
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Sender: " + alert.Sender);
                    Console.WriteLine("Note: " + alert.Note);

                    foreach (var info in alert.Info)
                    {
                        Console.WriteLine("  *******");
                        Console.WriteLine("  " + info.Headline);
                        Console.WriteLine("  Effective: " + info.Effective);
                        Console.WriteLine("  Expires: " + info.Expires);
                        Console.WriteLine("  Severity: " + info.Severity);

                        foreach (var area in info.Areas)
                        {
                            Console.WriteLine("  Area: " + area.Description);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("End of process.");
            Console.ReadLine();
        }

        public static async Task<IEnumerable<Alert>> GetAlerts(string url)
        {
            IEnumerable<Alert> alertList = null;
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();

                using (var reader = XmlReader.Create(stream))
                {
                    XDocument doc = XDocument.Load(reader);
                    alertList = XmlParser.Parse(doc);
                }


                return alertList;

            }
            catch (Exception ex)
            {
                string message = String.Format("GET failed. Received HTTP {0}", ex);
                throw new ApplicationException(message);
            }

        }
    }
}
