using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceCode.SmartObjects.Services.ServiceSDK.Objects;
using Attributes = SourceCode.SmartObjects.Services.ServiceSDK.Attributes;
using SourceCode.SmartObjects.Services.ServiceSDK.Types;
using System.Net;

namespace K2Field.SmartObjects.Services.BingMaps
{
    [Attributes.ServiceObject("BingMaps", "Bing Maps", "Bing Maps")]
    public class BingMaps
    {


        [Attributes.Property("LocationName", SoType.Text, "Location Name", "Location Name")]
        public string LocationName { get; set; }

        [Attributes.Property("PhoneNumber", SoType.Text, "Phone Number", "Phone Number")]
        public string PhoneNumber { get; set; }

        [Attributes.Property("WebSite", SoType.Text, "Web Site", "Web Site")]
        public string WebSite { get; set; }

        [Attributes.Property("Distance", SoType.Decimal, "Distance", "Distance")]
        public decimal Distance { get; set; }

        [Attributes.Property("AddressLine", SoType.Text, "Address Line", "Address Line")]
        public string AddressLine { get; set; }

        [Attributes.Property("Postcode", SoType.Text, "Postcode", "Postcode")]
        public string Postcode { get; set; }

        [Attributes.Property("FormattedAddress", SoType.Memo, "Formatted Address", "Formatted Address")]
        public string FormattedAddress { get; set; }

        [Attributes.Property("AdminDistrict", SoType.Text, "Admin District", "Admin District")]
        public string AdminDistrict { get; set; }

        [Attributes.Property("AdminDistrict2", SoType.Text, "Admin District2", "Admin District2")]
        public string AdminDistrict2 { get; set; }

        [Attributes.Property("CountryRegion", SoType.Text, "Country Region", "Country Region")]
        public string CountryRegion { get; set; }

        [Attributes.Property("CountryRegioniso2", SoType.Text, "Country Region iso2", "Country Region iso2")]
        public string CountryRegioniso2 { get; set; }

        [Attributes.Property("Locality", SoType.Text, "Locality", "Locality")]
        public string Locality { get; set; }

        [Attributes.Property("Landmark", SoType.Text, "Landmark", "Landmark")]
        public string Landmark { get; set; }

        [Attributes.Property("PostalTown", SoType.Text, "Postal Town", "Postal Town")]
        public string PostalTown { get; set; }

        [Attributes.Property("Latitude", SoType.Decimal, "Latitude", "Latitude")]
        public decimal Latitude { get; set; }

        [Attributes.Property("Longitude", SoType.Decimal, "Longitude", "Longitude")]
        public decimal Longitude { get; set; }

        [Attributes.Property("ImagePath", SoType.Text, "Image Path", "Image Path")]
        public string ImagePath { get; set; }

        [Attributes.Property("ImageBase64", SoType.Text, "Image Base64", "ImageBase64")]
        public string ImageBase64 { get; set; }

        [Attributes.Property("ImageUri", SoType.Text, "Image Uri", "ImageUri")]
        public string ImageUri { get; set; }

        [Attributes.Property("SouthLatitude", SoType.Decimal, "South Latitude", "South Latitude")]
        public decimal SouthLatitude { get; set; }

        [Attributes.Property("WestLongitude", SoType.Decimal, "West Longitude", "West Longitude")]
        public decimal WestLongitude { get; set; }

        [Attributes.Property("NorthLatitude", SoType.Decimal, "North Latitude", "North Latitude")]
        public decimal NorthLatitude { get; set; }

        [Attributes.Property("EastLongitude", SoType.Decimal, "East Longitude", "East Longitude")]
        public decimal EastLongitude { get; set; }

        [Attributes.Property("Confidence", SoType.Text, "Confidence", "Confidence")]
        public string Confidence { get; set; }

        [Attributes.Property("EntityType", SoType.Text, "Entity Type", "Entity Type")]
        public string EntityType { get; set; }

        [Attributes.Property("ResultStatus", SoType.Text, "Result Status", "Result Status")]
        public string ResultStatus { get; set; }

        [Attributes.Property("ResultMessage", SoType.Text, "Result Message", "Result Message")]
        public string ResultMessage { get; set; }



