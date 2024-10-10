using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repos
{
    public interface ITutorRepository
    {
        Task CreateTutorDetailsAsync(TutorDetails tutorDetails);
        Task<bool> UpdateTutorDetailsAsync(Guid id, TutorDetails tutorDetails);
        Task<bool> DeleteTutorDetailsAsync(Guid id);
        Task<IEnumerable<TutorDetails>> GetAllTutorDetailsAsync ();
        Task<TutorDetails?> GetTutorDetailsAsync (Guid id);
    }
}
