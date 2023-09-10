using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Services
{
    public interface ISmsService
    {
        string Send(string mobiileNumber, string message, int accountId);
    }
}
