using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repository
{ 
    public interface IDocumentService
    {
        public Task<string> UploadFileMinio(IFormFile file, Stream stream);
        public Task<string> GetFileFromMinio();
    }
}
