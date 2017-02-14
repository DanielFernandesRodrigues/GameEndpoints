using GameEndpoints.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameEndpoints.Api.Model
{
    public class GameResultModel
    {
        public string PlayerId { get; set; }
        public IList<GameResultDetailModel> GameDetails { get; set; }

        public long GetPlayerId()
        {
            return Convert.ToInt64(PlayerId);
        }
    }
}