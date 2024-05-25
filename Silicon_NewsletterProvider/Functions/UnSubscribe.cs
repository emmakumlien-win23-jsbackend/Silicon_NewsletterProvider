using Data.Contexts;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Silicon_NewsletterProvider.Functions;

public class UnSubscribe(ILogger<UnSubscribe> logger, DataContext context)
{
    private readonly ILogger<UnSubscribe> _logger = logger;
    private readonly DataContext _context = context;

    [Function("UnSubscribe")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        var body = await new StreamReader(req.Body).ReadToEndAsync();
        if (!string.IsNullOrEmpty(body))
        {
            var subscribeEntity = JsonConvert.DeserializeObject<SubscribeEntity>(body);

            if (subscribeEntity != null)
            {
                var existingSubscribe = await _context.subscriber.FirstOrDefaultAsync(x => x.Email == subscribeEntity.Email);
                if (existingSubscribe != null)
                {
                    _context.Remove(existingSubscribe);
                    await _context.SaveChangesAsync();
                    return new OkObjectResult(new { Status = 200, Message = "Subscriber was deleted" });

                }
                
               

            }

        }


        return new BadRequestObjectResult(new { Status = 404, Message = "Email was not found" });
    }
}

