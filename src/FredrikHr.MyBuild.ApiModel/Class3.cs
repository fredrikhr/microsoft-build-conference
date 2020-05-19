using System;
using System.Collections.Generic;

namespace FredrikHr.MyBuild.ApiModel
{

    public class ScheduleIdCollection
    {
        public List<Guid> Sessions { get; } = new List<Guid>();
        public List<Guid> BookedLabs { get; } = new List<Guid>();
        public List<Guid> WaitlistedSessions { get; } = new List<Guid>();
    }

}
