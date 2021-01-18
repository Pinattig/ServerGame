using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerGame.Models
{
    public class LeaderboardViewModel
    {
        public long PlayerId { get; set; }
        public long Balance { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public static explicit operator LeaderboardViewModel(GameResultModel model)
        {
            return new LeaderboardViewModel()
            {
                PlayerId = model.PlayerId,
                Balance = model.WinPoints,
                LastUpdateDate = model.TimeStamp
            };
        }
    }
}
