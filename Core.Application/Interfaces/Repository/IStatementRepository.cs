

using Core.Application.Dtos.Statement;
using Core.Domain;
using Core.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repository
{
    public interface IStatementRepository : IRepository<Statement>
    {
        Task<int> AddStatementReturnIdss(Statement statement);
    }
}
