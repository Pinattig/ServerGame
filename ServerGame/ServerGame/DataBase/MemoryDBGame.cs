using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerGame.Models;
using System.Timers;

namespace ServerGame.DataBase
{
    class MemoryDBGame
    {
        private List<GameResultModel> memoryDB;
        private readonly Timer timerToPersistense;

        public static MemoryDBGame Instance { get; } = new MemoryDBGame();

        public MemoryDBGame()
        {
            memoryDB = new List<GameResultModel>();
            timerToPersistense = new Timer();

            timerToPersistense.Elapsed += TimerElapsed;
            timerToPersistense.Start();
        }


        private void TimerElapsed(object source, ElapsedEventArgs e)
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                foreach (var item in memoryDB)
                {
                    var playerGameScore = context.GameResult.FirstOrDefault(x => x.GameId == item.GameId && x.PlayerId == item.PlayerId);
                    if(playerGameScore != null)
                    {
                        playerGameScore.WinPoints += item.WinPoints;
                        playerGameScore.TimeStamp = item.TimeStamp;
                        context.GameResult.Update(playerGameScore);
                    }
                    else
                    {
                        context.Add(item);
                    }
                }
                context.SaveChanges();
                memoryDB = new List<GameResultModel>();
            }
        }

        public void AddGameResult(GameResultModel model)
        {
            memoryDB.Add(model);
        }

        public void SetTimeInterval(TimeSpan time)
        {
            timerToPersistense.Interval = time.TotalMilliseconds;
        }
    }
}
