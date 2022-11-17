using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
    public static class Extensions
    {
        public static EmployeeDto AsDto(this Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PersonalCode = employee.PersonalCode,
            };
        }

        public static LoyaltyDto AsDto(this Loyalty loyalty)
        {
            return new LoyaltyDto
            {
                Id= loyalty.Id,
                Name = loyalty.Name,
                Description = loyalty.Description,
                TenantId = loyalty.TenantId,
            };
        }
    }
}
