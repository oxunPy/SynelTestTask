namespace SynelTestTask.Dto
{
    public class EmployeeDTO : BaseDTO
    {
        public string? PayrollNumber { get; set; }

        public string? ForeName { get; set; }

        public string? Surname { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Telephone { get; set; }

        public string? Mobile { get; set; }

        public string? MainAddress { get; set; }

        public string? SecondaryAddress { get; set; }

        public string? Postcode { get; set; }

        public string? EmailHome { get; set; }

        public DateTime? StartDate { get; set; }
    }
}
