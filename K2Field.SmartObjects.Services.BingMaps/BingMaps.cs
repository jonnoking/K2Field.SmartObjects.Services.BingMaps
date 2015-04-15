using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceCode.SmartObjects.Services.ServiceSDK.Objects;
using Attributes = SourceCode.SmartObjects.Services.ServiceSDK.Attributes;
using SourceCode.SmartObjects.Services.ServiceSDK.Types;
using System.Net;
using Microsoft.Win32;

namespace K2Field.SmartObjects.Services.BingMaps
{
    [Attributes.ServiceObject("BingMaps", "Bing Maps", "Bing Maps")]
    public class BingMaps
    {
        const string _decimalFormat = "#.######";

        public ServiceConfiguration ServiceConfiguration { get; set; }

        #region Inputs

        [Attributes.Property("Query", SoType.Text, "Query", "Query")]
        public string Query { get; set; }

        [Attributes.Property("Lat", SoType.Text, "Lat", "Lat")]
        public string Lat { get; set; }

        [Attributes.Property("Lon", SoType.Text, "Lon", "Lon")]
        public string Lon { get; set; }

        [Attributes.Property("IncludeEntityTypes", SoType.Text, "Include Entity Types", "Include Entity Types")]
        public string IncludeEntityTypes { get; set; }


        [Attributes.Property("MaxResults", SoType.Number, "Max Results", "Max Results")]
        public int MaxResults { get; set; }

        
        [Attributes.Property("ImageHeight", SoType.Number, "Image Heigh", "Image Height")]
        public int ImageHeight { get; set; }

        [Attributes.Property("ImageWidth", SoType.Number, "Image Width", "Image Width")]
        public int ImageWidth { get; set; }

        [Attributes.Property("ImageZoom", SoType.Number, "Image Zoom", "Image Zoom")]
        public int ImageZoom { get; set; }

        [Attributes.Property("MapStyle", SoType.Number, "Map Style", "Map Style")]
        public string MapStyle { get; set; }

        [Attributes.Property("ImageFormat", SoType.Text, "Image Format", "Image Format")]
        public string ImageFormat { get; set; }

        #endregion Inputs



        [Attributes.Property("LocationName", SoType.Text, "Location Name", "Location Name")]
        public string LocationName { get; set; }

        //[Attributes.Property("PhoneNumber", SoType.Text, "Phone Number", "Phone Number")]
        //public string PhoneNumber { get; set; }

        //[Attributes.Property("WebSite", SoType.Text, "Web Site", "Web Site")]
        //public string WebSite { get; set; }

        [Attributes.Property("Distance", SoType.Text, "Distance", "Distance")]
        public string Distance { get; set; }

        [Attributes.Property("AddressLine", SoType.Text, "Address Line", "Address Line")]
        public string AddressLine { get; set; }

        [Attributes.Property("PostalCode", SoType.Text, "Postal Code", "Postal Code")]
        public string PostalCode { get; set; }

        [Attributes.Property("FormattedAddress", SoType.Memo, "Formatted Address", "Formatted Address")]
        public string FormattedAddress { get; set; }

        [Attributes.Property("AdminDistrict", SoType.Text, "Admin District", "Admin District")]
        public string AdminDistrict { get; set; }

        [Attributes.Property("AdminDistrict2", SoType.Text, "Admin District2", "Admin District2")]
        public string AdminDistrict2 { get; set; }

        [Attributes.Property("CountryRegion", SoType.Text, "Country Region", "Country Region")]
        public string CountryRegion { get; set; }

        [Attributes.Property("CountryRegionIso2", SoType.Text, "Country Region Iso2", "Country Region Iso2")]
        public string CountryRegionIso2 { get; set; }

        [Attributes.Property("Locality", SoType.Text, "Locality", "Locality")]
        public string Locality { get; set; }

        [Attributes.Property("Landmark", SoType.Text, "Landmark", "Landmark")]
        public string Landmark { get; set; }

        [Attributes.Property("Latitude", SoType.Text, "Latitude", "Latitude")]
        public string Latitude { get; set; }

        [Attributes.Property("Longitude", SoType.Text, "Longitude", "Longitude")]
        public string Longitude { get; set; }

