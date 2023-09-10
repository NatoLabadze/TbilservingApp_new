//using AutoMapper;
//using Core.Application.Dtos.Document;
//using Core.Application.Interfaces;
//using Core.Application.Interfaces.Repository;
//using Core.Application.Services;
//using Core.Domain.Model;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using TbilservingApp.Application.Interfaces.Repository;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Presentation.WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DocumentController : ControllerBase
//    {
//        private readonly IMapper mapper;
//        private readonly IDocumentService documentService;
//        private readonly IDocumentRepository documentRepository;

//        public DocumentController(IMapper mapper, IDocumentService IdocumentService, IDocumentRepository documentRepository)
//        {
//            this.mapper = mapper;
//            this.documentService = IdocumentService;
//            this.documentRepository = documentRepository;
//        }

//        //[HttpGet]

//        //public async Task<string> Get()
//        //{
//        //    var result = await documentService.GetFileFromMinio();
//        //    return result;
//        //}

//        //[HttpPost]
//        //public async Task Post(IFormCollection documents, [FromForm] int StatementId)
//        //{
//        //    if (documents.Files.Count == 0)
//        //    {
//        //        throw new System.Exception("No Files Provided!");
//        //    }
//        //    var files = documents.Files.ToList();
//        //    var file = files[0];
//        //    Document documentInfo = new Document();
//        //    using (MemoryStream stream = new MemoryStream())
//        //    {
//        //        await file.CopyToAsync(stream);
//        //        stream.Position = 0;
//        //        string objectName = await documentService.UploadFileMinio(file, stream);
//        //        documentInfo.FileName = objectName;
//        //        documentInfo.StatementId = StatementId;
//        //        await documentRepository.Add(documentInfo);
//        //    }
//        //}

//        //public async void Post([FromForm] DocumentDto documentDto)
//        //{
//        //    //documentService.UploadFileMinio(document);
//        //    //documentService.AddFile(document);
//        //    Document documentInfo = new Document();
//        //    MemoryStream stream = new MemoryStream();
//        //    await documentDto.File.CopyToAsync(stream);
//        //    stream.Position = 0;
//        //    string objectName = await documentService.UploadFileMinio(documentDto.File, stream);
//        //    stream.Position = 0;


//        //}

//        //[HttpGet]
//        //public async Task<FileContentResult> GetImage([FromQuery] string fileName)
//        //{
//        //    var Bytes = await documentService.GetFileFromMinio(fileName);
//        //    return File(Bytes, "application/pdf", fileName);
//        //}






//    }
//}