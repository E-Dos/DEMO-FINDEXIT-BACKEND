using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TEMPLATE_ELDOS_BACKEND.Models
{
    public class AgreementUploadModel
    {
        public int? AgreementId { get; set; }
        public IFormFile? UploadFile { get; set; }
    }

    public class SmsResponseDto
    {
        public string? bulk_id { get; set; }
        public string? message_id { get; set; }
        public string? extra_id { get; set; }
        public string? to { get; set; }
        public string? sender { get; set; }
        public string? text { get; set; }
        public string? sent_at { get; set; }
        public string? done_at { get; set; }
        public string? sms_count { get; set; }
        public string? callback_data { get; set; }
        public string? status { get; set; }
        public string? mnc { get; set; }
        public string? err { get; set; }
    }

    public class SmsErrorResponseDto
    {
        public string? error_code { get; set; }
        public string? error_message { get; set; }
    }

    [XmlRoot("response")]
    public class SmsXmlResponseDto
    {
        public string? action { get; set; }
        public SmsErrorXmlResponseDataDto? data { get; set; }
        public string? errorcode { get; set; }
        public string? errormessage { get; set; }
    }

    public class SmsErrorXmlResponseDataDto
    {
        public SmsErrorXmlResponseDataAcceptReportDto? acceptreport { get; set; }
    }

    public class SmsErrorXmlResponseDataAcceptReportDto
    {
        public string? statuscode { get; set; }
        public string? statusmessage { get; set; }
        public string? messageid { get; set; }
        public string? originator { get; set; }
        public string? recipient { get; set; }
        public string? messagetype { get; set; }
        public string? messagedata { get; set; }
    }
    public class PageParam
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string? FilterText { get; set; }
    }

    public class UserDTO
    {
        public int Id { get; set; }
        //[JsonProperty("name")]
        public string Username { get; set; }
        public string? Password { get; set; } = null!;
        //[JsonProperty("roleId")]
        public int? RoleId { get; set; }
        public virtual bool CanExport { get; set; }
        public virtual bool CanEdit { get; set; }
    }
    public class LoginModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
    public class RegisterModel
    {
        public string? Username { get; set; }
        public string? FullName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
