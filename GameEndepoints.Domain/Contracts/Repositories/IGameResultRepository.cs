using GameEndpoints.Domain.Model;
using System;
using System.Collections.Generic;

namespace GameEndpoints.Domain.Contracts.Repositories
{
    public interface IGameResultRepository : IDisposable
    {
        IList<GameResult> Get(long playerId);
        Player GetPlayer(long playerId);
        Game GetGame(long gameId);
        Balance SaveGameResult(GameResult gameResult);
        Balance SaveGameResult(IList<GameResult> gameResult);
        IList<Balance> GetLeaderboard();
    }
}
