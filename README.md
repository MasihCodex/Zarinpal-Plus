# Zarinpal-Plus
  شما با استفاده از این کتاب خانه میتوانید به تمامی سرویس های عمومی زرین پال در سی شارپ بصورت گسترده دست رسی داشته باشید.

# آموزش استفاده

## استفاده سریع

  > ساخت سازنده

```
using Zarinpal_Plus.Services;

var ZRequest = new ZarinpalServices();
```
  > ساخت درگاه (Request)
```
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
```
var Url = ZRequest.GenerateUrl();
```
  > برسی جواب درگاه ساخته شده (Verify)
```
var VResponse = ZRequest.VerifyAsync(new Zarinpal_Plus.Models.VerifyRequestModel()
{
    Amount = 25 * 1000,
    MerchantId = Guid.Parse("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"),
    Authority = "A00000000000000000000000000217885159"
}).Result;
```

## توضیحات تکمیلی

  ### جدول وضعیت

| نوع | وضعیت | کد وضعیت | پیام فارسی |
| :---: | :---: | :---: | ---: |
| خطای اعتبار سنجی1- مرچنت کد داخل تنظیمات وارد نشده باشد-2 آدرس بازگشت (callbackurl) وارد نشده باشد -3 توضیحات (description ) وارد نشده باشد و یا از حد مجاز 500 کارکتر بیشتر باشد -4 مبلغ پرداختی کمتر یا بیشتر از حد مجاز | -9 | Error | public |
| ای پی یا مرچنت كد پذیرنده صحیح نیست. | -10 | Error | public |
| مرچنت کد فعال نیست، پذیرنده مشکل خود را به امور مشتریان زرین‌پال ارجاع دهد. | -11 | Error | public |
| تلاش بیش از دفعات مجاز در یک بازه زمانی کوتاه به امور مشتریان زرین پال اطلاع دهید | -12 | Error | public |
| درگاه پرداخت به حالت تعلیق در آمده است، پذیرنده مشکل خود را به امور مشتریان زرین‌پال ارجاع دهد. | -15 | Error | public |
| سطح تایید پذیرنده پایین تر از سطح نقره ای است. | -16 | Error | public |
| محدودیت پذیرنده در سطح آبی | -17 | Error | public |
| عملیات موفق | 100 | Success | public |
| پذیرنده اجازه دسترسی به سرویس تسویه اشتراکی شناور را ندارد. | -30 | Error | PaymentRequest |
| حساب بانکی تسویه را به پنل اضافه کنید. مقادیر وارد شده برای تسهیم درست نیست. پذیرنده جهت استفاده از خدمات سرویس تسویه اشتراکی شناور، باید حساب بانکی معتبری به پنل کاربری خود اضافه نماید. | -31 | Error | PaymentRequest |
| مبلغ وارد شده از مبلغ کل تراکنش بیشتر است. | -32 | Error | PaymentRequest |
| درصدهای وارد شده صحیح نیست. | -33 | Error | PaymentRequest |
| مبلغ وارد شده از مبلغ کل تراکنش بیشتر است. | -34 | Error | PaymentRequest |
| تعداد افراد دریافت کننده تسهیم بیش از حد مجاز است. | -35 | Error | PaymentRequest |
| حداقل مبلغ جهت تسهیم باید ۱۰۰۰۰ ریال باشد | -36 | Error | PaymentRequest |
| یک یا چند شماره شبای وارد شده برای تسهیم از سمت بانک غیر فعال است. | -37 | Error | PaymentRequest |
| خطا٬عدم تعریف صحیح شبا٬لطفا دقایقی دیگر تلاش کنید. | -38 | Error | PaymentRequest |
| خطایی رخ داده است به امور مشتریان زرین پال اطلاع دهید | -39 | Error | PaymentRequest |
|  | -40 | Error | PaymentRequest |
| حداکثر مبلغ پرداختی ۱۰۰ میلیون تومان است | -41 | Error | PaymentRequest |
| مبلغ پرداخت شده با مقدار مبلغ ارسالی در متد وریفای متفاوت است. | -50 | Error | PaymentVerify |
| پرداخت ناموفق | -51 | Error | PaymentVerify |
| خطای غیر منتظره‌ای رخ داده است. پذیرنده مشکل خود را به امور مشتریان زرین‌پال ارجاع دهد. | -52 | Error | PaymentVerify |
| پرداخت متعلق به این مرچنت کد نیست. | -53 | Error | PaymentVerify |
| اتوریتی نامعتبر است. | -54 | Error | PaymentVerify |
| تراکنش مورد نظر یافت نشد | -55 | Error | PaymentVerify |
| تراکنش وریفای شده است. | 101 | Success | PaymentVerify |
| PaymentVerify | Error | -55 | تراکنش مورد نظر یافت نشد |
| PaymentVerify | Success | 101 | تراکنش وریفای شده است. |


