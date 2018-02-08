using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace dotnet.Services
{
    public class GoogleServices
    {
        /// &lt;summary>
        /// returns driving distance in miles
        /// &lt;/summary>
        /// &lt;param name="origin">&lt;/param>
        /// &lt;param name="destination">&lt;/param>
        /// &lt;returns>&lt;/returns>
        public static double GetDrivingDistanceInMiles(string origin, string destination)
        {
            string url = @"http://maps.googleapis.com/maps/api/distancematrix/xml?origins=" +
              origin + "&destinations=" + destination +
              "&mode=driving&language=en-EN&units=imperial";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);


            if (xmldoc.GetElementsByTagName("status")[0].ChildNodes[0].InnerText == "OK")
            {
                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                return Convert.ToDouble(distance[0].ChildNodes[1].InnerText.Replace(" mi", ""));
            }

            return 0;
        }

        /// <summary>
        /// returns latitude 
        /// </summary>
        /// <param name="addresspoint"></param>
        /// <returns></returns>
        public static double GetCoordinatesLat(string addresspoint)
        {
            using (var client = new WebClient())
            {
                string seachurl = "http://maps.google.com/maps/geo?q='" + addresspoint + "'&output=csv";
                string[] geocodeInfo = client.DownloadString(seachurl).Split(',');
                return (Convert.ToDouble(geocodeInfo[2]));
            }
        }

        /// <summary>
        /// returns longitude 
        /// </summary>
        /// <param name="addresspoint"></param>
        /// <returns></returns>
        public static double GetCoordinatesLng(string addresspoint)
        {
            using (var client = new WebClient())
            {
                string seachurl = "http://maps.google.com/maps/geo?q='" + addresspoint + "'&output=csv";
                string[] geocodeInfo = client.DownloadString(seachurl).Split(',');
                return (Convert.ToDouble(geocodeInfo[3]));
            }
        }
    }
}
