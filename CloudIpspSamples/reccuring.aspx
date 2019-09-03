<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="reccuring.aspx.cs" Inherits="CloudIpspSamples.ReccuringSample" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<head runat="server">
    <title>Reccuring Sample</title>
</head>
<body>
<div class="container">
    <% if (DataOrder != null)
       { %>
        <h2 style="color: #1e7e34">Reccuring Completed!<br/>Payment ID: <% Response.Write(Data); %></h2>
        <h5>Reccuring Order ID: <% Response.Write(DataOrder); %></h5>
    <% }
       else if (DataError != null)
       { %>
        <h2>Reccuring Error!<br/>Request ID: <b><% Response.Write(Data); %></b></h2>
        <h5>Error message: <b><% Response.Write(DataError); %></b></h5>
    <% }
       else
       { %>
        <form runat="server">
            <fieldset>
                <legend>Order Details</legend>
                <div class="form-group">
                    <label for="order_id">Order ID: </label>
                    <input id="order_id" class="form-control" type="text" name="order_id" value="<%
                                                                                                     if (Request.Form["order_id"] == null)
                                                                                                     {
                                                                                                         Response.Write(Guid.NewGuid().ToString());
                                                                                                     }
                                                                                                     else
                                                                                                     {
                                                                                                         Response.Write(Request.Form["order_id"]);
                                                                                                     }
                                                                                                 %>"/>

                </div>
                <div class="form-group">
                    <label for="amount">Amount:</label>
                    <input id="amount" class="form-control" type="number" name="amount" value="<%
                                                                                                   if (Request.Form["amount"] == null)
                                                                                                   {
                                                                                                       Response.Write("100");
                                                                                                   }
                                                                                                   else
                                                                                                   {
                                                                                                       Response.Write(Request.Form["amount"]);
                                                                                                   }
                                                                                               %>"/>
                </div>
                <div class="form-group">
                    <label for="rectoken">Rectoken:</label>
                    <input id="rectoken" class="form-control" type="text" name="rectoken" value="<%
                                                                                                     if (Request.Form["rectoken"] == null)
                                                                                                     {
                                                                                                         Response.Write("b037ba5501956289d7a2094dee020e6560de04");
                                                                                                     }
                                                                                                     else
                                                                                                     {
                                                                                                         Response.Write(Request.Form["rectoken"]);
                                                                                                     }
                                                                                                 %>"/>
                </div>
            </fieldset>
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" Text="Submit" runat="server"/>
        </form>
    <% } %>
</div>
</body>
</html>