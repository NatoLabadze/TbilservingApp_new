

using Core.Application.Dtos.Statement;
using Core.Domain;
using Core.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repository
{
    public interface IStatementRepository : IRepository<Statement>
    {
      //  int AddStatementReturnId(Statement statement);

      //  Task<string> StatementAdd(AddStatementDto addStatementDto);
        // Task<Statement> GetStatementById(int Id);
     //   void AddStatementReturnIds(Statement statement);
        Task<int> AddStatementReturnIdss(Statement statement);
        // int Update(Statement statement);
    }
}
