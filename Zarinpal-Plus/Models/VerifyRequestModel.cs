using System;

namespace ZarinpalPlus.Models
{
    public class VerifyRequestModel
    {
        public Guid MerchantId { get; set; }

        public int Amount { get; set; }

        public string Authority { get; set; } = null!;
    }
}
