using Entities.Dto;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITutorDetailsService
    {
        public Task<IEnumerable<RequestTutorDetails>?> FindAllAsync(bool trackchanges);
        public Task<RequestTutorDetails?> FindByIdAsync(Guid id);
        public Task CreateAsync(RequestTutorDetails request);
        public Task<bool?> UpdateAsync(RequestTutorDetails request, Guid id);
        public Task<bool?> DeleteAsync(Guid id);
        public Task<List<RequestTutorDetails>?> SearchTutorsAsync(Expression<Func<RequestTutorDetails, bool>> expression, bool trackChanges);
    }
}