# Zarinpal-Plus
  شما با استفاده از این کتاب خانه میتوانید به تمامی سرویس های عمومی زرین پال در سی شارپ بصورت گسترده دسترسی داشته باشید.

# آموزش استفاده

## استفاده سریع

```csharp
dotnet add package Zarinpal-Plus --version 1.0.1
```
  > ساخت سازنده

```csharp
using ZarinpalPlus.Services;

var ZRequest = new ZarinpalServices();
```
  > ساخت درگاه (Request)
```csharp
var Response = ZRequest.RequestAsync(new Zarinpal_Plus.Models.RequestModel()
{
    MerchantId = Guid.Parse("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"),
    Description = "توضیحات تستی",
    Amount = 11 * 1000,
    CallBackUrl = "https://www.YOUR_WEBSITE.com",
    UnitType = Zarinpal_Plus.Models.UnitType.IRT,
    MetaData = new Zarinpal_Plus.Models.RequestMetaDataModel()
    {
        Email = "TESTMAIL@GMAIL.COM",
        Mobile = "09000000000",
        OrderId = "000000"
    }
}).Result;
```
  > ساخت لینک درگاه (Url)
```csharp
var Url = ZRequest.GenerateUrl();
```
  > برسی جواب درگاه ساخته شده (Verify)
```csharp
var VResponse = ZRequest.VerifyAsync(new Zarinpal_Plus.Models.VerifyRequestModel()
{
    Amount = 25 * 1000,
    MerchantId = Guid.Parse("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"),
    Authority = "A00000000000000000000000000217885159"
}).Result;
```

## توضیحات تکمیلی

### مدل ها
  > در تابع ساخت درگاه (RequestAsync) $${\color{lightgreen}Request}$$

```csharp
    public class RequestModel
    {
        public UnitType? UnitType { get; set; }

        public Guid MerchantId { get; set; }

        public int Amount { get; set; }

        public String CallBackUrl { get; set; } = null!;
        public String Description { get; set; } = null!;

        public RequestMetaDataModel? MetaData { get; set; }
    }

    public class RequestMetaDataModel
    {
        public String? Email { get; set; }
        public String? Mobile { get; set; }
        public String? OrderId { get; set; }
    }

    public enum UnitType
    {
        IRR, IRT
    }
```
 > در تابع ساخت درگاه (RequestAsync) $${\color{lightgreen}Response}$$

```csharp
    public class ResponseModel
    {
        public DataModel? Data { get; set; }

        public object? Errors { get; set; }

        public StatusModel? Status { get; set; }
    }
    public class DataModel
    {
        public int Fee { get; set; }

        public string? Authority { get; set; }
        public string? FeeType { get; set; }
    }
```
   > در تابع برسی درخواست درگاه (VerifyAsync) $${\color{lightblue}Request}$$
```csharp
    public class VerifyRequestModel
    {
        public Guid MerchantId { get; set; }

        public int Amount { get; set; }

        public string Authority { get; set; } = null!;
    }
```
  
  > در تابع برسی درخواست درگاه (VerifyAsync) $${\color{lightblue}Response}$$


```csharp
    public class VerifyResponseModel
    {
        public VerifyDataModel? Data { get; set; }

        public object? Errors { get; set; }

        public StatusModel? Status { get; set; }
    }

    public class VerifyDataModel
    {
        public int Code { get; set; }
        public int RefrenceId { get; set; }
        public int Fee { get; set; }

        public string CardHash { get; set; }
        public string CardPan { get; set; }
        public string FeeType { get; set; }
    }
```
  > مدل (StatusModel)
```csharp
    public class StatusModel
    {
        public int StatusCode { get; set; }

        public string Status { get; set; }
        public string Type { get; set; }

        public StatusMessageModel Messages { get; set; }
    }
    public class StatusMessageModel
    {
        public string Persion { get; set; }
        public string English { get; set; }
    }
```

### جدول وضعیت

| نوع | وضعیت | کد وضعیت | پیام فارسی |
| :---: | :---: | :---: | ---: |
| public | Error | -9 | خطای اعتبار سنجی1- مرچنت کد داخل تنظیمات وارد نشده باشد-2 آدرس بازگشت (callbackurl) وارد نشده باشد -3 توضیحات (description ) وارد نشده باشد و یا از حد مجاز 500 کارکتر بیشتر باشد -4 مبلغ پرداختی کمتر یا بیشتر از حد مجاز |
| public | Error | -10 | ای پی یا مرچنت كد پذیرنده صحیح نیست. |
| public | Error | -11 | مرچنت کد فعال نیست، پذیرنده مشکل خود را به امور مشتریان زرین‌پال ارجاع دهد. |
| public | Error | -12 | تلاش بیش از دفعات مجاز در یک بازه زمانی کوتاه به امور مشتریان زرین پال اطلاع دهید |
| public | Error | -15 | درگاه پرداخت به حالت تعلیق در آمده است، پذیرنده مشکل خود را به امور مشتریان زرین‌پال ارجاع دهد. |
| public | Error | -16 | سطح تایید پذیرنده پایین تر از سطح نقره ای است. |
| public | Error | -17 | محدودیت پذیرنده در سطح آبی |
| public | Success | 100 | عملیات موفق |
| PaymentRequest | Error | -30 | پذیرنده اجازه دسترسی به سرویس تسویه اشتراکی شناور را ندارد. |
| PaymentRequest | Error | -31 | حساب بانکی تسویه را به پنل اضافه کنید. مقادیر وارد شده برای تسهیم درست نیست. پذیرنده جهت استفاده از خدمات سرویس تسویه اشتراکی شناور، باید حساب بانکی معتبری به پنل کاربری خود اضافه نماید. |
| PaymentRequest | Error | -32 | مبلغ وارد شده از مبلغ کل تراکنش بیشتر است. |
| PaymentRequest | Error | -33 | درصدهای وارد شده صحیح نیست. |
| PaymentRequest | Error | -34 | مبلغ وارد شده از مبلغ کل تراکنش بیشتر است. |
| PaymentRequest | Error | -35 | تعداد افراد دریافت کننده تسهیم بیش از حد مجاز است. |
| PaymentRequest | Error | -36 | حداقل مبلغ جهت تسهیم باید ۱۰۰۰۰ ریال باشد |
| PaymentRequest | Error | -37 | یک یا چند شماره شبای وارد شده برای تسهیم از سمت بانک غیر فعال است. |
| PaymentRequest | Error | -38 | خطا٬عدم تعریف صحیح شبا٬لطفا دقایقی دیگر تلاش کنید. |
| PaymentRequest | Error | -39 | خطایی رخ داده است به امور مشتریان زرین پال اطلاع دهید |
| PaymentRequest | Error | -40 |  |
| PaymentRequest | Error | -41 | حداکثر مبلغ پرداختی ۱۰۰ میلیون تومان است |
| PaymentVerify | Error | -50 | مبلغ پرداخت شده با مقدار مبلغ ارسالی در متد وریفای متفاوت است. |
| PaymentVerify | Error | -51 | پرداخت ناموفق |
| PaymentVerify | Error | -52 | خطای غیر منتظره‌ای رخ داده است. پذیرنده مشکل خود را به امور مشتریان زرین‌پال ارجاع دهد. |
| PaymentVerify | Error | -53 | پرداخت متعلق به این مرچنت کد نیست. |
| PaymentVerify | Error | -54 | اتوریتی نامعتبر است. |
| PaymentVerify | Error | -55 | تراکنش مورد نظر یافت نشد |
| PaymentVerify | Success | 101 | تراکنش وریفای شده است. |

