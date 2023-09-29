using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TbilservingApp.Application.Interfaces.Repository
{
    public interface ISmsService
    {
        // (string result, int errorCode, string errorMessage) Send(string mobiileNumber, string message, Guid? accountId);
        Task<string> Send(string mobiileNumber, string message, int accountId);
    }
}
