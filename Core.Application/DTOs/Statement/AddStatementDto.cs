using Microsoft.AspNetCore.Http;

namespace Core.Application.Dtos.Statement
{
    public class AddStatementDto
    {

        public string Comment { get; set; }
        public IFormFileCollection Files { get; set; }

    }
}


