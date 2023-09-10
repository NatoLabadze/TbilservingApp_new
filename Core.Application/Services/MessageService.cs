//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Core.Application.Services
//{
//    public class MessageService
//    {
//        public MessageService()
//        {
//            var client = new RestClient("http://192.168.22.12:8075/api/Message/SmsSent?phone=551737767&message=test&applicationId=9");
//            client.Timeout = -1;
//            var request = new RestRequest(Method.GET);
//            request.AddHeader("Authorization", "Bearer r7H]*eVaD0[4Ke5?'J.:.KOAmb");
//            IRestResponse response = client.Execute(request);
//            Console.WriteLine(response.Content);
//        }
//    }
//}