        [Attributes.Property("ImagePath", SoType.Text, "Image Path", "Image Path")]
        public string ImagePath { get; set; }

        [Attributes.Property("ImageBase64", SoType.Memo, "Image Base64", "Image Base64")]
        public string ImageBase64 { get; set; }

        [Attributes.Property("ImageUri", SoType.Text, "Image Uri", "Image Uri")]
        public string ImageUri { get; set; }

        [Attributes.Property("Image", SoType.File, "Image", "Image")]
        public string Image { get; set; }

        [Attributes.Property("ImageSize", SoType.Number, "Image Size", "Image Size")]
        public int ImageSize { get; set; }

        [Attributes.Property("ImageFilename", SoType.Text, "Image Filename", "Image Filename")]
        public string ImageFilename { get; set; }

        [Attributes.Property("ImageContentType", SoType.Text, "Image Content Type", "Image Content Type")]
        public string ImageContentType { get; set; }

        [Attributes.Property("SouthLatitude", SoType.Text, "South Latitude", "South Latitude")]
        public string SouthLatitude { get; set; }

        [Attributes.Property("WestLongitude", SoType.Text, "West Longitude", "West Longitude")]
        public string WestLongitude { get; set; }

        [Attributes.Property("NorthLatitude", SoType.Text, "North Latitude", "North Latitude")]
        public string NorthLatitude { get; set; }

        [Attributes.Property("EastLongitude", SoType.Text, "East Longitude", "East Longitude")]
        public string EastLongitude { get; set; }

        [Attributes.Property("Confidence", SoType.Text, "Confidence", "Confidence")]
        public string Confidence { get; set; }

        [Attributes.Property("EstimatedTotal", SoType.Number, "Estimated Total", "Estimated Total")]
        public int EstimatedTotal { get; set; }

        [Attributes.Property("EntityType", SoType.Text, "Entity Type", "Entity Type")]
        public string EntityType { get; set; }

        [Attributes.Property("ResultStatus", SoType.Text, "Result Status", "Result Status")]
        public string ResultStatus { get; set; }

        [Attributes.Property("ResultMessage", SoType.Text, "Result Message", "Result Message")]
        public string ResultMessage { get; set; }



        [Attributes.Method("SearchByLocationRead", SourceCode.SmartObjects.Services.ServiceSDK.Types.MethodType.Read, "Search By Location (Read)", "Search By Location (Read)",
        new string[] { "Query" }, //required property array (no required properties for this sample)
        new string[] { "Query" }, //input property array (no optional input properties for this sample)
        new string[] { "Query", "LocationName", "Latitude", "Longitude", "LocationName", "FormattedAddress", "AddressLine", "AdminDistrict", "AdminDistrict2", "CountryRegion", "CountryRegionIso2", "PostalCode", "Locality", "Landmark", "SouthLatitude", "WestLongitude", "NorthLatitude", "EastLongitude", "Confidence", "EntityType", "EstimatedTotal", "ResultStatus", "ResultMessage" })]
        public BingMaps SearchByLocationRead()
        {
            BingMapsHelper Bing = new BingMapsHelper(ServiceConfiguration["BingMapsKey"].ToString());

            BingResult res = Bing.SearchByLocation(this.Query, 1);

            if (res == null)
            {
                this.ResultStatus = "Error";
                this.ResultMessage = "Failed to download and deserialize result";
            }

            if (res.resourceSets == null || res.resourceSets.Count() < 1 || res.resourceSets[0].resources == null || res.resourceSets[0].resources.Count() < 1)
            {
                this.ResultStatus = "OK";
                this.ResultMessage = "No results";
            }

            Resource resource = res.resourceSets[0].resources[0];

            MapBingMaps(this, resource);
            this.EstimatedTotal = res.resourceSets[0].estimatedTotal;
            this.ResultStatus = "OK";

            return this;
        }

