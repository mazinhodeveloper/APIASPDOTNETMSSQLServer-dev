using Microsoft.AspNetCore.Mvc;
using APIASPDOTNETMSSQLServer.Repositories;

namespace APIASPDOTNETMSSQLServer.Controllers
{
    public class ACLViewController : Controller
    {
        private readonly RepositoryACL _repository;
        public ACLViewController(RepositoryACL repository) => _repository = repository;

        // GET: /acl  (Razor page)
        [HttpGet("/acl")]
        public async Task<IActionResult> Index()
        {
            var aclList = await _repository.GetAllAsync();
            //return View(aclList); // Views/ACL/Index.cshtml 
            return View("~/Views/ACL/Index.cshtml", aclList); // <- full path 
            
        }
    }
}