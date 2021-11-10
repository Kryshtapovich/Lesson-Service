using API.Services.BotServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace API.Controllers
{
    [ApiController]
    [Route("api/bot")]
    public class BotController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromServices] BotService service, [FromBody] Update update)
        {
            await service.HandleUpdateAsync(update);

            return Ok();
        }
    }
}