using Zarinpal_Plus.Services;

var ZRequest = new ZarinpalServices();

var Response = ZRequest.RequestAsync(new Zarinpal_Plus.Models.RequestModel()
{
    MerchantId = Guid.Parse("8d27e894-df66-4c9b-87bc-270618fe3966"),
    Description = "توضیحات تستی",
    Amount = 25 * 1000,
    CallBackUrl = "https://www.google.com",
    UnitType = Zarinpal_Plus.Models.UnitType.IRT
}).Result;

var Url = ZRequest.GenerateUrl();

Console.WriteLine(Url);

var VCode = Console.ReadLine();

var VResponse = ZRequest.VerifyAsync(new Zarinpal_Plus.Models.VerifyRequestModel()
{
    Amount = 25 * 1000,
    MerchantId = Guid.Parse("8d27e894-df66-4c9b-87bc-270618fe3966"),
    Authority = VCode.ToString()
}).Result;

Console.WriteLine(VResponse.Status?.StatusCode);

Console.ReadKey();