using System;
using System.Collections.Generic;
using System.Text;
using Tracker.Models;

namespace Tracker.Repository
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        public BoardRepository(TrackerContext TrackerContext) : base(TrackerContext)
        {
        }
    }
}
