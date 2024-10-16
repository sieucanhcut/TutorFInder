using Repositories.Implements;
using Repositories.Intefaces;
using Repositories.Interfaces;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IRepositoryManager
    {
        IContractRepository Contract { get; }
        IEventRepository Event { get; }
        IRoleRepository Role { get; }
        IStudentDetailsRepository StudentDetails { get; }
        ITutionFeeScheduleRepository TutionFeeSchedule { get; }
        ITutorDetailsRepository TutorDetails { get; }
        IUserRepository User { get; }
        ILocationRepository Location { get; }
        IStudyCourseRepository StudyCourse { get; }
        ITutorAdvertisementRepository TutorAdvertisement { get; }
        IFeedbackRepository Feedback { get; }
        IFreeCourseRepository FreeCourse { get; }
        IInvoiceRepository Invoice { get; }
        IStudentRequirementRepository StudentRequirement { get; }
        ICourseRepository Course { get; }
        Task SaveAsync();
    }
}
