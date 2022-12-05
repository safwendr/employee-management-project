namespace Employee_Management_API.Models.Responses
{
    public class AuthResponse
    {
        public bool Success { get; set; }
        public bool NotFound { get; set; }
        public string Exception { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public User AuthUser { get; set; }  
        public string AccessToken { get; set; }
    }
}
