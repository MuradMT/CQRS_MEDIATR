namespace CQRS_MEDIATR.Model
{
    public class ServiceResponse
    {
        public object? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "there is no problem,everything is ok";
    }
}
