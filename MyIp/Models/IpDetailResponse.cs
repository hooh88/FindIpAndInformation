namespace MyIp.Models
{


    public sealed class IpDetailResponse
    {
        public string IpAddress { get; set; }
        public string Status { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string PostCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Isp { get; set; }
        public string Query { get; set; }
    }

}
