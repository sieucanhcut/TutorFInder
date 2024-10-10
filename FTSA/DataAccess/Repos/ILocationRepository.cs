using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repos
{
    public interface ILocationRepository
    {
        public Task<IEnumerable<Location>> GetAllLocations();
    }
}
