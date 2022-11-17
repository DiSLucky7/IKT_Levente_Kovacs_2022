using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelToDatabase.Data;
using System.Linq;

namespace ModelToDatabase.Controllers
{
    public class VideoGameController : Controller
    {
        private readonly ILogger<VideoGameController> _logger;
        private readonly MyDatabaseContext _databaseContext;

        public VideoGameController(ILogger<VideoGameController> logger, MyDatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            var videoGames = _databaseContext.VideoGames.ToList();
            return View(videoGames);
        }
    }
}
