using Entities;
using Repositories.Interfaces;

namespace Repositories.Implements
{
    internal class TutionFeeScheduleRepository : RepositoryBase<TutionFeeSchedule>, ITutionFeeScheduleRepository
    {
        public TutionFeeScheduleRepository(TutorWebContext dataContext) : base(dataContext) { }
    }
}
