namespace ZarinpalPlus.Dtos
{
    public class VerifyDataDto
    {
        public int code { get; set; }
        public string message { get; set; }
        public string card_hash { get; set; }
        public string card_pan { get; set; }
        public int ref_id { get; set; }
        public string fee_type { get; set; }
        public int fee { get; set; }
    }
}
