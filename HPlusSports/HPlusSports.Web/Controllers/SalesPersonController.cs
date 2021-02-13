using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HPlusSports.Core;
using HPlusSports.Web.ViewModels;
using HPlusSports.DAL;
using HPlusSports.Core.Commands;

namespace HPlusSports.Web.Controllers
{
    public class SalesPersonController : Controller
    {
        ISalesPersonService _salesPersonService;
        ISalesPersonRepository _salesPersonRepo;
        public SalesPersonController(ISalesPersonService salesPersonServiceService, ISalesPersonRepository salesPersonRepo)
        {
            _salesPersonService = salesPersonServiceService;
            _salesPersonRepo = salesPersonRepo;
        }

        public async Task<ActionResult> Index()
        {
            var salesPeople = await _salesPersonRepo.GetWithOrders();
            return View(salesPeople);
        }

        public async Task<ActionResult> Edit(int Id)
        {
            var person = await _salesPersonRepo.GetByID(Id);
            
            return View(new EditSalespersonViewModel(person));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditSalespersonViewModel vm)
        {
            var command = new UpdateSalesPersonCommand(vm.GetPerson(), _salesPersonRepo);
            if (!await command.CanUpdate()){
                ModelState.AddModelError("","Check your field values");
                return View(vm);
            }
            await command.Update();
            return Redirect("/SalesPerson/Index");
        }

    }
}