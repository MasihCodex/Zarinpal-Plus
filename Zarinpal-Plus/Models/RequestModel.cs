namespace Zarinpal_Plus.Models
{
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
}
