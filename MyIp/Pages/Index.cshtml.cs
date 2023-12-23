using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyIp.Models;
using System.Net;

namespace MyIp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IpApiClient _ipApiClient;
        public string IpAddress;
        public IpDetailResponse IpApiResponse;

        public IndexModel(ILogger<IndexModel> logger, IpApiClient ipApiClient)
        {
            _logger = logger;
            _ipApiClient = ipApiClient;
        }

        public async Task OnGetAsync(CancellationToken ct)
        {
            //IpAddress = HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR");
            IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            var ipAddressWithoutPort = IpAddress?.Split(':')[0];
            var ipApiResponse = await _ipApiClient.Get(ipAddressWithoutPort, ct);
            IpApiResponse = new IpDetailResponse()
            {
                IpAddress = ipAddressWithoutPort,
                Country = ipApiResponse?.country?? "no data",
                Region = ipApiResponse?.regionName ?? "no data",
                City = ipApiResponse?.city ?? "no data",
                District = ipApiResponse?.district ?? "no data",
                PostCode = ipApiResponse?.zip ?? "no data",
                Longitude = ipApiResponse?.lon.GetValueOrDefault(),
                Latitude = ipApiResponse?.lat.GetValueOrDefault(),
            };
        }
    }
}
