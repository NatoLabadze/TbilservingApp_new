using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TbilservingApp.Application.Interfaces.Repository
{
    public interface ISmsService
    {
        Task<string> Send(string mobiileNumber, string message, int accountId);
    }
}
