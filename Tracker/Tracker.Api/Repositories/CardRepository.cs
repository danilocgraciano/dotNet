using Tracker.Contracts;
using Tracker.Models;

namespace Tracker.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(TrackerContext TrackerContext) : base(TrackerContext)
        {
        }
    }
}
