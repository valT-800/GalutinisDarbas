using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RAWG.Libs.Services
{
    public static class RAWGServices
    {
        private static string xRapid_Host = "rawg-video-games-database.p.rapidapi.com";
        private static string xRapid_Key = "3a3940bc43msh2cd54cf51a2d70bp1490cdjsn7e6a9c45964d";

        public static async Task<string> getGamesList()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-rapidapi-host", xRapid_Host);
                client.DefaultRequestHeaders.Add("x-rapidapi-key", xRapid_Key);

                var url = new Uri("https://rawg-video-games-database.p.rapidapi.com/games");

                var response = await client.GetAsync(url);

                string json;

                using (var content = response.Content)
                    json = await content.ReadAsStringAsync();

                return json.ToString();
            }
        }

        public static async Task<string> getGameDetails(string game_pk)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-rapidapi-host", xRapid_Host);
                client.DefaultRequestHeaders.Add("x-rapidapi-key", xRapid_Key);

                var url = new Uri($"https://rawg-video-games-database.p.rapidapi.com/games/%7B{game_pk}%7D");

                var response = await client.GetAsync(url);

                string json;

                using (var content = response.Content)
                    json = await content.ReadAsStringAsync();

                return json.ToString();
            }
        }
    }
}
