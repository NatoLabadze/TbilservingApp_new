using Core.Application.Interfaces.Repository;
using Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Database.Implementations
{
    internal class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        public DocumentRepository(TbilservingDbContext context) : base(context)
        {

        }

    }
}
