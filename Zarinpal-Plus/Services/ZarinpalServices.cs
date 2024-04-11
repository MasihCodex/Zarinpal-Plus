using Leaf.xNet;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;
using ZarinpalPlus.Dtos;
using ZarinpalPlus.Models;

namespace ZarinpalPlus.Services
{
    public class ZarinpalServices
    {
        String ApiUrl = "https://api.zarinpal.com";
        String PayUrl = "https://www.zarinpal.com";

        StatusHelper StatusHelper = new StatusHelper();

        public ResponseModel RequestSource { get; private set; } = new ResponseModel();
        public VerifyResponseModel VerifySource { get; private set; } = new VerifyResponseModel();

        public String GenerateUrl()
        {
            if (RequestSource == null)
                return String.Empty;

            if (RequestSource.Errors != null)
                return String.Empty;

            return $"{PayUrl}/pg/StartPay/{RequestSource?.Data?.Authority}";
        }

        public async Task<ResponseModel> RequestAsync(RequestModel Model)
        {
            return await Task.Run(() =>
            {
                var Http = new HttpRequest();

                Http.UserAgent = "Zarinpal-Plus(1.0)";
                Http.KeepAlive = true;
                Http.IgnoreProtocolErrors = true;

                Http.AddHeader("Accept", "application/json");

                var Dto = new RequestDto()
                {
                    amount = Model.Amount,
                    callback_url = Model.CallBackUrl,
                    description = Model.Description,
                    currency = Model.UnitType.ToString(),
                    merchant_id = Model.MerchantId.ToString(),
                    metadata = new { }
                };

                if (Model.MetaData != null)
                    Dto.metadata = Model.MetaData;

                var Payload = JsonConvert.SerializeObject(Dto);

                var Request = Http.Post($"{ApiUrl}/pg/v4/payment/request.json", Encoding.UTF8.GetBytes(Payload), "application/json");

                var DeseryalizeRequest = JsonConvert.DeserializeObject<ResponseDto>(Request.ToString());

                if (DeseryalizeRequest == null)
                    return RequestSource;

                var HasError = false;

                if (DeseryalizeRequest.errors?.ToString() != "[]")
                {
                    DeseryalizeRequest.errors = JsonConvert.DeserializeObject<ErrorDto>(DeseryalizeRequest.errors.ToString());

                    HasError = true;
                }

                if (DeseryalizeRequest.data?.ToString() != "[]")
                {
                    DeseryalizeRequest.data = JsonConvert.DeserializeObject<DataDto>(DeseryalizeRequest.data.ToString());

                    HasError = false;
                }

                if (HasError)
                {
                    if (DeseryalizeRequest.errors is ErrorDto EDto)
                    {
                        RequestSource = new ResponseModel()
                        {
                            Data = null,
                            Errors = EDto.validations,
                            Status = StatusHelper.MapFromStatus(EDto.code)
                        };
                    }
                }
                else
                {
                    if (DeseryalizeRequest.data is DataDto DDto)
                    {
                        RequestSource = new ResponseModel()
                        {
                            Errors = null,
                            Data = new DataModel()
                            {
                                Authority = DDto.authority,
                                FeeType = DDto.fee_type,
                                Fee = DDto.fee,
                            },
                            Status = StatusHelper.MapFromStatus(DDto.code)
                        };
                    }
                }

                return RequestSource;
            });
        }
        public async Task<VerifyResponseModel> VerifyAsync(VerifyRequestModel Model)
        {
            return await Task.Run(() =>
            {
                var Http = new HttpRequest();

                Http.UserAgent = "Zarinpal-Plus(1.0)";
                Http.KeepAlive = true;
                Http.IgnoreProtocolErrors = true;

                Http.AddHeader("Accept", "application/json");

                var Dto = new VerifyRequestDto()
                {
                    amount = Model.Amount,
                    authority = Model.Authority,
                    merchant_id = Model.MerchantId.ToString()
                };

                var Payload = JsonConvert.SerializeObject(Dto);

                var Request = Http.Post($"{ApiUrl}/pg/v4/payment/verify.json", Encoding.UTF8.GetBytes(Payload), "application/json");

                var DeseryalizeRequest = JsonConvert.DeserializeObject<ResponseDto>(Request.ToString());

                if (DeseryalizeRequest == null)
                    return VerifySource;

                var HasError = false;

                if (DeseryalizeRequest.errors?.ToString() != "[]")
                {
                    DeseryalizeRequest.errors = JsonConvert.DeserializeObject<ErrorDto>(DeseryalizeRequest.errors.ToString());

                    HasError = true;
                }

                if (DeseryalizeRequest.data?.ToString() != "[]")
                {
                    DeseryalizeRequest.data = JsonConvert.DeserializeObject<VerifyDataDto>(DeseryalizeRequest.data.ToString());

                    HasError = false;
                }

                if (HasError)
                {
                    if (DeseryalizeRequest.errors is ErrorDto EDto)
                    {
                        VerifySource = new VerifyResponseModel()
                        {
                            Data = null,
                            Errors = EDto.validations,
                            Status = StatusHelper.MapFromStatus(EDto.code)
                        };
                    }
                }
                else
                {
                    if (DeseryalizeRequest.data is VerifyDataDto DDto)
                    {
                        VerifySource = new VerifyResponseModel()
                        {
                            Errors = null,
                            Data = new VerifyDataModel
                            {
                                CardHash = DDto.card_hash,
                                CardPan = DDto.card_pan,
                                Code = DDto.code,
                                Fee = DDto.fee,
                                FeeType = DDto.fee_type,
                                RefrenceId = DDto.ref_id
                            },
                            Status = StatusHelper.MapFromStatus(DDto.code)
                        };
                    }
                }

                return VerifySource;
            });
        }
    }
}
