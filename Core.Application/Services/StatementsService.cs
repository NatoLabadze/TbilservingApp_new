
using AutoMapper;
using Core.Application.Dtos.Statement;
using Core.Application.Interfaces.Repository;
using Core.Domain;
using Core.Domain.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Services
{
    public class StatementsService
    {
        private readonly IMapper mapper;
        private readonly IStatementRepository statementsRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IDocumentService documentService;
        private readonly IDocumentRepository documentRepository;

        public StatementsService(IMapper mapper, IStatementRepository statementsRepository, IHttpContextAccessor httpContextAccessor,
            IDocumentService documentService, IDocumentRepository documentRepository)
        {
            this.mapper = mapper;
            this.statementsRepository = statementsRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.documentService = documentService;
            this.documentRepository = documentRepository;
        }
        // public async Task<int> AddStatementReturnId(Statement statement)
        // {
        // int returnedStatementId = 0;
        //  Add(statement);
        //  context.SaveChanges();

        //returnedStatementId = statementsRepository..OrderByDescending(x => x.Id).FirstOrDefault().Id;
        // return await statementsRepository.Add(statement);
        // return returnedStatementId;
        //  }
        public async Task<string> StatementAdd(AddStatementDto addStatementDto)
        {

            var statement = mapper.Map<Statement>(addStatementDto);
            var userId = int.Parse(this.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            statement.UserId = userId;
            statement.Comment = addStatementDto.Comment;

            int statementId = await statementsRepository.AddStatementReturnIdss(statement);


            //if (addStatementDto.Files == null)
            //{
            //    throw new System.Exception("No Files Provided!");
            //}
            //var files = addStatementDto.Files.ToList();
            //var file = files[0];
            //Document documentInfo = new Document();
            //using (MemoryStream stream = new MemoryStream())
            //{
            //    await file.CopyToAsync(stream);
            //    stream.Position = 0;
            //    string objectName = await documentService.UploadFileMinio(file, stream);
            //    documentInfo.FileName = objectName;
            //    documentInfo.StatementId = statementId;
            //    await documentRepository.Add(documentInfo);
            //}

            if (addStatementDto.Files != null)
            {
                var files = addStatementDto.Files.ToList();
                foreach (var item in files)
                {
                    Document documentInfo = new Document();
                    MemoryStream stream = new MemoryStream();
                    await item.CopyToAsync(stream);
                    stream.Position = 0;

                    string objectName = await documentService.UploadFileMinio(item, stream);
                    stream.Position = 0;
                    documentInfo.StatementId = statementId;
                    // documentInfo.FilePath = "file://192.168.20.93/statementdocuments/";
                    documentInfo.FilePath = "http://192.168.22.88:57891/";
                    documentInfo.ObjectName = objectName;
                    await documentRepository.Add(documentInfo);
                }
            }
            return "ok";

        }
       
    }
}

