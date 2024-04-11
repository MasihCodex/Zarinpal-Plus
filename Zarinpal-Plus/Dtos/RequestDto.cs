using System;

namespace ZarinpalPlus.Dtos
{
    public class RequestDto
    {
        public int amount { get; set; }

        public String merchant_id { get; set; } = null!;
        public String description { get; set; } = null!;
        public String callback_url { get; set; } = null!;

        public String? currency { get; set; }
        public object? metadata { get; set; }
    }
}
