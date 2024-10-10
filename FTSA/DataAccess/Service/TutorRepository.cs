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
    public class TutorRepository : ITutorRepository
    {
        private readonly TutorWebContext _tutorWebContext;
        public TutorRepository(TutorWebContext tutorWebContext)
        {
            _tutorWebContext = tutorWebContext;
        }
        public async Task CreateTutorDetailsAsync(TutorDetails tutorDetails)
        {
            using var transaction = await _tutorWebContext.Database.BeginTransactionAsync();
            try
            {
                var newTutorDetails = new TutorDetails
                {
                    UserId = tutorDetails.UserId,
                    AcademicSpecialty = tutorDetails.AcademicSpecialty,
                    Contacts = tutorDetails.Contacts,
                    Faculty = tutorDetails.Faculty,
                    OnlineTutor = tutorDetails.OnlineTutor,
                    SelfIntroduction = tutorDetails.SelfIntroduction,
                    TeachingAchievement = tutorDetails.TeachingAchievement,
                    Title = tutorDetails.Title,
                    TutorId = tutorDetails.TutorId,
                    Transportation = tutorDetails.Transportation,
                    IncludingPhotos = tutorDetails.IncludingPhotos,
                    Photo = tutorDetails.Photo
                };
                await _tutorWebContext.Tutors.AddAsync(tutorDetails);
                await _tutorWebContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteTutorDetailsAsync(Guid id)
        {
            var tutorDetails = await _tutorWebContext.Tutors.FirstAsync(p => p.UserId == id);

            if (tutorDetails == null)
            {
                return false;
            }

            _tutorWebContext.Remove(tutorDetails);
            return await _tutorWebContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<TutorDetails>> GetAllTutorDetailsAsync()
        {
            return await _tutorWebContext.Tutors.ToListAsync();
        }

        public async Task<TutorDetails?> GetTutorDetailsAsync(Guid id)
        {
            var tutor = await _tutorWebContext.Tutors.FindAsync(id);

            if (tutor == null)
            {
                return default;
            }
            return tutor;
        }

        public async Task<bool> UpdateTutorDetailsAsync(Guid id, TutorDetails tutorDetails)
        {
            var tutorDetailsUpdate = await _tutorWebContext.Tutors.FindAsync(id);

            if (tutorDetailsUpdate == null)
            {
                return false;
            }
            tutorDetailsUpdate.AcademicSpecialty = tutorDetails.AcademicSpecialty;
            tutorDetailsUpdate.Contacts = tutorDetails.Contacts;
            tutorDetailsUpdate.Faculty = tutorDetails.Faculty;
            tutorDetailsUpdate.OnlineTutor = tutorDetails.OnlineTutor;
            tutorDetailsUpdate.SelfIntroduction = tutorDetails.SelfIntroduction;
            tutorDetailsUpdate.TeachingAchievement = tutorDetails.TeachingAchievement;
            tutorDetailsUpdate.Title = tutorDetails.Title;
            tutorDetailsUpdate.TutorId = tutorDetails.TutorId;
            tutorDetailsUpdate.Transportation = tutorDetails.Transportation;
            tutorDetailsUpdate.IncludingPhotos = tutorDetails.IncludingPhotos;
            tutorDetailsUpdate.Photo = tutorDetails.Photo;
            _tutorWebContext.Tutors.Update(tutorDetailsUpdate);
            return await _tutorWebContext.SaveChangesAsync() > 0;
        }
    }
}
