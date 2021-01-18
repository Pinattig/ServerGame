using Microsoft.AspNetCore.Mvc;
using ServerGame.Models;
using ServerGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerGame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaderboardController : ControllerBase
    {
        private LeaderboardService service;

        public LeaderboardController() 
        {
            service = new LeaderboardService();
        }

        [HttpPost]
        public ActionResult<List<LeaderboardViewModel>> GetLeaderboard(long gameId)
        {
            try{
                var leaderboardsGame = service.GetLeaderboardsGame(gameId);
                if (leaderboardsGame == null)
                    return StatusCode(404, "Game not found");
                return leaderboardsGame;
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error to get leaderboards");
            }
        }

    }
}
