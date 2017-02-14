using GameEndpoints.Domain.Model;
using GameEndpoints.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace GameEndpoints.Domain.Contracts.Services
{
    public interface IGameResultService : IDisposable
    {
        Balance SaveGameResult(long playerId, long gameId, long win, DateTime timeStamp);
        Balance SaveGameResult(long playerId, IList<GameResultDetailModel> gameResultDetails);
        IList<Balance> GetLeaderboard();
    }
}
