using Core.Application.Dtos.Statement;
using Core.Application.Interfaces.Repository;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Implementations
{
    public class StatementsRepository : Repository<Statement>, IStatementRepository
    {

        public StatementsRepository(TbilservingDbContext context) : base(context)
        {

        }



        public async Task<int> AddStatementReturnIdss(Statement statement)
        {
            int returnedStatementId = 0;
            await Add(statement);
            context.SaveChanges();

            returnedStatementId = context.Statements.OrderByDescending(x => x.Id).FirstOrDefault().Id;

            return returnedStatementId;
        }
    }
}
