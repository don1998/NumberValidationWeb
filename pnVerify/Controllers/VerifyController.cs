using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pnVerification.Models;
using pnVerify.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace pnVerify.Controllers
{
    public class VerifyController : ApiController
    {
        private string url = @"http://apilayer.net/api/validate?access_key=71ac8a48cc30a3fab62a7ee590749fe1&number=";

        //Random string generator for requestid
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


 
        // POST api/values
        public Object Post([FromBody]Objectmodel obj)
        {
            PhoneInfo phoneInfo = new PhoneInfo();
            phoneInfo.username = obj.username;
            phoneInfo.number = obj.number;
            String username;
            String number;
            String requestId;
            String dateCreated;
            DateTime currentDate = DateTime.Now;
            number = obj.number;
            username = obj.username;
            //Stores user email that was logged in 

            //Stores randomly generated request if to unniquely indentify the record
            requestId = RandomString(8);

            //Stores current date and time when the record was inserted
            dateCreated = currentDate.ToString();

            //gets count to check if phone number exist
            //returns count if the number exist in the database and valid
            //should be equal to 0 or 1
            int x = phoneInfo.SelectValidPhoneNumberCount(number);

            //returns count if the number exist in the database and invalid
            //should be equal to 0 or 1
            int y = phoneInfo.SelectInvalidPhoneNumberCount(number);

            if (x > 0 || y > 0)
            {
                if(x >0)
                {
                    //stores phoneNumber record returned from database
                    object result = phoneInfo.SelectValidPhoneNumberInfo(number);

                    //Converts record to json format 
                    string json = JsonConvert.SerializeObject(result, Formatting.Indented);
                    var response = new HttpResponseMessage()
                    {
                        Content = new StringContent(json)
                    };
                    return response;
                }
                else
                {
                    object result1 = phoneInfo.SelectInvalidPhoneNumberInfo(number);

                    string jsonResult = JsonConvert.SerializeObject(result1, Formatting.Indented);
                    var response = new HttpResponseMessage()
                    {
                        Content = new StringContent(jsonResult)
                    };
                    return response;

                }

            }
            else
            {

                string verificationResult;

                //send request to numverify api
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + number);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    //stores reponse in local variable.
                    verificationResult = reader.ReadToEnd();
                }
               
                //Converts from json format and stores data in phoneInfo class
                var info = JsonConvert.DeserializeObject<PhoneInfo>(verificationResult);

                //Checks to see if number being inserted is valid or not
                //and used appropriate function to insert
                if (info.valid == "False")
                {
                    phoneInfo.InsertInvalidPhoneNumberInfo(info.valid, info.local_format,
                      info.international_format, info.country_prefix, info.country_code,
                      info.country_name, info.location, info.carrier, number, requestId, username, dateCreated);
                }
                else
                {
                    phoneInfo.InsertValidPhoneNumberInfo(info.valid, info.local_format,
                      info.international_format, info.country_prefix, info.country_code,
                      info.country_name, info.location, info.carrier, info.line_type, number, requestId, 
                      username, dateCreated);
                }

                info.dateCreated = dateCreated;
                info.requestId = requestId;
                info.username = username;

                //Converts information inserted into the database to json format to be displayed in browser
                String data = JsonConvert.SerializeObject(info, Formatting.Indented);
                var insertedData = new HttpResponseMessage();
                insertedData.Content = new StringContent(data);
                return insertedData;
            }


        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