        [Attributes.Method("SearchByLocation", SourceCode.SmartObjects.Services.ServiceSDK.Types.MethodType.List, "Search By Location", "Search By Location",
        new string[] { "Query" }, //required property array (no required properties for this sample)
        new string[] { "Query", "MaxResults"}, //input property array (no optional input properties for this sample)
        new string[] { "Query", "MaxResults", "LocationName", "Latitude", "Longitude", "LocationName", "FormattedAddress", "AddressLine", "AdminDistrict", "AdminDistrict2", "CountryRegion", "CountryRegionIso2", "PostalCode", "Locality", "Landmark", "SouthLatitude", "WestLongitude", "NorthLatitude", "EastLongitude", "Confidence", "EntityType", "EstimatedTotal", "ResultStatus", "ResultMessage" })]
        public List<BingMaps> SearchByLocationList()
        {
            List<BingMaps> results = new List<BingMaps>();

            int max = 10;
            if (this.MaxResults > 0)
            {
                max = this.MaxResults;
            }

            BingMapsHelper Bing = new BingMapsHelper(ServiceConfiguration["BingMapsKey"].ToString());

            BingResult res = Bing.SearchByLocation(this.Query, max);

            //if (res == null)
            //{
            //    this.ResultStatus = "Error";
            //    this.ResultMessage = "Failed to download and deserialize result";
            //}

            //if (res.resourceSets == null || res.resourceSets.Count() < 1 || res.resourceSets[0].resources.Count() < 1)
            //{
            //    this.ResultStatus = "OK";
            //    this.ResultMessage = "No results";
            //}

            if (res == null || res.resourceSets == null || res.resourceSets.Count() < 1 || res.resourceSets[0].resources == null || res.resourceSets[0].resources.Count() < 1)
            {
                return results;
            }

            foreach(Resource resource in res.resourceSets[0].resources)
            {
                BingMaps map = new BingMaps();
                MapBingMaps(map, resource);
                map.Query = this.Query;
                map.MaxResults = this.MaxResults;
                map.EstimatedTotal = res.resourceSets[0].estimatedTotal;
                map.ResultStatus = "OK"; 
                results.Add(map);
            }

            return results;
        }





        [Attributes.Method("SearchByLatLonRead", SourceCode.SmartObjects.Services.ServiceSDK.Types.MethodType.Read, "Search By Lat Lon (Read)", "Search By Lat Lon (Read)",
        new string[] { "Lat", "Lon" }, //required property array (no required properties for this sample)
        new string[] { "Lat", "Lon", "IncludeEntityTypes" }, //input property array (no optional input properties for this sample)
        new string[] { "Lat", "Lon", "IncludeEntityTypes", "LocationName", "Latitude", "Longitude", "LocationName", "FormattedAddress", "AddressLine", "AdminDistrict", "AdminDistrict2", "CountryRegion", "CountryRegionIso2", "PostalCode", "Locality", "Landmark", "SouthLatitude", "WestLongitude", "NorthLatitude", "EastLongitude", "Confidence", "EntityType", "EstimatedTotal", "ResultStatus", "ResultMessage" })]
        public BingMaps SearchByLatLonRead()
        {
            if(string.IsNullOrWhiteSpace(this.IncludeEntityTypes))
            {
                this.IncludeEntityTypes = "";
            }

            BingMapsHelper Bing = new BingMapsHelper(ServiceConfiguration["BingMapsKey"].ToString());


            //decimal.Round(decimal.Parse(this.Lat), 5, MidpointRounding.AwayFromZero).ToString();

            //decimal.Parse(this.Lat).ToString("#.#####");

            BingResult res = Bing.SearchByPoint(decimal.Parse(this.Lat).ToString(_decimalFormat), decimal.Parse(this.Lon).ToString(_decimalFormat), this.IncludeEntityTypes);
//            BingResult res = Bing.SearchByPoint(this.Lat.ToString(), this.Lon.ToString(), this.IncludeEntityTypes);

            if (res == null)
            {
                this.ResultStatus = "Error";
                this.ResultMessage = "Failed to download and deserialize result";
            }

            if (res.resourceSets == null || res.resourceSets.Count() < 1 || res.resourceSets[0].resources == null || res.resourceSets[0].resources.Count() < 1)
            {
                this.ResultStatus = "OK";
                this.ResultMessage = "No results";
            }

            Resource resource = res.resourceSets[0].resources[0];

            MapBingMaps(this, resource);
            this.EstimatedTotal = res.resourceSets[0].estimatedTotal;
            this.ResultStatus = "OK";

            return this;
        }

