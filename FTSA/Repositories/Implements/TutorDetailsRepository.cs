using Entities;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using Repositories.Intefaces;
using Repositories.Interfaces;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories.Implements
{
    public class TutorDetailsRepository : RepositoryBase<TutorDetails>, ITutorDetailsRepository
    {
        private readonly TutorWebContext _webContext;
        public TutorDetailsRepository(TutorWebContext webContext) : base(webContext)
        {
            _webContext = webContext;
        }

        public void Create(RequestTutorDetails entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> DeleteAsync(Guid id)
        {
            var tutordetails = await _webContext.Tutors.FirstOrDefaultAsync(t => t.TutorId == id);

            if (tutordetails == null)
            {
                return false;
            }

            _webContext.Tutors.Remove(tutordetails);
            return await _webContext.SaveChangesAsync() > 0;
        }

        public void Delete(RequestTutorDetails entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<RequestTutorDetails>> FindByConditionAsync(Expression<Func<RequestTutorDetails, bool>> expression, bool trackChanges)
        {
            var query = _webContext.Tutors
                .Include(t => t.User).
                ThenInclude(u => u.Location)
        .Select(t => new RequestTutorDetails
        {
            UserId = t.UserId,
            AcademicSpecialty = t.AcademicSpecialty,
            City = t.User.Location.CityOrProvince,
            District = t.User.Location.District,
            DateOfBirth = t.User.DateOfBirth,
            Faculty = t.Faculty,
            Gender = t.User.Gender,
            Photo = t.Photo,
            IncludingPhotos = t.IncludingPhotos,
            OnlineTutor = t.OnlineTutor,
            PlaceOfWork = t.User.PlaceOfWork,
            SelfIntroduction = t.SelfIntroduction,
            TeachingAchievement = t.TeachingAchievement,
            Title = t.Title,
            Transportation = t.Transportation,
            UserName = t.User.UserName
        });

            if (!trackChanges)
            {
                query = query.AsNoTracking();
            }
            var filteredQuery = query.Where(expression);

            return await Task.FromResult(filteredQuery);
        }
        public void Update(RequestTutorDetails entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> UpdateAsync(RequestTutorDetails entity, Guid id)
        {
            var tutorDetailsUpdate = await _webContext.Tutors.FindAsync(id);

            if (tutorDetailsUpdate == null)
            {
                return false;
            }

            tutorDetailsUpdate.AcademicSpecialty = entity.AcademicSpecialty;
            tutorDetailsUpdate.Faculty = entity.Faculty;
            tutorDetailsUpdate.OnlineTutor = entity.OnlineTutor;
            tutorDetailsUpdate.SelfIntroduction = entity.SelfIntroduction;
            tutorDetailsUpdate.TeachingAchievement = entity.TeachingAchievement;
            tutorDetailsUpdate.Title = entity.Title;
            tutorDetailsUpdate.TutorId = entity.TutorId;
            tutorDetailsUpdate.Transportation = entity.Transportation;
            tutorDetailsUpdate.Photo = entity.Photo;
            tutorDetailsUpdate.IncludingPhotos = entity.IncludingPhotos;

            _context.Tutors.Update(tutorDetailsUpdate);
            return await _context.SaveChangesAsync() > 0;
        }

    async Task ITutorDetailsRepository.CreateAsync(TutorDetails entity)
        {
            using var transaction = await _webContext.Database.BeginTransactionAsync();
            try
            {
                var newTutorDetails = new TutorDetails
                {
                    UserId = entity.UserId,
                    AcademicSpecialty = entity.AcademicSpecialty,
                    Faculty = entity.Faculty,
                    OnlineTutor = entity.OnlineTutor,
                    SelfIntroduction = entity.SelfIntroduction,
                    TeachingAchievement = entity.TeachingAchievement,
                    Title = entity.Title,
                    TutorId = entity.TutorId,
                    Transportation = entity.Transportation,
                    Photo = entity.Photo,
                    IncludingPhotos = entity.IncludingPhotos
                };

                await _webContext.Tutors.AddAsync(newTutorDetails);
                await _webContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

        }

        async Task<IQueryable<RequestTutorDetails>> ITutorDetailsRepository.FindAllAsync(bool trackChanges)
        {
            return await Task.FromResult(
        trackChanges
            ? _webContext.Tutors
                .Include(t => t.User)
                .Select(tutor => new RequestTutorDetails
                {
                    UserId = tutor.User.UserId,
                    AcademicSpecialty = tutor.AcademicSpecialty,
                    Faculty = tutor.Faculty,
                    OnlineTutor = tutor.OnlineTutor,
                    SelfIntroduction = tutor.SelfIntroduction,
                    TeachingAchievement = tutor.TeachingAchievement,
                    Title = tutor.Title,
                    TutorId = tutor.TutorId,
                    Transportation = tutor.Transportation,
                    Photo = tutor.Photo,
                    IncludingPhotos = tutor.IncludingPhotos
                })
            : _webContext.Tutors
                .Include(t => t.User)
                .AsNoTracking()
                .Select(tutor => new RequestTutorDetails
                {
                    UserId = tutor.User.UserId,
                    AcademicSpecialty = tutor.AcademicSpecialty,
                    Faculty = tutor.Faculty,
                    OnlineTutor = tutor.OnlineTutor,
                    SelfIntroduction = tutor.SelfIntroduction,
                    TeachingAchievement = tutor.TeachingAchievement,
                    Title = tutor.Title,
                    TutorId = tutor.TutorId,
                    Transportation = tutor.Transportation,
                    Photo = tutor.Photo,
                    IncludingPhotos = tutor.IncludingPhotos
                })
    );
        }

        IQueryable<RequestTutorDetails> IRepositoryBase<RequestTutorDetails>.FindAll(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public IQueryable<RequestTutorDetails> FindByCondition(Expression<Func<RequestTutorDetails, bool>> expression, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        async Task<RequestTutorDetails?> ITutorDetailsRepository.FindByIdAsync(Guid id)
        {
            return await _webContext.Tutors
                .Include(t => t.User)
                .Select(tutor => new RequestTutorDetails
                {
                    UserId = tutor.User.UserId,
                    AcademicSpecialty = tutor.AcademicSpecialty,
                    Faculty = tutor.Faculty,
                    OnlineTutor = tutor.OnlineTutor,
                    SelfIntroduction = tutor.SelfIntroduction,
                    TeachingAchievement = tutor.TeachingAchievement,
                    Title = tutor.Title,
                    TutorId = tutor.TutorId,
                    Transportation = tutor.Transportation,
                    Photo = tutor.Photo,
                    IncludingPhotos = tutor.IncludingPhotos
                }).Where(t => t.TutorId == id).FirstOrDefaultAsync();
        }
    }
}
