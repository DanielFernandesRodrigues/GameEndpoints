using GameEndpoints.Domain.Contracts.Repositories;
using GameEndpoints.Domain.Model;
using GameEndpoints.Infrastructure.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GameEndpoints.Infrastructure.Repositories
{
    public class GameResultRepository : IGameResultRepository
    {
        private AppDataContext _context;

        public GameResultRepository(AppDataContext context)
        {
            this._context = context;
        }

        public IList<GameResult> Get(long playerId)
        {
            return _context.GameResults.Where(x => x.Player.PlayerId == playerId).ToList();
        }

        public Balance SaveGameResult(GameResult gameResult)
        {
            _context.GameResults.Add(gameResult);

            var balance = GetBalance(gameResult.Player);
            balance.UpdatePoints(gameResult.Win);
            
            _context.SaveChanges();

            return balance;
        }

        public Player GetPlayer(long playerId)
        {
            return _context.Players.Where(x => x.PlayerId == playerId).FirstOrDefault();
        }

        public Game GetGame(long gameId)
        {
            return _context.Games.Where(x => x.GameId == gameId).FirstOrDefault();
        }

        public Balance SaveGameResult(IList<GameResult> gamesResult)
        {
            var balance = GetBalance(gamesResult.First().Player);
            
            foreach (var gameResult in gamesResult)
            {
                balance.UpdatePoints(gameResult.Win);
                _context.GameResults.Add(gameResult);
            }

            _context.SaveChanges();

            return balance;
        }

        private Balance GetBalance(Player player)
        {
            var balance = _context.Balances.Where(x => x.Player.PlayerId == player.PlayerId).FirstOrDefault();

            if (balance != null)
            {
                _context.Entry(balance).State = EntityState.Modified;
            }
            else
            {
                balance = new Balance(player, 0);
                _context.Balances.Add(balance);
            }

            return balance;
        }

        public IList<Balance> GetLeaderboard()
        {
            return _context.Balances
                .Include(x => x.Player)
                .OrderByDescending(x => x.Points).Take(100).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
