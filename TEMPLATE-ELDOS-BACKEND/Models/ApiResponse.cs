namespace TEMPLATE_ELDOS_BACKEND.Models
{
    public class ApiResponse
    {
        public int status { get; set; } = 200;
        public string message { get; set; } = "success";
        public object? result { get; set; }
    }
}
