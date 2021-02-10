using System;
using System.Threading.Tasks;
using HPlusSports.DAL;
using HPlusSports.Models;

namespace HPlusSports.Core.Commands
{
    public class UpdateSalesPersonCommand : IEntityUpdateCommand
    {
        Salesperson person;
        ISalesPersonRepository _salesRepo;

        public UpdateSalesPersonCommand(Salesperson p, ISalesPersonRepository repo)
        {
            person = p;
            _salesRepo = repo;
        }

        public async Task<bool> CanInvoke()
        {
            var existingSalesperson = await _salesRepo.GetByID(person.Id);

            if (existingSalesperson == null) return false;

            if (person.Phone.Length < 10) return false;

            return true;
        }

        public async Task Invoke()
        {
            if (!await CanInvoke()) throw new ApplicationException("Unable to execute command");

            var existingSalesperson = await _salesRepo.GetByID(person.Id);

            existingSalesperson.PropertyChanged += (sender, e) =>
                Console.WriteLine($"User {(sender as Salesperson).Id} {e.PropertyName} updated");

            existingSalesperson.FirstName = person.FirstName;
            existingSalesperson.LastName = person.LastName;
            existingSalesperson.Email = person.Email;
            existingSalesperson.Phone = person.Phone;

            _salesRepo.Save(existingSalesperson);
            await _salesRepo.SaveChanges();
        }
    }

}