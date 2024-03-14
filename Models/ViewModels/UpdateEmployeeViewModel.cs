namespace Employee_Management_System.Models.ViewModels
{
    public class UpdateEmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        public string? ImageUrl { get; set; }
    }
}
