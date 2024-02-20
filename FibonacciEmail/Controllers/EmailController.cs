using FibonacciEmail.Data;
using FibonacciEmail.Logic;
using FibonacciEmail.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            Fibonacci fibonacci = new Fibonacci();
            var MySequence = fibonacci.CalculateSeries(request.Number1, request.Number2);
            if (request.Number1 < request.Number2)
            {
                var OddNums = JsonConvert.SerializeObject(MySequence.Item1);
                var EvenNums = JsonConvert.SerializeObject(MySequence.Item2);

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
                        _ctx.emailmodels.Add(request);
                        await _ctx.SaveChangesAsync();
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




