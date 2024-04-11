namespace Zarinpal_Plus.Dtos
{
    public class ResponseDto
    {
        public object? data { get; set; }
        public object? errors { get; set; }
    }
    public class DataDto
    {
        public int code { get; set; }
        public int fee { get; set; }

        public string? message { get; set; }
        public string? authority { get; set; }
        public string? fee_type { get; set; }
    }

    public class ErrorDto
    {
        public int code { get; set; }

        public string? message { get; set; }
        public object? validations { get; set; }
    }
}
