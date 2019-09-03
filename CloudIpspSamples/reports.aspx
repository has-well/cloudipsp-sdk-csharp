<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="reports.aspx.cs" Inherits="CloudIpspSamples.ReportSample" %>
<%@ Import Namespace="System.ComponentModel" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<head runat="server">
    <title>ReportSample</title>
</head>
<body>
<div class="container">
    <% if (DataNoList != null)
       { %>
        <h2>
            <b><% Response.Write(DataNoList); %></b>
        </h2>
    <% } %>
    <% if (DataError != null)
       { %>
        <h2>Error!<br/>Request ID: <b><% Response.Write(DataErrorId); %></b></h2>
        <h5>Error message: <b><% Response.Write(DataError); %></b></h5>
    <% } %>
    <% if (Data != null)
       { %>

        <% for (var i = 0; i < Data.response.Count; i++)
           { %>
            <h1>Order ID: <% Response.Write(Data.response[i].order_id); %></h1>
            <table class="table table-sm">
                <% foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(Data.response[i]))
                   { %>
                    <tr>
                        <td><% Response.Write(descriptor.Name); %></td>
                        <td><% Response.Write(descriptor.GetValue(Data.response[i])); %></td>
                    </tr>
                <% } %>
            </table>
        <% } %>

    <% } %>
    <form runat="server">
        <fieldset>
            <legend>Order Details</legend>
            <div class="form-group">
                <label for="date_from">Date From</label>
                <input id="date_from" class="form-control" type="text" name="date_from" value="<%
                                                                                                   if (Request.Form["date_from"] == null)
                                                                                                   {
                                                                                                       Response.Write(DateTime.Now.AddDays(-1).ToString("dd.MM.yyyy hh:mm:ss"));
                                                                                                   }
                                                                                                   else
                                                                                                   {
                                                                                                       Response.Write(Request.Form["date_from"]);
                                                                                                   }
                                                                                               %>"/>

            </div>
            <div class="form-group">
                <label for="date_to">Date To</label>
                <input id="date_to" class="form-control" type="text" name="date_to" value="<%
                                                                                               if (Request.Form["date_to"] == null)
                                                                                               {
                                                                                                   Response.Write(DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss"));
                                                                                               }
                                                                                               else
                                                                                               {
                                                                                                   Response.Write(Request.Form["date_to"]);
                                                                                               }
                                                                                           %>"/>

            </div>
        </fieldset>
        <asp:Button ID="btnSubmit" CssClass="btn btn-primary" Text="Submit" runat="server"/>
    </form>
</div>
</body>
</html>