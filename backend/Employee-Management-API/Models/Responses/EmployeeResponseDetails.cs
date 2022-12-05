namespace Employee_Management_API.Models.Responses
{
    public class EmployeeResponseDetails
    {
        public bool Success { get; set; }
        public bool NotFound { get; set; }
        public string Exception { get; set; }
        public int StatusCode { get; set; } 
        public string Message { get; set; }
        public List<Employee> ListEmpoyees { get; set; }
        public Employee SingleEmployee { get; set; }
    }
}
