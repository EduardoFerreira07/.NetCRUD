namespace EmployeAdminPortal.Models
{
    public class UpdateEmployeDTO
    {
        public required string Email { get; set; }

        public string? Phone { get; set; }

        public decimal Salary { get; set; }
    }
}
