using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersExample.Models;
using UsersExample.Models.Data;
using UsersExample.ViewModels;

namespace UsersExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private ApplicationContext _db;

        public UsersController(ApplicationContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("addUser")]
        public async Task<IActionResult> AddUser(User model)
        {
            _db.Entry(model).State = EntityState.Added;
            await _db.SaveChangesAsync();
            return new JsonResult(true);
        }
    }
}