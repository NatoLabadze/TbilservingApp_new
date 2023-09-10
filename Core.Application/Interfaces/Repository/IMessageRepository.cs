using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Interfaces.Repository
{
   public interface IMessageRepository : IRepository<Message>
    {
        Message GetLastActiveMessage(string phoneNumber, string smsCode, MessageType messageType);
    }
}
