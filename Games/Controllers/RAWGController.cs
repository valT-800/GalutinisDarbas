using System.Threading.Tasks;
using RAWG.Libs.Services;
using Microsoft.AspNetCore.Mvc;

namespace Games.Controllers
{
    /// <summary>
    /// Controller class of RAWG external API
    /// </summary>
    /// <param name="getGamesList"> gets a list of games </param>>
    /// <param name="getGameDetails"> get games details </param>>
    public class RAWGController : Controller
    {
        [HttpGet]
        [Route("rawg-video-games-database/getGamesList")]
        public async Task<IActionResult> getGamesList()
        {
            var result = await RAWGServices.getGamesList();

            return Ok(result);
        }

        [HttpGet]
        [Route("rawg-video-games-database/getGameDetails")]
        public async Task<IActionResult> getGameDetails(string game_pk)
        {
            var result = await RAWGServices.getGameDetails(game_pk);

            return Ok(result);
        }
    }
}