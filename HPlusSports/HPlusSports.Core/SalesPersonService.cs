using HPlusSports.DAL;
using HPlusSports.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HPlusSports.Core
{
    public class SalesPersonService : ISalesPersonService
    {
        ISalesPersonRepository _salesRepo;
        ITrackingRepository<SalesGroup> _salesGroupRepo;

        public SalesPersonService(ISalesPersonRepository salesPersonRepository, ITrackingRepository<SalesGroup> salesGroupRepo)
        {
            _salesRepo = salesPersonRepository;
            _salesGroupRepo = salesGroupRepo;
        }

        public async Task MoveSalesPersonToGroup(int salesPersonId, int groupId)
        {
            var person = await _salesRepo.GetByID(salesPersonId);
            var group = await _salesGroupRepo.GetByID(groupId);
            person.SalesGroup = group;
            _salesRepo.Save(person);
            await _salesRepo.SaveChanges();
        }
    }
}
