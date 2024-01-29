using FibonacciEmail.Data;
using FibonacciEmail.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PostmarkDotNet;
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

                    if (c > number2)
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

                var OddNums = JsonConvert.SerializeObject(oddlist);
                var EvenNums = JsonConvert.SerializeObject(evenlist);

                try
                {
                    var message = new PostmarkMessage()
                    {
                        To = request.EmailAddress,
                        From = "oluwatobi.balogun@octosoft.ai",
                        TrackOpens = true,
                        Subject = "Fibonacci Sequence",
                        TextBody = $"Odd Numbers except multiples of 3: {OddNums}. EvenNumbers: {EvenNums}",
                        MessageStream = "broadcast",
                    };

                    var client = new PostmarkClient("95a70547-39d6-4349-89e6-58aadde7ac57");
                    var sendResult = await client.SendMessageAsync(message);

                    if (sendResult.Status == PostmarkStatus.Success)
                    {
                        return Ok("Email was sent successfully.");
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            return BadRequest("Number 1 must be lesser than Number 2");
        }

    }

}


