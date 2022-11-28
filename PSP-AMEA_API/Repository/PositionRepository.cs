using PSP_AMEA_API.DataModels;

namespace PSP_AMEA_API.Repository
{
    public class PositionRepository : IPositionRepository
    {
        private readonly List<Position> positions = new()
        {
            new Position() { Name = "Manger",  Id = Guid.NewGuid() },
            new Position() { Name = "Manger",  Id = Guid.NewGuid() },
            new Position() { Name = "Manger",  Id = Guid.NewGuid() }
        };

        public IEnumerable<Position> GetPositions()
        {
            return positions;
        }

        public void CreatePosition(Position position)
        {
           positions.Add(position);
        }
        public Position GetPosition(Guid id)
        {
            return positions.SingleOrDefault(position => position.Id == id);
        }



    }
}
