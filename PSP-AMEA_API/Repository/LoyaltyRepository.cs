using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
    public class LoyaltyRepository : ILoyaltyRepository
    {
        private readonly List<Loyalty> loyalties = new()
        {
            new Loyalty() { Id = Guid.NewGuid(), Name = "Programa 1", Description = "Aprasymas 1"},
            new Loyalty() { Id = Guid.NewGuid(), Name = "Programa 2", Description = "Aprasymas 2" }
        };

        public void CreateLoyaltyProgram(Loyalty loyalty)
        {
            loyalties.Add(loyalty);
        }

        public IEnumerable<Loyalty> GetAllLoyaltyPrograms()
        {
            return loyalties;
        }

        public Loyalty GetLoyaly(Guid id)
        {
            return loyalties.SingleOrDefault(loyalty => loyalty.Id == id);
        }

        public void UpdateLoyaltyProgram(Loyalty loyalty)
        {
            var index = loyalties.FindIndex(existingLoyalty => existingLoyalty.Id == loyalty.Id);
            loyalties[index] = loyalty;
        }
    }
}
