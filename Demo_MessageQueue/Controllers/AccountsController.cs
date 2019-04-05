using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return _db.Accounts.ToList();
        }


        // POST api/users
        [HttpPost]
        public void Post([FromBody] Account account)
        {
            _db.Accounts.Add(account);
            _db.SaveChanges();

            //SendWelcomeEmail(user);

            SendMessageAsync(account).GetAwaiter().GetResult();

            Console.WriteLine("===============================================================");
            Console.WriteLine("API request responded.");
            Console.WriteLine("===============================================================");
        }

        public async Task SendMessageAsync(Account account)
        {
            var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(account)));

            await Startup.MyQueueClient.SendAsync(message);
        }
    }
}
