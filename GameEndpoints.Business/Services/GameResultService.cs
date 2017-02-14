using GameEndpoints.Domain.Contracts.Repositories;
using GameEndpoints.Domain.Contracts.Services;
using GameEndpoints.Domain.Model;
using GameEndpoints.Domain.ViewModel;
using System;
using System.Collections.Generic;

namespace GameEndpoints.Business.Services
{
    public class GameResultService : IGameResultService
    {
        private IGameResultRepository _repository;

        public GameResultService(IGameResultRepository repository)
        {
            this._repository = repository;
        }

        public Balance SaveGameResult(long playerId, long gameId, long win, DateTime timeStamp)
        {
            var player = _repository.GetPlayer(playerId);
            var game = _repository.GetGame(gameId);
            var gameResult = new GameResult(player, game, win, timeStamp);
            gameResult.Validate();
            return _repository.SaveGameResult(gameResult);
        }
        
        public Balance SaveGameResult(long playerId, IList<GameResultDetailModel> gameResultDetails)
        {
            var player = _repository.GetPlayer(playerId);
            var gamesResult = new List<GameResult>();
            foreach (var gameResultDetail in gameResultDetails)
            {
                var game = _repository.GetGame(gameResultDetail.GetGameId());
                var gameResult = new GameResult(player, game, gameResultDetail.GetWin(), gameResultDetail.GetTimeStamp());
                gameResult.Validate();
                gamesResult.Add(gameResult);
            }
            return _repository.SaveGameResult(gamesResult);
        }
        
        public IList<Balance> GetLeaderboard()
        {
            return _repository.GetLeaderboard();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
