using GameEndpoints.Domain.Contracts.Repositories;
using GameEndpoints.Domain.Model;
using GameEndpoints.Infrastructure.Data;
using System.Linq;

namespace GameEndpoints.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private AppDataContext _context;

        public PlayerRepository(AppDataContext context)
        {
            this._context = context;
        }

        public Player Get(string email)
        {
            return _context.Players.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}