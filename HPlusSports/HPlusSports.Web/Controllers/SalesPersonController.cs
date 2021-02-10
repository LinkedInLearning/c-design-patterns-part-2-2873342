using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HPlusSports.Core;
using HPlusSports.Web.ViewModels;
using HPlusSports.Models;
using HPlusSports.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            ModelState.AddModelError("","Check your field values");
            if (!await command.CanInvoke()) return View(vm);

            await command.Invoke();

            return Redirect("/SalesPerson/Index");
        }

    }
}