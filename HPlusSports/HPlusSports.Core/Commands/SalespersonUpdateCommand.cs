using System;
using System.Threading.Tasks;
using HPlusSports.DAL;
using HPlusSports.Models;

namespace HPlusSports.Core.Commands
{
    public class UpdateSalesPersonCommand : IUpdateCommand
    {
        Salesperson person;
        ISalesPersonRepository _salesRepo;

        public UpdateSalesPersonCommand(Salesperson p, ISalesPersonRepository repository)
        {
            person = p;
            _salesRepo = repository;
        }
        public async Task<bool> CanUpdate()
        {
            var existingSalesperson = await _salesRepo.GetByID(person.Id);
            if (existingSalesperson == null) return false;

            if (person.Phone.Length < 10) return false;
            //other validations
            return true;
        }

        public async Task Update()
        {
            if (!await CanUpdate()) throw new ApplicationException("You didn't validate");
            var existingSalesperson = await _salesRepo.GetByID(person.Id);
            
            existingSalesperson.PropertyChanged += (sender, e) => 
                Console.WriteLine( 
                    $"User {(sender as Salesperson).Id} {e.PropertyName} updated"); 
 
            existingSalesperson.FirstName = person.FirstName;
            existingSalesperson.LastName = person.LastName;
            existingSalesperson.Email = person.Email;
            existingSalesperson.Phone = person.Phone;

            _salesRepo.Save(existingSalesperson);
            await _salesRepo.SaveChanges();
        }
    }
}