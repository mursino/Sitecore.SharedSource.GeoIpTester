<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="geoip.aspx.cs" Inherits="Sitecore.SharedSource.GeoIpTester.sitecore_modules.web.geoip" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GeoIP Tester Info</title>
    <style type="text/css">
    * {
        font-family : Sans-Serif;
        font-size: 13px;
    }
    form {
        margin: 0 auto;
        width: 300px;
        background-color: #eee;
        padding: 10px;
    }
    td {
        padding: 0 30px 10px 0;
    }
    .off {
        color: Red;
        font-weight: bold;
    }
    .on {
        color: Green;
        font-weight: bold;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h1>GeoIP Tester Info</h1>
    <table>
        <% if (!WanIpLookupOn && !MockIpOn) { %>
        <tr>
            <td class="off" colspan="2">Configure the module via App_Config\Include\ Sitecore.SharedSource.GeoIpTester.config</td>
        </tr>
        <% } %>
        <tr>
            <td>Mock IP Status</td>
            <td><%= MockIpStatus %></td>
        </tr>
        <tr>
            <td>WAN IP Lookup Status</td>
            <td><%= WanIpLookupStatus %></td>
        </tr>
        <tr>
            <td>IP</td>
            <td><%= VisitIp %></td>
        </tr>
        <tr>
            <td>City</td>
            <td><%= VisitCity %></td>
        </tr>
        <tr>
            <td>Region</td>
            <td><%= VisitRegion %></td>
        </tr>
        <tr>
            <td>Postal Code</td>
            <td><%= VisitPostalCode %></td>
        </tr>
        <tr>
            <td>Country</td>
            <td><%= VisitCountry %></td>
        </tr>
    </table>
    </form>
</body>
</html>
