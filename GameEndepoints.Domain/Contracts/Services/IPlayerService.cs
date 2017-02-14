using GameEndpoints.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEndpoints.Domain.Contracts.Services
{
    public interface IPlayerService : IDisposable
    {
        Player Authenticate(string email, string password);
    }
}