        [Attributes.Method("SearchByLatLon", SourceCode.SmartObjects.Services.ServiceSDK.Types.MethodType.List, "Search By Lat Lon", "Search By Lat Lon",
        new string[] { "Lat", "Lon" }, //required property array (no required properties for this sample)
        new string[] { "Lat", "Lon", "IncludeEntityTypes"}, //input property array (no optional input properties for this sample)
        new string[] { "Lat", "Lon", "IncludeEntityTypes", "LocationName", "Latitude", "Longitude", "LocationName", "FormattedAddress", "AddressLine", "AdminDistrict", "AdminDistrict2", "CountryRegion", "CountryRegionIso2", "PostalCode", "Locality", "Landmark", "SouthLatitude", "WestLongitude", "NorthLatitude", "EastLongitude", "Confidence", "EntityType", "EstimatedTotal", "ResultStatus", "ResultMessage" })]
        public List<BingMaps> SearchByLatLonList()
        {
            List<BingMaps> results = new List<BingMaps>();

            if (string.IsNullOrWhiteSpace(this.IncludeEntityTypes))
            {
                this.IncludeEntityTypes = "";
            }

            BingMapsHelper Bing = new BingMapsHelper(ServiceConfiguration["BingMapsKey"].ToString());

            BingResult res = Bing.SearchByPoint(decimal.Parse(this.Lat).ToString(_decimalFormat), decimal.Parse(this.Lon).ToString(_decimalFormat), this.IncludeEntityTypes);

            if (res == null || res.resourceSets == null || res.resourceSets.Count() < 1 || res.resourceSets[0].resources == null || res.resourceSets[0].resources.Count() < 1)
            {
                return results;
            }

            foreach (Resource resource in res.resourceSets[0].resources)
            {
                BingMaps map = new BingMaps();
                MapBingMaps(map, resource);
                map.Lat = this.Lat;
                map.Lon = this.Lon;
                map.IncludeEntityTypes = this.IncludeEntityTypes;
                map.EstimatedTotal = res.resourceSets[0].estimatedTotal;
                map.ResultStatus = "OK";
                results.Add(map);
            }

            return results;
        }



        [Attributes.Method("GetMapImageByLatLon", SourceCode.SmartObjects.Services.ServiceSDK.Types.MethodType.Read, "Get Map Image By Lat Lon (Read)", "Get Map Image By Lat Lon (Read)",
        new string[] { "Lat", "Lon" }, //required property array (no required properties for this sample)
        new string[] { "Lat", "Lon", "ImageWidth", "ImageHeight", "ImageZoom", "MapStyle", "ImageFormat"}, //input property array (no optional input properties for this sample)
        new string[] { "Lat", "Lon", "ImageWidth", "ImageHeight", "ImageZoom", "MapStyle", "ImageFormat", "Image", "ImageBase64", "ImageSize", "ImageFilename", "ImageContentType", "LocationName", "Latitude", "Longitude", "LocationName", "FormattedAddress", "AddressLine", "AdminDistrict", "AdminDistrict2", "CountryRegion", "CountryRegionIso2", "PostalCode", "Locality", "Landmark", "SouthLatitude", "WestLongitude", "NorthLatitude", "EastLongitude", "Confidence", "EntityType", "EstimatedTotal", "ResultStatus", "ResultMessage" })]
        public BingMaps GetMapImageByLatLon()
        {
            /* need to:
             * pushpin co-ordinates
             * pushpint label
             * map type - aerialwithlabels, etc
             * image format - jpeg, png,
             * map layer
             * */

            try
            {
                float.Parse(this.Lat);
                float.Parse(this.Lon);
            }
            catch (Exception ex)
            {
                this.ResultStatus = "Error";
                this.ResultMessage = "Latitude and Longitude must be supplied as a float xxx.xxxxxx";
                return this;
            }


            BingMapsHelper Bing = new BingMapsHelper(ServiceConfiguration["BingMapsKey"].ToString());
            PushPin p = new PushPin()
            {
                //Latitude = float.Parse(this.Lat),
                //Longitude = float.Parse(this.Lon),
                Latitude = this.Lat,
                Longitude = this.Lon,

            };
            List<PushPin> pins = new List<PushPin>();
            pins.Add(p);

            DownloadedFile file = Bing.GetMapImage(decimal.Parse(this.Lat).ToString(_decimalFormat), decimal.Parse(this.Lon).ToString(_decimalFormat), this.ImageZoom, this.MapStyle, this.ImageWidth, this.ImageHeight, "", pins, this.ImageFormat, false);
            BingResult res = Bing.GetMapImageMetadata(decimal.Parse(this.Lat).ToString(_decimalFormat), decimal.Parse(this.Lon).ToString(_decimalFormat), this.ImageZoom, this.MapStyle, this.ImageWidth, this.ImageHeight, "", pins, this.ImageFormat, false);


            if (res == null)
            {
                this.ResultStatus = "Error";
                this.ResultMessage = "Failed to download and deserialize result";
                return this;
            }

            if (res.resourceSets == null || res.resourceSets.Count() < 1 || res.resourceSets[0].resources == null || res.resourceSets[0].resources.Count() < 1)
            {
                this.ResultStatus = "OK";
                this.ResultMessage = "No results";
                return this;
            }

            Resource resource = res.resourceSets[0].resources[0];
            
            MapBingMaps(this, resource);
            this.ImageBase64 = file.Base64;
            this.ImageSize = file.Size;
            string filename = Guid.NewGuid() + file.FileExtension;
            this.ImageFilename = filename;
            this.ImageContentType = file.ContentType;
            this.EstimatedTotal = res.resourceSets[0].estimatedTotal;

            FileProperty fp = new FileProperty()
            {
                Content = this.ImageBase64,
                FileName = filename
            };
            
            this.Image = fp.Value.ToString();


            this.ResultStatus = "OK";

            return this;
        }


