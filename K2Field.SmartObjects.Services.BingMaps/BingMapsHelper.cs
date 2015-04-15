using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace K2Field.SmartObjects.Services.BingMaps
{
    public class BingMapsHelper
    {
        public BingMapsHelper()
        { }
        
        public BingMapsHelper(string Key)
        {
            BingMapsKey = Key;
        }

        public string BingMapsKey { set; private get;} 

        private const string BaseUri = "https://dev.virtualearth.net/REST/v1";


        // general query
        //https://dev.virtualearth.net/REST/v1/Locations?query=perth,wa&includeNeighborhood=1&maxResults=1&key=AjQ6xFBNP_8eWx1BuFY7AOkvidc-qI2UaV-m7GwVuCF4a0nhNUitcwP9F0AAFz97

        // context based search
        //https://dev.virtualearth.net/REST/v1/Locations?culture=en-GB&query=Kings%20Road&o=xml&userLocation=51.504360719046616,-0.12600176611298197&o=xml&key=BingMapsKey


        //lat lon serch
        //https://dev.virtualearth.net/REST/v1/Locations/47.64054,-122.12934?o=json&key=AjQ6xFBNP_8eWx1BuFY7AOkvidc-qI2UaV-m7GwVuCF4a0nhNUitcwP9F0AAFz97

        //image metadata
        //http://dev.virtualearth.net/REST/v1/Imagery/Map/AerialWithLabels/47.610,-122.107/10?mapSize=300,300&pushpin=47.610,-122.107&mapLayer=trafficflow&format=jpeg&mapMetadata=1&key=BingMapsKey
        // image
        //http://dev.virtualearth.net/REST/v1/Imagery/Map/AerialWithLabels/47.610,-122.107/10?mapSize=300,300&pushpin=47.610,-122.107&mapLayer=trafficflow&format=jpeg&mapMetadata=0
        //https://msdn.microsoft.com/en-us/library/ff701724.aspx



        public BingResult SearchByLocation(string Query, int MaxResults)
        {
            string uri = string.Format("{0}/Locations?query={1}&includeNeighborhood=1&incl=ciso2&maxResults={2}&key={3}", BaseUri, Query, MaxResults, BingMapsKey);
            BingResult bing = null;
            
            bing = GetBingMapsData(uri);

            return bing; 
        }

        public BingResult SearchByPoint(string Latitude, string Longitude, string IncludeEntityTypes)
        {
            BingResult bing = null;
            string uri = string.Format("{0}/Locations/{1},{2}?o=json&includeNeighborhood=1&incl=ciso2&key={3}", BaseUri, Latitude, Longitude, BingMapsKey);

            if(!string.IsNullOrWhiteSpace(IncludeEntityTypes))
            {
                //Address
                //Neighborhood
                //PopulatedPlace
                //Postcode1
                //AdminDivision1
                //AdminDivision2
                //CountryRegion

                uri += uri + "&includeEntityTypes=" + IncludeEntityTypes;
            }

            bing = GetBingMapsData(uri);

            return bing;
        }

        public DownloadedFile GetMapImageByLocation(string Location, int Zoom, string MapStyle, int Width, int Height, string MapLayer, List<PushPin> Pins, string ImageFormat = "jpeg", bool DeclutterPins = false)
        {
            BingResult bing = SearchByLocation(Location, 1);
            if (bing == null || bing.resourceSets == null || bing.resourceSets.Count() < 1 || bing.resourceSets[0].resources == null || bing.resourceSets[0].resources.Count() < 1)
            {
                return null;
            }
            return GetMapImage(GetImageUrl(bing.resourceSets[0].resources[0].point.coordinates[0].ToString(), bing.resourceSets[0].resources[0].point.coordinates[1].ToString(), Zoom, Width, Height, MapLayer, Pins, MapStyle, ImageFormat, DeclutterPins, 0));
        }

        public BingResult GetMapImageMetadataByLocation(string Location, int Zoom, string MapStyle, int Width, int Height, string MapLayer, List<PushPin> Pins, string ImageFormat = "jpeg", bool DeclutterPins = false)
        {
            BingResult bing = SearchByLocation(Location, 1);
            if (bing == null || bing.resourceSets == null || bing.resourceSets.Count() < 1 || bing.resourceSets[0].resources == null || bing.resourceSets[0].resources.Count() < 1)
            {
                return null;
            }
            return GetMapImageMetadata(GetImageUrl(bing.resourceSets[0].resources[0].point.coordinates[0].ToString(), bing.resourceSets[0].resources[0].point.coordinates[1].ToString(), Zoom, Width, Height, MapLayer, Pins, MapStyle, ImageFormat, DeclutterPins, 1));
        }

        public BingResult GetMapImageMetadata(string uri)
        {
            uri = uri.Replace("mapMetadata=0", "mapMetadata=1");
            return GetBingMapsData(uri);
        }

        public BingResult GetMapImageMetadata(string Latitude, string Longitude, int Zoom, string MapStyle, int Width, int Height, string MapLayer, List<PushPin> Pins, string ImageFormat = "jpeg", bool DeclutterPins = false)
        {
            return GetMapImageMetadata(GetImageUrl(Latitude, Longitude, Zoom, Width, Height, MapLayer, Pins, MapStyle, ImageFormat, DeclutterPins, 1));
        }


        public DownloadedFile GetMapImage(string Latitude, string Longitude, int Zoom, string MapStyle, int Width, int Height, string MapLayer, List<PushPin> Pins, string ImageFormat = "jpeg", bool DeclutterPins = false)
        {                       
            return GetMapImage(GetImageUrl(Latitude, Longitude, Zoom, Width, Height, MapLayer, Pins, MapStyle, ImageFormat, DeclutterPins, 0));

        }

        public DownloadedFile GetMapImage(string uri)
        {
            return  DownloadFile(uri);
        }

        
        public string GetImageUrl(string Latitude, string Longitude, int Zoom, int Width, int Height, string MapLayer, List<PushPin> Pins, string MapStyle="road", string ImageFormat="jpeg", bool DeclutterPins=false, int MapMetadata=0)
        {
            //http://dev.virtualearth.net/REST/v1/Imagery/Map/AerialWithLabels/47.610,-122.107/10?mapSize=300,300&pushpin=47.610,-122.107&mapLayer=trafficflow&format=jpeg&mapMetadata=0



//Aerial
//AerialWithLabels
//Road
//OrdnanceSurvey (london only)
//CollinsBart (london only)

            if (MapStyle == null || !MapStyle.Equals("aerial", StringComparison.CurrentCultureIgnoreCase) || !MapStyle.Equals("aerialwithlabels", StringComparison.CurrentCultureIgnoreCase) 
                || !MapStyle.Equals("road", StringComparison.CurrentCultureIgnoreCase))

            {
                MapStyle = "road";
            }

            if (!string.IsNullOrWhiteSpace(MapLayer) && !MapStyle.Equals("TrafficFlow"))
            {
                MapLayer = "";
            }
            //MapLayer =TrafficFlow

            if (string.IsNullOrWhiteSpace(ImageFormat))
            {
                ImageFormat = "jpeg";
            }
            switch (ImageFormat.ToLower())
            {
                case "jpg":
                case "jpeg":
                    ImageFormat = "jpeg";
                    break;
                case "gif":
                    ImageFormat = "gif";
                    break;
                case "png":
                    ImageFormat = "png";
                    break;
                default:
                    ImageFormat = "jpeg";
                    break;
            }

            if (Zoom < 1 || Zoom > 21)
            {
                // set default zoom if specified incorrectly
                Zoom = 10;
            }

            if(Width < 1)
            {
                Width = 300;
            }
            if (Height < 1)
            {
                Height = 300;
            }

            //highlightEntity - not done

            //http://dev.virtualearth.net/REST/v1/Imagery/Map/AerialWithLabels/47.610,-122.107/10?mapSize=300,300&pushpin=47.610,-122.107&mapLayer=trafficflow&format=jpeg&mapMetadata=0
            string uri = string.Format("{0}/Imagery/Map/{1}/{2},{3}/{4}?mapSize={5},{6}&mapLayer={7}&format={8}&mapMetadata={9}&key={10}", BaseUri, MapStyle, Latitude, Longitude, Zoom, Width, Height, MapLayer, ImageFormat, MapMetadata, BingMapsKey);

            if (Pins != null && Pins.Count > 0)
            {
                string pins = "";
                foreach (PushPin p in Pins)
                {
                    pins = "&pushpin=" + p.Latitude + "," + p.Longitude + ";;" + p.Name;
                }
                uri += pins;
            }

            if (DeclutterPins)
            {
                uri += uri + "&declutterPins=1";
            }

            return uri;

        }


        //string base64 = string.Empty;
        //    if(MapMetadata != 1)
        //    {
        //        bing = new BingResult();                
        //        base64 = DownloadFileToBase64(uri);
        //        bing.imageBase64 = base64;
        //    }

//bing = GenerateCoordinatesImage(Latitude, Longitude, Zoom, MapStyle, Width, Height, MapStyle, Pins, ImageFormat, DeclutterPins, 1);
            //bing.resourceSets[0].resources[0].imageBase64 = base64;

        private BingResult GetBingMapsData(string uri)
        {
            BingResult res = null;
            try
            {
                using (WebClient client = new WebClient())
                {
                    string result = client.DownloadString(uri);
                    res = Newtonsoft.Json.JsonConvert.DeserializeObject<BingResult>(result);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return res;
        }


        private DownloadedFile DownloadFile(string uri)
        {
            DownloadedFile File = new DownloadedFile();

            byte[] data;
            using (WebClient Client = new WebClient())
            {
                data = Client.DownloadData(uri);
                
                File.ContentType = Client.ResponseHeaders[HttpResponseHeader.ContentType];
                int size = 0;
                if (int.TryParse(Client.ResponseHeaders[HttpResponseHeader.ContentLength], out size))
                {
                    File.Size = size;
                }
                File.Base64 = Convert.ToBase64String(data);
                File.Downloaded = DateTime.Now;
                File.FileExtension = GetDefaultExtension(File.ContentType);
            }
            return File;

        }
        
        private string DownloadFileToBase64(string uri)
        {
            byte[] data;
            using (WebClient Client = new WebClient())
            {
                data = Client.DownloadData(uri);
            }
            string base64 = Convert.ToBase64String(data);
            return base64;
        }

        //http://www.cyotek.com/blog/mime-types-and-file-extensions
        public static string GetDefaultExtension(string mimeType)
        {
            string result;
            RegistryKey key;
            object value;

            key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + mimeType, false);
            value = key != null ? key.GetValue("Extension", null) : null;
            result = value != null ? value.ToString() : string.Empty;

            return result;
        }

        public static string GetMimeTypeFromExtension(string extension)
        {
            string result;
            RegistryKey key;
            object value;

            if (!extension.StartsWith("."))
                extension = "." + extension;

            key = Registry.ClassesRoot.OpenSubKey(extension, false);
            value = key != null ? key.GetValue("Content Type", null) : null;
            result = value != null ? value.ToString() : string.Empty;

            return result;
        }
    }

    public class PushPin
    {
        public string Latitude { get; set; } //float
        public string Longitude { get; set; } //float
        public string Name { get; set; }
    }
    
    public class DownloadedFile
    {
        public string Base64 { get; set; }
        public string FileExtension { get; set; }
        public string FileName { get; set; }
        public DateTime Downloaded { get; set; }
        public string ContentType { get; set; }
        public int Size { get; set; }
    }


    // from Bing Maps

    public class BingResult
    {
        public string authenticationResultCode { get; set; }
        public string brandLogoUri { get; set; }
        public string copyright { get; set; }
        public ResourceSet[] resourceSets { get; set; }
        public int statusCode { get; set; }
        public string statusDescription { get; set; }
        public string traceId { get; set; }
    }

    public class ResourceSet
    {
        public int estimatedTotal { get; set; }
        public Resource[] resources { get; set; }
    }

    public class Resource
    {
        public string __type { get; set; }
        public string[] bbox { get; set; } //float
        public string name { get; set; }
        public Point point { get; set; }
        public Address address { get; set; }
        public string confidence { get; set; }
        public string entityType { get; set; }
        public GeocodePoint[] geocodePoints { get; set; }
        public string[] matchCodes { get; set; }
        public int zoom { get; set; }
        public int imageHeight { get; set; }
        public int imageWidth { get; set; }
    }

    public class Point
    {
        public string type { get; set; }
        public string[] coordinates { get; set; } // float
    }

    public class Address
    {
        public string addressLine { get; set; }
        public string locality { get; set; }
        public string adminDistrict { get; set; }
        public string adminDistrict2 { get; set; }
        public string countryRegion { get; set; }
        public string countryRegionIso2 { get; set; }
        public string formattedAddress { get; set; }
        public string postalCode { get; set; }
        public string neighborhood { get; set; }
        public string landmark { get; set; }
    }

    public class GeocodePoint
    {
        public string type { get; set; }
        public string[] coordinates { get; set; } // float
        public string calculationMethod { get; set; }
        public string[] usageTypes { get; set; }
    }

}
