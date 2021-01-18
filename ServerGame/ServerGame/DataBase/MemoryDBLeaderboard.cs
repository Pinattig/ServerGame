using ServerGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace ServerGame.DataBase
{
    public class MemoryDBLeaderboard
    {
        private Dictionary<long, List<GameResultModel>> memoryDB;
        private readonly Timer timerToAtt;

        public static MemoryDBLeaderboard Instance { get; } = new MemoryDBLeaderboard();

        public MemoryDBLeaderboard()
        {
            memoryDB = new Dictionary<long, List<GameResultModel>>();
            timerToAtt = new Timer();

            timerToAtt.Elapsed += TimerElapsed;
            timerToAtt.Start();
        }

        private void TimerElapsed(object source, ElapsedEventArgs e)
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                var auxMemoryDB = new Dictionary<long, List<GameResultModel>>(memoryDB);
                foreach (var item in auxMemoryDB)
                {
                    var leaderboards = context.GameResult.Where(x => x.GameId == item.Key).OrderByDescending(x => x.WinPoints).Take(100).ToList();
                    memoryDB[item.Key] = leaderboards;
                }

            }
        }

        public List<GameResultModel> GetLeaderboards(long gameId)
        {
            if (memoryDB.ContainsKey(gameId))
                return memoryDB[gameId];

            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                var leaderboards = context.GameResult.Where(x => x.GameId == gameId).OrderByDescending(x => x.WinPoints).Take(100).ToList();
                if (leaderboards.Count() == 0)
                    return null;


                memoryDB[gameId] = leaderboards;
                return leaderboards;
            }

        }

        public void SetTimeInterval(TimeSpan time)
        {
            timerToAtt.Interval = time.TotalMilliseconds;
        }
    }
}
