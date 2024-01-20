namespace EmployManagementSystemAPIs.Model
{
    public class SalaryInfo : BaseEntity
    {
        public DateTime SalaryMonth { get; set; }
        public int BasicSalary { get; set; }
        public int Allowance { get; set; }
        public int Bonus { get; set; }
        public int TotalSalary { get; set; }
        public int BasicId { get; set; }

    }
}
