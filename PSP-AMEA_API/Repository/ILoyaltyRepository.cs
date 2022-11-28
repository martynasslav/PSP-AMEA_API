using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
    public interface ILoyaltyRepository
    {
        void CreateLoyaltyProgram(Loyalty loyalty);
        void UpdateLoyaltyProgram(Loyalty loyalty);
        IEnumerable<Loyalty> GetAllLoyaltyPrograms();
        Loyalty GetLoyaly(Guid id);
    }
}
