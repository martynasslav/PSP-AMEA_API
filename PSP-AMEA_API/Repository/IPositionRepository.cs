using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
    public interface IPositionRepository
    {
        void CreatePosition(Position position);
        Position GetPosition(Guid id);
        IEnumerable<Position> GetPositions();
    }
}