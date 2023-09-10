using Core.Application.Interfaces.Repository;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TbilservingDbContext context) : base(context)
        {

        }


        public async Task<bool> ExistedUser(string userName)
        {
            return await context.Users.AnyAsync(x => x.UserName == userName);
        }



        public async Task<User> ValidateUser(string UserName, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == UserName);
            if (BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;

            }
            return null;

        }
        public async Task<User> SearchFullList(string privateNumber = null, string phoneNumber = null)
        {
            return await context.Users
                    .FirstOrDefaultAsync(x =>
                    (privateNumber == null || x.PrivateNumber == privateNumber)
                    && (phoneNumber == null || x.PhoneNumber == phoneNumber));
        }
    }
}
