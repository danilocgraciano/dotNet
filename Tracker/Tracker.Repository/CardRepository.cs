using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tracker.Models;

namespace Tracker.Repository
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(TrackerContext TrackerContext) : base(TrackerContext)
        {
        }
    }
}
