using System;
using System.Collections.Generic;
using System.Linq;

namespace Tracker.Shared
{
    public class PaginatedList<T>
    {

        public int Total { get; private set; }
        public int Offset { get; private set; }
        public int Limit { get; private set; }
        public IEnumerable<T> Results { get; set; }

        public PaginatedList(IQueryable<T> source, int offset, int limit = 4)
        {
            Offset = offset;
            Limit = limit;
            Total = source.Count();
            Results = source.Skip(offset * limit).Take(limit);
        }
    }
}
