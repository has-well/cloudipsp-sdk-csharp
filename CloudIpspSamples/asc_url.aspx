<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="asc_url.aspx.cs" Inherits="CloudIpspSamples.AscUrl" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<head runat="server">
    <title>Asc Form</title>
</head>
<body>
<div class="container">
    <form name="MPIform" action='<% Response.Write(Request.Form["acs_url"]); %>' method="POST">
        <input class="form-control" type="hidden" name="PaReq" value='<% Response.Write(Request.Form["pareq"]); %>'>
        <input class="form-control" type="hidden" name="MD" value='<% Response.Write(Request.Form["md"]); %>'>
        <input class="form-control" type="hidden" name="TermUrl" value='<% Response.Write(Request.Form["TermUrl"]); %>'>
        <input class="btn btn-primary" type="submit"/>
    </form>
</div>
</body>
</html>