        [Attributes.Method("SearchByLocationRead", SourceCode.SmartObjects.Services.ServiceSDK.Types.MethodType.Execute, "Search By Location Read", "Search By Location Read",
        new string[] { "Message", "Index", "CreateIndex", "Source", "SourceType" }, //required property array (no required properties for this sample)
        new string[] { "Message", "Index", "CreateIndex", "Source", "SourceType" }, //input property array (no optional input properties for this sample)
        new string[] { "Message", "Index", "CreateIndex", "Source", "SourceType", "ResultStatus", "ResultMessage" })] //return property array (2 properties for this example)
        public BingMaps SearchByLocationRead()
        {
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

            string uri = string.Empty;

            BingResult res = null;

            using(WebClient client = new WebClient())
            {
                string result = client.DownloadString(uri);
                res = Newtonsoft.Json.JsonConvert.DeserializeObject<BingResult>(result);
            }

            if (res == null || res.resourceSets == null || res.resourceSets.Count() < 1 || res.resourceSets[0].resources.Count() < 1)
            {
                this.ResultStatus = "Error";
                this.ResultMessage = "Failed to download and deserialize result";
            }

            Resource resource = res.resourceSets[0].resources[0];

            MapBingMaps(this, resource);

            return this;
        }




        private void MapBingMaps(BingMaps bm, Resource resource)
        {
         

            bm.LocationName = resource.name;
            //bm.PhoneNumber = resource.address
            //bm.WebSite = 

            if (resource.address != null)
            {

                if (!string.IsNullOrWhiteSpace(resource.address.addressLine))
                    bm.AddressLine = resource.address.addressLine;

                if (!string.IsNullOrWhiteSpace(resource.address.adminDistrict))
                    bm.AdminDistrict = resource.address.adminDistrict;

                if (!string.IsNullOrWhiteSpace(resource.address.adminDistrict2))
                    bm.AdminDistrict2 = resource.address.adminDistrict2;

                if (!string.IsNullOrWhiteSpace(resource.address.countryRegion))
                    bm.CountryRegion = resource.address.countryRegion;

                if (!string.IsNullOrWhiteSpace(resource.address.countryRegioniso2))
                    bm.CountryRegioniso2 = resource.address.countryRegioniso2;

                if (!string.IsNullOrWhiteSpace(resource.address.formattedAddress))
                    bm.FormattedAddress = resource.address.formattedAddress;

                if (!string.IsNullOrWhiteSpace(resource.address.locality))
                    bm.Locality = resource.address.locality;

                if (!string.IsNullOrWhiteSpace(resource.address.postalCode))
                    bm.Postcode = resource.address.postalCode;

                if (!string.IsNullOrWhiteSpace(resource.address.landmark))
                    bm.Landmark = resource.address.landmark;

            }

            if (!string.IsNullOrWhiteSpace(resource.confidence)) 
                bm.Confidence = resource.confidence;

            if (!string.IsNullOrWhiteSpace(resource.entityType)) 
                bm.EntityType = resource.entityType;


            bm.Latitude = decimal.Parse(resource.point.coordinates[0].ToString());
            bm.Longitude = decimal.Parse(resource.point.coordinates[1].ToString());

            bm.SouthLatitude = decimal.Parse(resource.bbox[0].ToString());
            bm.WestLongitude = decimal.Parse(resource.bbox[1].ToString());
            bm.NorthLatitude = decimal.Parse(resource.bbox[2].ToString());
            bm.EastLongitude = decimal.Parse(resource.bbox[3].ToString());
        }

        

    }

    
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
public float[] bbox { get; set; }
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
public float[] coordinates { get; set; }
}

public class Address
{
    public string addressLine { get; set; }
    public string locality { get; set; }
    public string adminDistrict { get; set; }
    public string adminDistrict2 { get; set; }
    public string countryRegion { get; set; }
    public string countryRegioniso2 { get; set; }
    public string formattedAddress { get; set; }
    public string postalCode { get; set; }
    public string neighborhood { get; set; }
    public string landmark { get; set; }
}

public class GeocodePoint
{
public string type { get; set; }
public float[] coordinates { get; set; }
public string calculationMethod { get; set; }
public string[] usageTypes { get; set; }
}


}
