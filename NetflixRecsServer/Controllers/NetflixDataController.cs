using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace NetflixRecsServer.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class NetflixDataController : ControllerBase {
        private static readonly string[] TITLE = new[]
        {"Breaking Bad", "Avatar: The Last Airbender", "Our Planet", "Kota Factory", "The Last Dance", "Arcane", "Attack on Titan", "Hunter x Hunter"};

        private static readonly double[] SCORE = new[]
        {9.5, 9.3, 9.3, 9.3, 9.1, 9.1, 9.0, 9.0};

        private static readonly int[] VOTES = new[]
        {1727694, 297336, 41386, 66985, 108321, 175412, 325381, 87857};

        private static readonly string[] GENRE = new[]
        {"drama", "animation", "documentary", "drama", "documentary", "animation", "animation", "animation"};

        private readonly ILogger<NetflixDataController> _logger;

        public NetflixDataController(ILogger<NetflixDataController> logger) => _logger = logger;

        [HttpGet(Name = "GetNetflixData")]
        public ActionResult<IEnumerable<NetflixData>> Get() {
            List<NetflixData> data = new List<NetflixData>();
            for (int i = 0; i < TITLE.Length; i++) {
                data.Add(new NetflixData {
                    GENRE = GENRE[i],
                    SCORE = SCORE[i],
                    VOTES = VOTES[i],
                    TITLE = TITLE[i]
                });
            }
            return data;
        }
    }
}