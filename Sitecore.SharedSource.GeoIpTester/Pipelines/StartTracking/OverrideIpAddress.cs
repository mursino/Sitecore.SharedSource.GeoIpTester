using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Analytics.Pipelines.StartTracking;
using Sitecore.Analytics;
using System.Net;
using Sitecore.Diagnostics;

namespace Sitecore.SharedSource.GeoIpTester.Pipelines.StartTracking
{
    /// <summary>
    /// Override the client IP address with WAN IP or mock IP
    /// </summary>
    public class OverrideIpAddress
    {
        /// <summary>
        /// The <ipurl /> XML node in the patch config
        /// </summary>
        public string IpUrl
        {
            get;
            set;
        }

        /// <summary>
        /// The <badips /> XML node in the patch config
        /// </summary>
        public string BadIps
        {
            get;
            set;
        }

        /// <summary>
        /// The <mockip /> XML node in the patch config
        /// </summary>
        public string MockIp
        {
            get;
            set;
        }

        /// <summary>
        /// Process the pipeline step
        /// </summary>
        /// <param name="args"></param>
        public void Process(StartTrackingArgs args)
        {
            // bail out if null
            if (Tracker.CurrentVisit == null || Tracker.CurrentVisit.Ip == null)
            {
                return;
            }

            // get current raw IP
            string ip = new IPAddress(Tracker.CurrentVisit.Ip).ToString();
            Assert.IsNotNullOrEmpty(ip, "Tracker.CurrentVisit.Ip");

            // default BadIps if not set
            if (string.IsNullOrEmpty(BadIps))
            {
                BadIps = "0.0.0.0|127.0.0.1";
            }

            // if the currently tracked IP is not in the list of
            // bad IPs, don't bother processing the IP override
            if (!BadIps.Split('|').Contains(ip))
            {
                return;
            }


            string rawIpValue = "";

            if (string.IsNullOrEmpty(MockIp))
            {
                if (string.IsNullOrEmpty(IpUrl))
                {
                    // no mock IP or WAN IP lookup URL
                    return;
                }
                else
                {
                    // fetch WAN IP via IP lookup URL
                    rawIpValue = Sitecore.Web.WebUtil.ExecuteWebPage(IpUrl);
                    Assert.IsNotNullOrEmpty(rawIpValue, "WAN IP lookup from <IpUrl>");
                }
            }
            else
            {
                // mock IP is configured so use it
                rawIpValue = MockIp;
                Assert.IsNotNullOrEmpty(rawIpValue, "value of <MockIp>");
            }

            // sanitize raw IP value
            rawIpValue = rawIpValue.ToLowerInvariant().Replace("\n", "").Replace("\r", "");

            // convert IP and set to current visit
            IPAddress address = IPAddress.Parse(rawIpValue);
            Tracker.CurrentVisit.GeoIp = Tracker.Visitor.DataContext.GetGeoIp(address.GetAddressBytes());
        }
    }
}