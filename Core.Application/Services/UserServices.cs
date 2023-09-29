using AutoMapper;
using Core.Application.DTOs;
using Core.Application.DTOs.UsersDTO;
using Core.Application.Interfaces.Repository;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TbilservingApp.Application.Interfaces.Repository;

namespace Core.Application.Services
{
    public class UserServices
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IMessageRepository messageRepository;
        private readonly ISmsService smsService;

        public UserServices(IUserRepository userRepository, IMapper mapper, IMessageRepository messageRepository, ISmsService smsService)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.messageRepository = messageRepository;
            this.smsService = smsService;
        }
        public async Task AddUser(UserDTO userDTO)
        {
            string randomNumber = new Random().Next(0, 10000).ToString("D4");          
            var user = mapper.Map<User>(userDTO);
            user.PhoneNumberConfirmed = false;
            user.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
            user.TwoFactorEnabled = false;
            
            await userRepository.Add(user);       

            var sms = new Message()
            {
                MessageType = MessageType.ConfirmationCode,
                Text = randomNumber,
               // MessageId = result,
                PhoneNumber = user.PhoneNumber,
                //ErrorCode = errorCode,
                //ErrorMessage = errorMessage,
                SendDate = DateTime.Now,
                Addressee = user.Id,
                Author = user.Id,
            };
          await messageRepository.Add(sms);
        }

        public async Task<User> SignUpSmsConfirm(SignUpSmsConfirmRequest request )
        {
            var lastSms = messageRepository.GetLastActiveMessage(request.PhoneNumber, request.SmsCode, MessageType.ConfirmationCode);

            if (lastSms == null)
                throw new Exception("ვერ მოხდა sms კოდის დადასტურება");


        // გაგზავნილი SMS კოდის ადრესატის გადამოწმება
        var user = await userRepository.SearchFullList( privateNumber: request.PrivateNumber, phoneNumber: request.PhoneNumber);

            if (user == null)
                throw new Exception("ვერ მოხდა sms კოდის დადასტურება");


            // თუ პირველად ხდება sms ის დადასტურება, მოინიშნოს შესაბამისი ველი და გააქტიურდეს პიროვნება
            if (!user.PhoneNumberConfirmedDate.HasValue)
            {
                user.PhoneNumberConfirmedDate = DateTime.Now;
                user.PhoneNumberConfirmed = true;
                await userRepository.Update(user.Id, user);
    }

            
            return user;
        }

        public async Task<User> ValidateUser(string UserName, string Password)
        {
            return await userRepository.ValidateUser(UserName, Password);

        }



      
    }
}


