using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SynelTestTask.Constants;
using SynelTestTask.Dto;
using SynelTestTask.Dto.Response;
using SynelTestTask.Entity;
using SynelTestTask.Service.I;

namespace SynelTestTask.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEmployeeService _employeeService;

        [BindProperty]
        public List<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();

        public IndexModel(ILogger<IndexModel> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _employeeService.FindAll(EntityStatus.Active);
            if (response.Status == SynelHttpResponse<ICollection<EmployeeDTO>>.HttpStatus.OK && response.Object != null)
            {
                Employees = response.Object.ToList();
            }

            var file = Request.Form.Files[0];


            if (file != null && file.Length > 0)
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    int lineNumber = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = await reader.ReadLineAsync();
                        if (lineNumber == 0)
                        {
                            lineNumber++;
                            continue;
                        }

                        var values = line.Split(',');
                        var dto = new EmployeeDTO
                        {
                            PayrollNumber = values[0],
                            ForeName = values[1],
                            Surname = values[2],
                            DateOfBirth = DateTime.TryParse(values[3], out var dob) ? dob : null,
                            Telephone = values[4],
                            Mobile = values[5],
                            MainAddress = values[6],
                            SecondaryAddress = string.IsNullOrWhiteSpace(values[7]) ? null : values[7],
                            Postcode = values[8],
                            EmailHome = values[9],
                            StartDate = DateTime.TryParse(values[10], out var startDate) ? startDate : null
                        };
                        // save in DB then update the content
                        await _employeeService.Add(dto);
                        Employees.Add(dto);

                        lineNumber++;
                    }
                }
            }

            return Page();
        }


        public async Task OnGetAsync()
        {
            var response = await _employeeService.FindAll(EntityStatus.Active);
            if (response.Status == SynelHttpResponse<ICollection<EmployeeDTO>>.HttpStatus.OK && response.Object != null)
            {
                Employees = response.Object.ToList();
            }
        }
    }
}
