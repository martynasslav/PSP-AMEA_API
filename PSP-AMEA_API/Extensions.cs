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

        public static CustomerDto AsDto(this Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                TenantId = customer.TenantId,
            };
        }

        public static UserDto AsDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id
            };
        }

        public static PositionDto AsDto(this Position position)
        {
            return new PositionDto
            {
                Id = position.Id
            };
        }
    }
}
