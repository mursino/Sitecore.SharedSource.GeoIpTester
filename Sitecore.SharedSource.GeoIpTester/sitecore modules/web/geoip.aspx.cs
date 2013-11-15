using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sitecore.SharedSource.GeoIpTester.sitecore_modules.web
{
    public partial class geoip : System.Web.UI.Page
    {
        public bool WanIpLookupOn
        {
            get
            {
                var node = Sitecore.Configuration.Factory.GetConfigNode("/sitecore/pipelines/startTracking/processor/IpUrl");
                return node != null && !string.IsNullOrEmpty(node.InnerText);
            }
        }
        
        public string WanIpLookupStatus
        {
            get
            {
                if (WanIpLookupOn)
                {
                    if (MockIpOn)
                    {
                        return "<span class='on'>ON</span> <span class='off'>(ignored)</span>";
                    }
                    else
                    {
                        return "<span class='on'>ON</span>";
                    }
                }
                else
                {
                    return "<span class='off'>OFF</span>";
                }
            }
        }

        public bool MockIpOn
        {
            get
            {
                var node = Sitecore.Configuration.Factory.GetConfigNode("/sitecore/pipelines/startTracking/processor/MockIp");
                return node != null && !string.IsNullOrEmpty(node.InnerText);
            }
        }
        
        public string MockIpStatus
        {
            get
            {
                if (MockIpOn)
                {
                    return "<span class='on'>ON</span>";
                }
                else
                {
                    return "<span class='off'>OFF</span>";
                }
            }
        }

        public string VisitIp
        {
            get
            {
                return new System.Net.IPAddress(Sitecore.Analytics.Tracker.CurrentVisit.Ip).ToString();
            }
        }

        public string VisitCity
        {
            get
            {
                return Sitecore.Analytics.Tracker.CurrentVisit.City;
            }
        }

        public string VisitRegion
        {
            get
            {
                return Sitecore.Analytics.Tracker.CurrentVisit.Region;
            }
        }

        public string VisitPostalCode
        {
            get
            {
                return Sitecore.Analytics.Tracker.CurrentVisit.PostalCode;
            }
        }

        public string VisitCountry
        {
            get
            {
                return Sitecore.Analytics.Tracker.CurrentVisit.Country;
            }
        }
    }
}