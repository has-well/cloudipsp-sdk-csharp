﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using CloudIpspSDK;
using CloudIpspSDK.Checkout;
using CloudIpspSDK.Order;
using CloudIpspSDK.Response;

namespace CloudIpspSamples
{
    public partial class OrderReverse : System.Web.UI.Page
    {
        protected string Data = null;
        protected string DataError = null;
        protected NameValueCollection ResponeData = null;
        protected string ResponeOrder = null;
        protected string ResponeOrderError = null;
        protected string ResponeOrderSignatureString = null;
        protected string ResponeOrderCalculatedSignatureString = null;
        protected ReverseByOrderResponse ReverseResp = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo ui = System.Globalization.CultureInfo.CurrentUICulture;
            if (Request.Form["payment_id"] != null || Request.Form["data"] != null)
            {
                ResponeData = Request.Form;
                var resp = new Response().GetResponse(Request.Form.ToString(), "form");
                if (resp.SignatureError != null)
                {
                    ResponeOrderError = "Signature error";
                    ResponeOrderSignatureString = resp.SignatureError.SignatureString;
                    ResponeOrderCalculatedSignatureString = resp.SignatureError.CalculatedSignature;
                }
                else
                {
                    ResponeOrder = resp.order_id;
                    var reverReq = new ReverseByOrder
                    {
                        order_id = resp.order_id,
                        amount = Convert.ToInt32(resp.amount),
                        currency = "USD",
                    };
                    var rresp = new Reverse().ByOrderID(reverReq);
                    if (rresp.Error != null)
                    {
                        ResponeData = null;
                        DataError = rresp.Error.ErrorMessage;
                        Data = rresp.Error.RequestId;
                    }
                    else
                    {
                        ReverseResp = rresp;
                    }
                }
            }
            btnSubmit.Click += Submit;
        }

        private void Submit(object sender, EventArgs e)
        {
            int amount = Convert.ToInt32(Request.Form["amount"].Substring(0,
                Request.Form["amount"].IndexOf('.') > 0
                    ? Request.Form["amount"].IndexOf('.')
                    : Request.Form["amount"].Length));
            var req = new CheckoutRequest
            {
                order_id = Request.Form["order_id"],
                amount = amount * 100,
                order_desc = "checkout reverse demo",
                currency = "USD",
                response_url = Request.Url.Scheme + "://" + Request.Url.Authority + "/order_reverse.aspx"
            };
            DoRequest(req);
        }

        private void DoRequest(CheckoutRequest req)
        {
            var resp = new Url().Post(req);
            if (resp.Error != null)
            {
                DataError = resp.Error.ErrorMessage;
                Data = resp.Error.RequestId;
            }
            else
            {
                Response.Redirect(resp.checkout_url);
            }
        }
    }
}