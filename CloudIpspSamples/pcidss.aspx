<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="pcidss.aspx.cs" Inherits="CloudIpspSamples.PcidssSample" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<head runat="server">
    <title>PciDss non 3ds</title>
</head>
<body>
<div class="container">
    <% if (Data != null)
       { %>
        <table class="table table-sm">
            <tr>
                <td>Order ID</td>
                <td><% Response.Write(Data.order_id); %></td>
            </tr>
            <tr>
                <td>Order status</td>
                <td><% Response.Write(Data.order_status); %></td>
            </tr>
            <tr>
                <td>Amount in cent</td>
                <td><% Response.Write(Data.amount); %></td>
            </tr>
        </table>
    <% }
       else if (DataError != null)
       { %>
        <h2>Error!<br/>Request ID: <b><% Response.Write(DataReqId); %></b></h2>
        <h5>Error message: <b><% Response.Write(DataError); %></b></h5>
    <% }
       else
       { %>
        <form runat="server">
            <fieldset>
                <legend>Order Details</legend>
                <div class="form-group">
                    <label for="order_id">Order ID:</label>
                    <input id="order_id" class="form-control" type="text" name="order_id" value="<%
                                                                                                     if (Request.Form["order_id"] == null)
                                                                                                     {
                                                                                                         Response.Write(System.Guid.NewGuid().ToString());
                                                                                                     }
                                                                                                     else
                                                                                                     {
                                                                                                         Response.Write(Request.Form["order_id"]);
                                                                                                     }
                                                                                                 %>"/>

                </div>
                <div class="form-group">
                    <label for="amount">Amount:</label>
                    <input id="amount" class="form-control" type="text" name="amount" value="<%
                                                                                                 if (Request.Form["amount"] == null)
                                                                                                 {
                                                                                                     Response.Write("100.00");
                                                                                                 }
                                                                                                 else
                                                                                                 {
                                                                                                     Response.Write(Request.Form["amount"]);
                                                                                                 }
                                                                                             %>"/>

                </div>
                <div class="form-group">
                    <label for="card_number">Card Number:</label>
                    <input id="card_number" class="form-control" type="text" autocomplete="off" name="card_number" value="<%
                                                                                                                              if (Request.Form["card_number"] == null)
                                                                                                                              {
                                                                                                                                  Response.Write("4444555511116666");
                                                                                                                              }
                                                                                                                              else
                                                                                                                              {
                                                                                                                                  Response.Write(Request.Form["card_number"]);
                                                                                                                              }
                                                                                                                          %>"/>

                </div>
                <div class="form-group">
                    <label for="card_cvv">CVV:</label>
                    <input id="card_cvv" class="form-control" type="text" autocomplete="off" name="card_cvv" value="<%
                                                                                                                        if (Request.Form["card_cvv"] == null)
                                                                                                                        {
                                                                                                                            Response.Write("111");
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            Response.Write(Request.Form["card_cvv"]);
                                                                                                                        }
                                                                                                                    %>"/>

                </div>
                <div class="form-group">
                    <label for="card_expiry_month">Card Expiry:</label>
                    <asp:DropDownList class="form-control" ID="card_expiry_month" runat="server"/>

                </div>
                <div class="form-group">
                    <label for="card_expiry_month">Card Expiry:</label>
                    <asp:DropDownList class="form-control" ID="card_expiry_year" runat="server"/>
                </div>
            </fieldset>
            <asp:Button ID="btnSubmitNon3ds" CssClass="btn btn-primary" Text="Submit non 3ds" runat="server"/>
        </form>
    <% } %>
</div>
</body>
</html>