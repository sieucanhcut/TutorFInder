using Entities;
using Repositories.Intefaces;
using Repositories.Interfaces;

namespace Repositories.Implements
{
    internal class ContractRepository : RepositoryBase<Contract>, IContractRepository
    {
        public ContractRepository(TutorWebContext dataContext) : base(dataContext) { 
        }
    }
}
