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
    public interface ITutorAdvertisementService
    {
        public Task<IEnumerable<RequestTutorAdvertisement>?> FindAllAsync(bool trackchanges);
        public Task<RequestTutorAdvertisement?> FindByIdAsync(Guid id);
        public Task CreateAsync(RequestTutorAdvertisement request);
        public Task<bool?> UpdateAsync(RequestTutorAdvertisement request, Guid id);
        public Task<bool?> DeleteAsync(Guid id);
        public Task<List<RequestTutorAdvertisement>?> SearchTutorsAsync(Expression<Func<RequestTutorAdvertisement, bool>> expression, bool trackChanges);
    }
}