using ServerGame.DataBase;
using ServerGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerGame.Services
{
    public class LeaderboardService
    {

        public MemoryDBLeaderboard memoryDB;
        
        public LeaderboardService()
        {
            memoryDB = MemoryDBLeaderboard.Instance;
        }

        public List<LeaderboardViewModel> GetLeaderboardsGame(long gameId)
        {
            return memoryDB.GetLeaderboards(gameId)?.ConvertAll(x => (LeaderboardViewModel) x);
        }
    }
}