        [Attributes.Method("GetMapImageByLocation", SourceCode.SmartObjects.Services.ServiceSDK.Types.MethodType.Read, "Get Map Image By Location (Read)", "Get Map Image By Location (Read)",
        new string[] { "Query" }, //required property array (no required properties for this sample)
        new string[] { "Query", "ImageWidth", "ImageHeight", "ImageZoom", "MapStyle", "ImageFormat" }, //input property array (no optional input properties for this sample)
        new string[] { "Query", "ImageWidth", "ImageHeight", "ImageZoom", "MapStyle", "ImageFormat", "Image", "ImageBase64", "ImageSize", "ImageFilename", "ImageContentType", "LocationName", "Latitude", "Longitude", "LocationName", "FormattedAddress", "AddressLine", "AdminDistrict", "AdminDistrict2", "CountryRegion", "CountryRegionIso2", "PostalCode", "Locality", "Landmark", "SouthLatitude", "WestLongitude", "NorthLatitude", "EastLongitude", "Confidence", "EntityType", "EstimatedTotal", "ResultStatus", "ResultMessage" })]
        public BingMaps GetMapImageByLocation()
        {
            /* need to:
             * pushpin co-ordinates
             * pushpint label
             * map type - aerialwithlabels, etc
             * image format - jpeg, png,
             * map layer
             * */

            try
            {
                float.Parse(this.Lat);
                float.Parse(this.Lon);
            }
            catch (Exception ex)
            {
                this.ResultStatus = "Error";
                this.ResultMessage = "Latitude and Longitude must be supplied as a float xxx.xxxxxx";
                return this;
            }

            BingMapsHelper Bing = new BingMapsHelper(ServiceConfiguration["BingMapsKey"].ToString());
            PushPin p = new PushPin()
            {
                //Latitude = float.Parse(this.Lat),
                //Longitude = float.Parse(this.Lon),
                Latitude = this.Lat,
                Longitude = this.Lon,
            };
            List<PushPin> pins = new List<PushPin>();
            pins.Add(p);

            DownloadedFile file = Bing.GetMapImageByLocation(this.Query, this.ImageZoom, this.MapStyle, this.ImageWidth, this.ImageHeight, "", pins, this.ImageFormat, false);
            BingResult res = Bing.GetMapImageMetadata(decimal.Parse(this.Lat).ToString(_decimalFormat), decimal.Parse(this.Lon).ToString(_decimalFormat), this.ImageZoom, this.MapStyle, this.ImageWidth, this.ImageHeight, "", pins, this.ImageFormat, false);


            if (res == null)
            {
                this.ResultStatus = "Error";
                this.ResultMessage = "Failed to download and deserialize result";
                return this;
            }

            if (file == null || res.resourceSets == null || res.resourceSets.Count() < 1 || res.resourceSets[0].resources == null || res.resourceSets[0].resources.Count() < 1)
            {
                this.ResultStatus = "OK";
                this.ResultMessage = "No results";
                return this;
            }

            Resource resource = res.resourceSets[0].resources[0];

            MapBingMaps(this, resource);
            this.ImageBase64 = file.Base64;
            this.ImageSize = file.Size;
            string filename = Guid.NewGuid() + file.FileExtension;
            this.ImageFilename = filename;
            this.ImageContentType = file.ContentType;
            this.EstimatedTotal = res.resourceSets[0].estimatedTotal;

            FileProperty fp = new FileProperty()
            {
                Content = this.ImageBase64,
                FileName = filename
            };

            this.Image = fp.Value.ToString();


            this.ResultStatus = "OK";

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

                if (!string.IsNullOrWhiteSpace(resource.address.countryRegionIso2))
                    bm.CountryRegionIso2 = resource.address.countryRegionIso2;

                if (!string.IsNullOrWhiteSpace(resource.address.formattedAddress))
                    bm.FormattedAddress = resource.address.formattedAddress;

                if (!string.IsNullOrWhiteSpace(resource.address.locality))
                    bm.Locality = resource.address.locality;

                if (!string.IsNullOrWhiteSpace(resource.address.postalCode))
                    bm.PostalCode = resource.address.postalCode;

                if (!string.IsNullOrWhiteSpace(resource.address.landmark))
                    bm.Landmark = resource.address.landmark;

            }

