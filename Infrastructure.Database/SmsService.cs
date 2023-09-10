using Core.Application.Services;
using RestClient.Net;
using RestSharp;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Infrastructure.Database
{
    public class SmsService : ISmsService
    {
        public string Send(string mobiileNumber, string message, int accountId)
        {

            //var client = new RestClient("http://192.168.22.12:8075/api/Message/SmsSent?phone=551737767&message=test&applicationId=9");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Authorization", "Bearer r7H]*eVaD0[4Ke5?'J.:.KOAmb");
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            return "";




        }
    }
}
