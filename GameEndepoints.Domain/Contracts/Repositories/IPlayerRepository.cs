using GameEndpoints.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEndpoints.Domain.Contracts.Repositories
{
    public interface IPlayerRepository : IDisposable
    {
        Player Get(string email);
    }
}
