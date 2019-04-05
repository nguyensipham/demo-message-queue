using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private DemoContext _db;
        public AccountsController(DemoContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return _db.Accounts.ToList();
        }

        // POST api/accounts
        [HttpPost]
        public void Post([FromBody] Account account)
        {
            _db.Accounts.Add(account);
            _db.SaveChanges();

            SendEmail(account);

            Console.WriteLine("===============================================================");
            Console.WriteLine("API request responded.");
            Console.WriteLine("===============================================================");
        }

        public static void SendEmail(Account account)
        {
            Console.WriteLine("===============================================================");
            Console.WriteLine("Sending email taking 3 seconds here....");
            Console.WriteLine("===============================================================");
            //Do send email here
            System.Threading.Thread.Sleep(3000);
        }
    }
}
