using System.Threading.Tasks;
using IMDB.Libs.Services;
using Microsoft.AspNetCore.Mvc;

namespace Games.Controllers
{
    /// <summary>
    /// Controller class of IMDB external API
    /// </summary>
    /// <param name="get250Top"> gets 250 results of games </param>>
    /// <param name="getSimillar"> get similar games by id </param>>
    public class IMDBController : Controller
    {
        [HttpGet]
        [Route("imdb8/get250Top")]
        public async Task<IActionResult> get250Top()
        {
            var result = await IMDBServices.getTop250();

            return Ok(result);
        }

        [HttpGet]
        [Route("imdb8/getSimillar")]
        public async Task<IActionResult> getSimillar(string mID)
        {
            var result = await IMDBServices.getSimilarGames(mID);

            return Ok(result);
        }
    }
}