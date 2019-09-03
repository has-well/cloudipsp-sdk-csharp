<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="transaction_list.aspx.cs" Inherits="CloudIpspSamples.TransactionListSample" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<head runat="server">
    <title>TransactionsList</title>
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
        <table class="table table-sm">
            <% for (var i = 0; i < Data.response.Count; i++)
               { %>
                <tr>
                    <td>
                        <b><% Response.Write(i); %></b>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>ID</td>
                    <td><% Response.Write(Data.response[i].id); %></td>
                </tr>
                <tr>
                    <td>Payment id</td>
                    <td><% Response.Write(Data.response[i].payment_id); %></td>
                </tr>
                <tr>
                    <td>Amount</td>
                    <td><% Response.Write(Data.response[i].amount); %></td>
                </tr>
                <tr>
                    <td>Status</td>
                    <td><% Response.Write(Data.response[i].transaction_status); %></td>
                </tr>
            <% } %>
        </table>
    <% } %>
    <form runat="server">
        <fieldset>
            <legend>Order Details</legend>
            <div class="form-group">
                <label for="order_id">Order ID: </label>
                <input id="order_id" class="form-control" type="text" name="order_id" value="<%
                                                                                                 if (Request.Form["order_id"] == null)
                                                                                                 {
                                                                                                     Response.Write("1");
                                                                                                 }
                                                                                                 else
                                                                                                 {
                                                                                                     Response.Write(Request.Form["order_id"]);
                                                                                                 }
                                                                                             %>"/>

            </div>
        </fieldset>
        <asp:Button ID="btnSubmit" CssClass="btn btn-primary" Text="Submit" runat="server"/>
    </form>
</div>
</body>
</html>