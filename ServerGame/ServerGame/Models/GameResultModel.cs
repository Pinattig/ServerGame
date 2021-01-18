using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerGame.Models
{
    public class GameResultModel
    {
        [Required]
        public long PlayerId { get; set; }
        [Required]
        public long GameId { get; set; }
        [Required]
        public long WinPoints { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
    }
}
