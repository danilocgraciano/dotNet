using Tracker.Contracts;
using Tracker.Models;

namespace Tracker.Repositories
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        public BoardRepository(TrackerContext TrackerContext) : base(TrackerContext)
        {
        }
    }
}