            if (!string.IsNullOrWhiteSpace(resource.confidence)) 
                bm.Confidence = resource.confidence;

            if (!string.IsNullOrWhiteSpace(resource.entityType)) 
                bm.EntityType = resource.entityType;


            //float latout;
            //if (resource.point != null && resource.point.coordinates.Length > 0 && float.TryParse(resource.point.coordinates[0].ToString(), out latout))
            //    bm.Latitude = latout;

            //float lonout;
            //if (resource.point != null && resource.point.coordinates.Length > 1 && float.TryParse(resource.point.coordinates[1].ToString(), out lonout))
            //    bm.Longitude = lonout;


            //float slatout = 0;
            //if (resource.bbox != null && resource.bbox.Length > 0 && float.TryParse(resource.bbox[0].ToString(), out slatout))
            //    bm.SouthLatitude = slatout;

            //float wlonout;
            //if (resource.bbox != null && resource.bbox.Length > 0 && float.TryParse(resource.bbox[1].ToString(), out wlonout))
            //    bm.WestLongitude = wlonout;

            //float nlatout;
            //if (resource.bbox != null && resource.bbox.Length > 0 && float.TryParse(resource.bbox[2].ToString(), out nlatout))
            //    bm.NorthLatitude = nlatout;

            //float elonout;
            //if (resource.bbox != null && resource.bbox.Length > 0 && float.TryParse(resource.bbox[3].ToString(), out elonout))
            //    bm.EastLongitude = elonout;


            float latout;
            if (resource.point != null && resource.point.coordinates.Length > 0)
                bm.Latitude = resource.point.coordinates[0].ToString();

            float lonout;
            if (resource.point != null && resource.point.coordinates.Length > 1)
                bm.Longitude = resource.point.coordinates[1].ToString();


            float slatout = 0;
            if (resource.bbox != null && resource.bbox.Length > 0)
                bm.SouthLatitude = resource.bbox[0].ToString();

            float wlonout;
            if (resource.bbox != null && resource.bbox.Length > 0)
                bm.WestLongitude = resource.bbox[1].ToString();

            float nlatout;
            if (resource.bbox != null && resource.bbox.Length > 0)
                bm.NorthLatitude = resource.bbox[2].ToString();

            float elonout;
            if (resource.bbox != null && resource.bbox.Length > 0)
                bm.EastLongitude = resource.bbox[3].ToString();

            
            bm.ImageWidth = resource.imageWidth;

            
            bm.ImageHeight = resource.imageHeight;

            
            bm.ImageZoom = resource.zoom;


        }



   

    }

    


}
