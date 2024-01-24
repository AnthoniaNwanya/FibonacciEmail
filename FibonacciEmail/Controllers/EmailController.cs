using Microsoft.AspNetCore.Mvc;
using FibonacciEmail.Data;
using FibonacciEmail.Model;

namespace FibonacciEmail.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly EmailContext _ctx;

        public EmailController(EmailContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailModel request)
        {
            List<int> oddlist = new List<int>();
            List<int> evenlist = new List<int>();

            int number1 = request.Number1;
            int number2 = request.Number2;
            int a = 0;
            int b = 1;
            int c = 1;

            if (number1 < number2)
            {
                while (true)
                {
                    c = a + b;

                    if(c > number2)
                    {
                        break;
                    }
                    //OddNumbers Except Multiples of 3
                    if (c > number1 && c % 2 != 0 && c % 3 != 0)
                    {
                        oddlist.Add(c);
                    }
                    // Even numbers
                    if (c > number1 && c % 2 == 0)
                    {
                        evenlist.Add(c);
                    }
                    a = b;
                    b = c;
                    
                }

                (List<int>, List<int>) value = (oddlist.ToList(), evenlist.ToList());
                return Ok(value.ToTuple());

            } 
                return BadRequest("Number 1 must be lesser than Number 2");
           
        }
    }
}

