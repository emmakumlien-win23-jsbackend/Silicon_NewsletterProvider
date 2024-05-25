using Data.Contexts;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Silicon_NewsletterProvider.Functions;

public class Subscribe(ILogger<Subscribe> logger, DataContext context)
{
    private readonly ILogger<Subscribe> _logger = logger;
    private readonly DataContext _context = context;

    [Function("Subscribe")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function,"post")] HttpRequest req)
    {
        var body = await new StreamReader(req.Body).ReadToEndAsync();
        if (!string.IsNullOrEmpty(body))
        {
            var subscribeEntity = JsonConvert.DeserializeObject<SubscribeEntity>(body);

            if (subscribeEntity != null)
            {
                var existingSubscribe= await _context.subscriber.FirstOrDefaultAsync(x=> x.Email == subscribeEntity.Email);
                if (existingSubscribe != null)
                {
                    _context.Entry(existingSubscribe).CurrentValues.SetValues(subscribeEntity);
                    await _context.SaveChangesAsync();
                    return new OkObjectResult(new {Status = 200 ,Message="Subscriber updated" });
                    
                }
                _context.subscriber.Add(subscribeEntity);
                await _context.SaveChangesAsync();
                return new OkObjectResult(new { Status = 200, Message = "Subscriber added" });
                
            }
            
        }


        return new BadRequestObjectResult(new { Status = 400, Message = "Unable to subscribe" });
    }
}
