using DataAccess.dbContext_Access;
using DataAccess.Repos;
using DataObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Service
{
    public class LocationRepository : ILocationRepository
    {
        private readonly TutorWebContext _tutorWebContext;
        public LocationRepository(TutorWebContext tutorWebContext)
        {
            _tutorWebContext = tutorWebContext;
        }
        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            return await _tutorWebContext.Locations.ToListAsync();
        }
    }
}
