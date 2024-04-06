namespace Zarinpal_Plus.Models
{
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
}
