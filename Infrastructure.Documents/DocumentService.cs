using Core.Application.Interfaces;
using Core.Application.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Minio;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Documents
{
    public class DocumentService : IDocumentService
    {       
        public async Task<string> UploadFileMinio(IFormFile file, Stream stream)
        {
            var endpoint = "192.168.22.88:9000";
            var accessKey = "saba";
            var secretKey = "S123456t";
            var minio = new MinioClient(endpoint, accessKey, secretKey);
            var bucketName = "tbilservingdocuments";


            var splittedFileName = file.FileName.Split('.');
            string fileName = splittedFileName[0];
            string fileFormat = "." + splittedFileName[1];
            string hash = CreateMD5(DateTime.Now.ToString());

            string objectName = fileName + "_" + hash + fileFormat;
            await minio.PutObjectAsync(bucketName, objectName, stream, stream.Length, "application/octet-stream");

            return objectName;
        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public async Task<string> GetFileFromMinio()
        {
            //var endpoint = "localhost:9000";
            var endpoint = "192.168.22.88:9000";
            var accessKey = "saba";
            var secretKey = "S123456t";
            var minio = new MinioClient(endpoint, accessKey, secretKey);
            await minio.StatObjectAsync("tsgservicecontracts", "");
            // await minio.GetObjectAsync("statementdocuments", "2020-07-02_175727_901C6F87CD991747FF299B8CDA774432.png", "2020-07-02_175727_901C6F87CD991747FF299B8CDA774432.png");
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await minio.GetObjectAsync("tsgservicecontracts", "",
                       (stream) =>
                       {
                           stream.CopyTo(memoryStream);
                       });
                return "";
            }
        }
    }
}
