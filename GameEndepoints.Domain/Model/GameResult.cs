using GameEndpoints.Common.Resources;
using GameEndpoints.Common.Validations;
using System;

namespace GameEndpoints.Domain.Model
{
    public class GameResult
    {
        public long GameResultId { get; set; }
        public virtual Player Player { get; private set; }
        public virtual Game Game { get; private set; }
        public long Win { get; private set; }
        public DateTime TimeStamp { get; private set; }

        protected GameResult() { }
        public GameResult(Player player, Game game, long win, DateTime timeStamp)
        {
            this.Player = player;
            this.Game = game;
            this.Win = win;
            this.TimeStamp = timeStamp;
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(Player, ErrorMessages.InvalidPlayer);
            AssertionConcern.AssertArgumentNotNull(Game, ErrorMessages.InvalidGame);
        }
    }
}
