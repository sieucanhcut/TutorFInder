using Entities;
using Repositories.Intefaces;
using Repositories.Interfaces;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly TutorWebContext _context;

        private IContractRepository _contract;
        private IEventRepository _event;
        private IRoleRepository _role;
        private IStudentDetailsRepository _studentDetails;
        private ITutionFeeScheduleRepository _tutionFeeSchedule;
        private ITutorDetailsRepository _tutorDetails;
        private IUserRepository _user;
        private ILocationRepository _location;
        private IStudyCourseRepository _studyCourse;
        private ITutorAdvertisementRepository _tutorAdvertisement;
        private IFeedbackRepository _feedBack;
        private IFreeCourseRepository _freeCourse;
        private IInvoiceRepository _invoice;
        private IStudentRequirementRepository _studentRequirement;
        private ICourseRepository _course;

        public RepositoryManager(TutorWebContext context)
        {
            _context = context;
            _contract = new ContractRepository(_context);
            _event = new EventRepository(_context);
            _role = new RoleRepository(_context);
            _studentDetails = new StudentDetailsRepository(_context);
            _tutionFeeSchedule = new TutionFeeScheduleRepository(_context);
            _tutorDetails = new TutorDetailsRepository(_context);
            _user = new UserRepository(_context);
            _location = new LocationRepository(_context);
            _studyCourse = new StudyCourseRepository(_context);
            _tutorAdvertisement = new TutorAdvertisementRepository(_context);
            _feedBack = new FeedbackRepository(_context);
            _freeCourse = new FreeCourseRepository(_context);
            _invoice = new InvoiceRepository(_context);
            _studentRequirement = new StudentRequirementRepository(_context);
            _course = new CourseRepository(_context);
        }

        public IContractRepository Contract => _contract;
        public IEventRepository Event => _event;
        public IRoleRepository Role => _role;
        public IStudentDetailsRepository StudentDetails => _studentDetails;
        public ITutionFeeScheduleRepository TutionFeeSchedule => _tutionFeeSchedule;
        public ITutorDetailsRepository TutorDetails => _tutorDetails;
        public IUserRepository User => _user;
        public ILocationRepository Location => _location;
        public IStudyCourseRepository StudyCourse => _studyCourse;
        public ITutorAdvertisementRepository TutorAdvertisement => _tutorAdvertisement;
        public IFeedbackRepository Feedback => _feedBack;
        public IFreeCourseRepository FreeCourse => _freeCourse;
        public IInvoiceRepository Invoice => _invoice;
        public IStudentRequirementRepository StudentRequirement => _studentRequirement;
        public ICourseRepository Course => _course;

        public Task SaveAsync() => _context.SaveChangesAsync();
    }
}
