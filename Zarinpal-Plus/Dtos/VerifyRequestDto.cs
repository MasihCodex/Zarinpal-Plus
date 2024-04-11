namespace ZarinpalPlus.Dtos
{
    public class VerifyRequestDto
    {
        public int amount { get; set; }

        public string merchant_id { get; set; } = null!;
        public string authority { get; set; } = null!;
    }
}
