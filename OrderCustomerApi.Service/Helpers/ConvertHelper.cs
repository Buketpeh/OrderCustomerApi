using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderCustomerApi.Service.Helpers
{
    public static class ConvertHelper
    {

        public static long IPAddressToInt64(string ip)
        {
            if (!IPAddress.TryParse(ip, out IPAddress address) && ip.Contains(","))
            {
                IPAddress.TryParse(ip.Split(new char[1]
                {
                    ','
                })[0], out address);
            }

            if (address != null)
            {
                return (uint)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(address.GetAddressBytes(), 0));
            }

            return 0L;
        }
    }
}
