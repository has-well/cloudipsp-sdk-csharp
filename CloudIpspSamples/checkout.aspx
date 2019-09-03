<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="CloudIpspSamples.Checkout" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<head runat="server">
    <title>Checkout</title>
</head>
<body>
<div class="container">
    <% if (DataUri != null)
       { %>
        <h2 style="color: #1e7e34">Checkout Created!<br/>Payment ID: <% Response.Write(Data); %></h2>
        <h5>Checkout Url: <a href="<% Response.Write(DataUri); %>"><% Response.Write(DataUri); %></a></h5>
    <% }
       else if (DataError != null)
       { %>
        <h2>Checkout Error!<br/>Request ID: <b><% Response.Write(Data); %></b></h2>
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
            </fieldset>
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" Text="Submit Json" runat="server"/>
            <asp:Button ID="btnSubmitXml" CssClass="btn btn-primary" Text="Submit Xml" runat="server"/>
            <asp:Button ID="btnSubmitForm" CssClass="btn btn-primary" Text="Submit Form" runat="server"/>
        </form>
    <% } %>
</div>
</body>
</html>