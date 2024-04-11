namespace Zarinpal_Plus.Models
{
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
}
