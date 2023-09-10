using Core.Application.Interfaces.Repository;
using Core.Domain;
using System;
using System.Linq;

namespace Infrastructure.Database.Implementations
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(TbilservingDbContext context) : base(context)
        {

        }
        public Message GetLastActiveMessage(string phoneNumber, string smsCode, MessageType messageType)
        {
            // გაგზავნილი SMS კოდის გადამოწმება
            var currentDate = DateTime.Now;
            var lastSms = context.Messages
                    .Where(x => x.PhoneNumber == phoneNumber
                        && x.Text == smsCode
                        && x.MessageType == messageType
                        && x.SendDate.AddSeconds(60) >= currentDate)
                    .OrderByDescending(x => x.SendDate)
                    .FirstOrDefault();

            return lastSms;
        }
    }
}
