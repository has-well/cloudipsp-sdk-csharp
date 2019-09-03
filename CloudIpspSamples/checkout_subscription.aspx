<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="CloudIpspSamples.CheckoutSubscription" %>

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
                <div class="form-group">
                    <label for="start_time">Start time:</label>
                    <input id="start_time" class="form-control" type="text" name="start_time" value="<%
                                                                                                           if (Request.Form["start_time"] == null)
                                                                                                           {
                                                                                                               Response.Write(DateTime.Now.ToString("yyyy-MM-dd"));
                                                                                                           }
                                                                                                           else
                                                                                                           {
                                                                                                               Response.Write(Request.Form["start_time"]);
                                                                                                           }
                                                                                                       %>"/>
                </div>
                <div class="form-group">
                    <label for="subscription_amount">Subscription Amount:</label>
                    <input id="subscription_amount" class="form-control" type="number" name="subscription_amount" value="<%
                                                                                                                             if (Request.Form["subscription_amount"] == null)
                                                                                                                             {
                                                                                                                                 Response.Write("100");
                                                                                                                             }
                                                                                                                             else
                                                                                                                             {
                                                                                                                                 Response.Write(Request.Form["subscription_amount"]);
                                                                                                                             }
                                                                                                                         %>"/>
                </div>
            </fieldset>
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" Text="Submit Json" runat="server"/>
        </form>
    <% } %>
</div>
</body>
</html>