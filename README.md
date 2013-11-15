Sitecore.SharedSource.GeoIpTester
=================================

This module provides a simple mechanism in Sitecore to test Geo IP capabilities as a developer. There are two ways to use it to test Geo IP:
- Mock a real world IP to mimic being in that location: this will allow a developer to take real-world geo-distributed IPs and test Geo IP CEP rules against them as if they are in those locations.
- Fetch a public WAN IP when behind a firewall or developing locally: this will allow a developer instance (e.g. localhost) to be resolved as the real-world public IP via a lookup mechanism so you can test real-world Geo IP rules.

Requirements
============
- Sitecore DMS configured
- MaxMind (or another provider) configured
- Use cases or CEP rules using Geo IP to test with

How to Install
==============
- Either install the Sitecore package which will deploy a custom config, a DLL, and an ASPX info page
- Or build the solution yourself, then copy the DLL, the config, and the ASPX to your web root (make sure you maintain the folders they are in)

How to Configure & Use
======================
- Open App_Config\Include\Sitecore.SharedSource.GeoIpTester.config
- Define either a mock IP to fake with (<MockIp /> XML node) or a WAN IP lookup URL (<IpUrl /> XML node).
- Load http://hostname/sitecore modules/web/geoip.aspx to see how Sitecore resolves your settings (public IP or fake IP)
- Run your CEP Geo IP rules with the configured test cases (mock IP or WAN IP). Note: after making a config change, you may need to load your page twice before the rule engines kicks in.

How to Build
============
- Open Build\deploy-target.txt and enter the file system path to your web root to deploy to
- Build the solution
