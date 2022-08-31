<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="response.aspx.cs" Inherits="CloudIpspSamples.ResponseSample" %>
<%@ Import Namespace="System.ComponentModel" %>
<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<head runat="server">
    <title>Order Status</title>
</head>
<body>
<div class="container">
    <% if (ResponeData != null)
       { %>
        <% if (ResponeOrderError != null)
           { %>
            <h2>Signature Error</h2>
            <table class="table table-sm">
                <tr>
                    <td>Calculated Signature</td>
                    <td><% Response.Write(ResponeOrderCalculatedSignatureString); %></td>
                </tr>
                <tr>
                    <td>Response Signature</td>
                    <td><% Response.Write(ResponeOrderSignatureString); %></td>
                </tr>
            </table>
        <% }
           else
           { %>
            <h2>Order Response data</h2>
            <table class="table table-sm">
                <% foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(ResponeData))
                   { %>
                    <tr>
                        <td><% Response.Write(descriptor.Name); %></td>
                        <td><% Response.Write(descriptor.GetValue(ResponeData)); %></td>
                    </tr>
                <% } %>
            </table>
    <% }
       }
       else if (DataError != null)
       { %>
        <h2>Error!<br/>Request ID: <b><% Response.Write(Data); %></b></h2>
        <h5>Error message: <b><% Response.Write(DataError); %></b></h5>
    <% } %>
</div>
</body>
</html>