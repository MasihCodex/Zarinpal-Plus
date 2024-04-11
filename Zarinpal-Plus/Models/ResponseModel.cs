namespace Zarinpal_Plus.Models
{
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
}
