using GameEndpoints.Common.Resources;
using GameEndpoints.Common.Validations;
using GameEndpoints.Domain.Contracts.Repositories;
using GameEndpoints.Domain.Contracts.Services;
using GameEndpoints.Domain.Model;
using System;

namespace GameEndpoints.Business.Services
{
    public class PlayerService : IPlayerService
    {
        private IPlayerRepository _repository;

        public PlayerService(IPlayerRepository repository)
        {
            this._repository = repository;
        }

        public Player Authenticate(string email, string password)
        {
            var player = _repository.Get(email);
            if (player.Password != PasswordAssertionConcern.Encrypt(password))
                throw new Exception(ErrorMessages.InvalidCredentials);

            return player;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
