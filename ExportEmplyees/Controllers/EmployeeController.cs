using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Contract;

namespace ExportEmplyees.Controllers
{
    public class EmployeeController: Controller
    {
        private readonly IServiceManager _serviceManager;
        public EmployeeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _serviceManager.EmployeeService.GetAllEmployees(trackChanges: false);
            return View(employees.OrderBy(x => x.Surname));
        }
        [HttpPost]
        public async Task<IActionResult> Import(IFormFile file)
        {
            var result = await _serviceManager.CsvImportSrvice.ImportAsync(file);
            TempData["Message"] = $" Imported: {result.Inserted}, errors: {result.Failed}";
            if (result.Errors.Any())
                TempData["Errors"] = string.Join("<br>", result.Errors);

            return RedirectToAction("Index");

        }
    }
}
