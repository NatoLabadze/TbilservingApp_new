
//using AutoMapper;
//using Core.Application.Dtos.Statement;
//using Core.Application.Interfaces;
//using Core.Application.Interfaces.Repository;
//using Core.Domain;
//using Core.Domain.Model;
//using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace Infrastructure.Database.Implementations
//{
//    internal class StatementRepository : Repository<Statement>, IStatementRepository
//    {

//        private readonly IHttpContextAccessor httpContextAccessor;
//        private readonly IDocumentService documentService;
//        private readonly IDocumentRepository documentRepository;
//        private readonly IMapper mapper;
//        public StatementRepository(TbilservingDbContext context, IHttpContextAccessor httpContextAccessor,
//            IDocumentService documentService, DocumentRepository documentRepository, IMapper mapper) : base(context)
//        {

//            this.httpContextAccessor = httpContextAccessor;
//            this.documentService = documentService;
//            this.documentRepository = documentRepository;
//            this.mapper = mapper;
//        }

//        public async Task<int> AddStatementReturnId(Statement statement)
//        {
//            int returnedStatementId = 0;
//            await Add(statement);
//            context.SaveChanges();

//            returnedStatementId = context.Statements.OrderByDescending(x => x.Id).FirstOrDefault().Id;

//            return returnedStatementId;
//        }

//        public async Task<string> StatementAdd(AddStatementDto addStatementDto)
//        {
//            var statement = mapper.Map<Statement>(addStatementDto);
//            var userId = int.Parse(this.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
//            statement.UserId = userId;
//            statement.Comment = addStatementDto.Comment;
//            int statementId = await AddStatementReturnId(statement);

//            if (addStatementDto.Files != null)
//            {
//                var files = addStatementDto.Files.ToList();
//                foreach (var item in files)
//                {
//                    Document documentInfo = new Document();
//                    MemoryStream stream = new MemoryStream();
//                    await item.CopyToAsync(stream);
//                    stream.Position = 0;

//                    string objectName = await documentService.UploadFileMinio(item, stream);
//                    stream.Position = 0;
//                    documentInfo.StatementId = statementId;
//                    // documentInfo.FilePath = "file://192.168.20.93/statementdocuments/";
//                    documentInfo.FilePath = "http://192.168.22.88:57891/";
//                    documentInfo.ObjectName = objectName;
//                    await documentRepository.Add(documentInfo);
//                }
//            }


//            return "ok";

//        }
//    }
//}
