
using System;
namespace GameEndpoints.Domain.ViewModel
{
    public class GameResultDetailModel
    {
        public string GameId { get; set; }
        public string Win { get; set; }
        public string TimeStamp { get; set; }

        public long GetGameId()
        {
            return Convert.ToInt64(GameId);
        }

        public long GetWin()
        {
            return Convert.ToInt64(Win);
        }

        public DateTime GetTimeStamp()
        {
            return string.IsNullOrEmpty(TimeStamp) ? DateTime.Now : DateTime.Parse(TimeStamp);
        }
    }
}
