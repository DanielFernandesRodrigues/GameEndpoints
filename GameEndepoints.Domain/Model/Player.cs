
using System.Collections.Generic;
namespace GameEndpoints.Domain.Model
{
    public class Player
    {
        public long PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<GameResult> GameResults { get; set; }
    }
}
