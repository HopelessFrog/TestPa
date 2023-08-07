using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Services
{
    public class NetworkCheck
    {
        public static bool IsInternet()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}
