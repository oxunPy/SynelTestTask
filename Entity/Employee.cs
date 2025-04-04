using SynelTestTask.Dto;

namespace SynelTestTask.Entity
{
    public class Employee : BaseEntity
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

        public override T ToDTO<T>()
        {
            T dto = new T();

            if (dto is EmployeeDTO e)
            {
                e.Id = this.Id;
                e.PayrollNumber = this.PayrollNumber;
                e.ForeName = this.ForeName;
                e.Surname = this.Surname;
                e.DateOfBirth = this.DateOfBirth;
                e.Telephone = this.Telephone;
                e.Mobile = this.Mobile;
                e.MainAddress = this.MainAddress;
                e.SecondaryAddress = this.SecondaryAddress;
                e.Postcode = this.Postcode;
                e.EmailHome = this.EmailHome;
                e.StartDate = this.StartDate;
            }

            return dto;
        }

        public static Employee FromDTO(EmployeeDTO dto)
        {
            return new Employee()
            {
                Id = dto.Id,
                PayrollNumber = dto.PayrollNumber,
                ForeName = dto.ForeName,
                Surname = dto.Surname,
                DateOfBirth = dto.DateOfBirth,
                Telephone = dto.Telephone,
                Mobile = dto.Mobile,
                MainAddress = dto.MainAddress,
                SecondaryAddress = dto.SecondaryAddress,
                Postcode = dto.Postcode,
                EmailHome = dto.EmailHome,
                StartDate = dto.StartDate
            };
        }
    }
}
