using Core.Application.Services;
using MediatR;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TbilservingApp.Application.Interfaces.Repository;

namespace Infrastructure.Database
{
    internal class SmsService : ISmsService
    {

        /// <summary>
        /// sms -ის გაგზავნა
        /// </summary>
        /// <param name="mobiileNumber">მობილურის ნომერი</param>
        /// <param name="message">sms -ის ტექსტი</param>
        /// <param name="accountType">ანგარიშის ტიპი(კლიენტი, ადმინი....)</param>
        /// <param name="accountId">იუზერის უნიკალური იდენთიფიკატორი</param>
        /// <returns></returns>
        /// 
        public (string result, int errorCode, string errorMessage) Send(string mobiileNumber, string message, Guid? accountId)
        {
            //var fullMobileNumber = +995 + mobiileNumber;


            //string loginName = "Stateissuessmsuser";
            //string password = "resetpass";

            //Guid projectId = new Guid("c4945c6e-00a1-479e-8447-59dd667b5b4c");

            //var userLogin = umUtilStateless.Login(loginName, password);
            //var userLoginToken = userLogin.Result.Value;

            //var projectLogin = umUtilStateless.Login(loginName, password);
            //var projectLoginToken = projectLogin.Result.Value;


            // ლოგერის ობიექტის შექმნა
            // var logService = new AddLogServiceRequest(accountType: accountType, accountId: accountId, serviceType: ServiceType.SmsService);

            // ლოგერის შევსება საწყისი მონაცემებით
            //logService.SetRequest(DateTime.Now, JsonConvert.SerializeObject(new
            //{
            //    userLoginToken = userLoginToken,
            //    projectLoginToken = projectLoginToken,
            //    projectId = projectId,
            //    smsProvider = Hmis.Contracts.SmsService.Enums.SmsProvidersEnum.Magti_Ssa,
            //    mobileNumber = fullMobileNumber,
            //    text = message
            //}));

            // sms -ის გაგზავნის სერვისის გამოძახება
            //            Ssa.Utils.Entities.OperationGenericResult<string> smsResult;
            //            try
            //            {
            //                // sms -ის გაგზავნა ჩადგმული სერვისით
            //                smsResult = smsServiceBusProxy.SendSms(
            //                        userLoginToken: userLoginToken,
            //                        projectLoginToken: projectLoginToken,
            //                        projectId: projectId,
            //                        smsProvider: Hmis.Contracts.SmsService.Enums.SmsProvidersEnum.Magti_Ssa,
            //                        mobileNumber: fullMobileNumber,
            //                        text: message
            //                    );
            //            }
            //            catch (Exception)
            //            {
            //                // სერვისის ჩვარდნიშ შემთხვევაში დაილოგოს მხოლოდ request ობიექტი
            //                //mediator.Send(logService);
            //                throw;
            //            }


            //            ლოგერის შევსება საბოლოო მონაცემებით
            //            logService.SetResponse(DateTime.Now, JsonConvert.SerializeObject(smsResult));
            //            სერვისის ლოგის შენახვა ბაზაში EntityFrameworkCore საშვალებით
            //            mediator.Send(logService);


            return (result: "test", errorCode: 0, errorMessage: "test");
        }

        public async Task<string> Send(string mobiileNumber, string message, int accountId)
        {
            var client = new HttpClient();

            var asdasd = $"asdasd{mobiileNumber}";
            var url = string.Format("http://192.168.22.12:8075/api/Message/SmsSent?phone={0}&message={1}&applicationId=9", mobiileNumber, message);
            client.Timeout = TimeSpan.FromSeconds(60);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer r7H]*eVaD0[4Ke5?'J.:.KOAmb"); 
            var response = await client.GetAsync(url);

            var result = response.Content.ReadAsStringAsync();

            Console.WriteLine(result);

            return null;
        }
    }
}