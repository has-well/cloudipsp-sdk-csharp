# IPSP C# SDK

<p align="center">
  <img width="200" height="200" src="https://avatars0.githubusercontent.com/u/15383021?s=200&v=4">
</p>
<p align="center">
	<a href="https://www.nuget.org/packages/CloudIpspSDK/"><img src="https://img.shields.io/nuget/v/CloudIpspSDK.svg" /></a>
	<a href="https://www.nuget.org/packages/CloudIpspSDK/"><img src="https://img.shields.io/nuget/dt/CloudIpspSDK.svg" /></a>
</p>

## Payment service provider
A payment service provider (PSP) offers shops online services for accepting electronic payments by a variety of payment methods including credit card, bank-based payments such as direct debit, bank transfer, and real-time bank transfer based on online banking. Typically, they use a software as a service model and form a single payment gateway for their clients (merchants) to multiple payment methods. 
[read more](https://en.wikipedia.org/wiki/Payment_service_provider)

## Installation

SDK availble on NuGet.

## Requirements

Fondy account - [Register here](https://portal.fondy.eu/mportal/#/account/registration)

Newtonsoft.json (JSON.NET)


## Simple Start
```csharp
using CloudIpspSDK;
using CloudIpspSDK.Checkout;

Config.MerchantId = 1396424;
Config.SecretKey = "test";

var req = new CheckoutRequest {
  order_id = Guid.NewGuid().ToString("N"),
  amount = 100000,
  order_desc = "checkout json demo",
  currency = "EUR"
};
var resp = new Url().Post(req);
if (resp.Error == null) {
 string url = resp.checkout_url;
}
```
# Api

See [docs](https://docs.fondy.eu/)
## Examples
To check it you can use build-in ISS server
[http://localhost:7777/](http://localhost:7777/)
