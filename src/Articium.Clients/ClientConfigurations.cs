using System;
namespace Articium.Clients
{
    public class ClientConfigurations
    {
        public ClientAddressItem ArticleClient { get; set; }
        public ClientAddressItem VarnishClient { get; set; }
    }

    public class ClientAddressItem
    {
        public string Url { get; set; }
        public int Timeout { get; set; }
    }
}

