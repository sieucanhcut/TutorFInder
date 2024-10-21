using Entities;
using Repositories.Interfaces;

namespace Repositories.Implements
{
    public class TutorAdvertisementRepository : RepositoryBase<TutorAdvertisement>, ITutorAdvertisementRepository
    {
        public TutorAdvertisementRepository(TutorWebContext dataContext) : base(dataContext)
        {
        }

    }
}
