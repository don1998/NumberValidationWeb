using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using pnVerify.Models;
using Newtonsoft.Json;

namespace pnVerification.Models
{
    public class PhoneInfo
    {
        public String valid { get; set; }

        public String local_format { get; set; }

        public String international_format { get; set; }

        public String country_prefix { get; set; }

        public String country_code { get; set; }

        public String country_name { get; set; }

        public String location { get; set; }

        public String carrier { get; set; }

        public String line_type { get; set; }

        public String number { get; set; }

        public String requestId { get; set; }

        public String username { get; set; }

        public String dateCreated { get; set; }

        private static string MyConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DEV_SummerInternConnectionString"].ConnectionString;
        }

        //Inserting json response into database
        [DataObjectMethod(DataObjectMethodType.Insert)]

        public int InsertValidPhoneNumberInfo(String valid, String local_format, String international_format, String country_prefix, String country_code,
            String country_name, String location, String carrier, String line_type, String number, String requestId, String username,
            String dateCreated)
        {
            try
            {
                SqlConnection con = new SqlConnection(MyConnectionString());
                SqlCommand cmd = new SqlCommand("sp_insertPhoneNumInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //Passing the value into the stored procedure parameters
                cmd.Parameters.AddWithValue("@valid", valid);
                cmd.Parameters.AddWithValue("@local_format", local_format);
                cmd.Parameters.AddWithValue("@international_Format", international_format);
                cmd.Parameters.AddWithValue("@country_name", country_name);
                cmd.Parameters.AddWithValue("@pn_location", location);
                cmd.Parameters.AddWithValue("@carrier", carrier);
                cmd.Parameters.AddWithValue("@line_type", line_type);
                cmd.Parameters.AddWithValue("@country_code", country_code);
                cmd.Parameters.AddWithValue("@country_prefix", country_prefix);
                cmd.Parameters.AddWithValue("@number", number);
                cmd.Parameters.AddWithValue("@requestId", requestId);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@dateCreated", dateCreated);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
            catch (Exception)
            {
                throw;
            }



        }

        //Inserting Invalid json response into database
        [DataObjectMethod(DataObjectMethodType.Insert)]

        public int InsertInvalidPhoneNumberInfo(String valid, String local_format, String international_format, String country_prefix, String country_code,
            String country_name, String location, String carrier, string number, String requestId, String username,
            String dateCreated)
        {
            try
            {
                SqlConnection con = new SqlConnection(MyConnectionString());
                SqlCommand cmd = new SqlCommand("sp_insertInvalidPhoneNumInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                

                //Passing the value into the stored procedure parameters
                cmd.Parameters.AddWithValue("@valid", valid);
                cmd.Parameters.AddWithValue("@local_format", local_format);
                cmd.Parameters.AddWithValue("@international_Format", international_format);
                cmd.Parameters.AddWithValue("@country_name", country_name);
                cmd.Parameters.AddWithValue("@pn_location", location);
                cmd.Parameters.AddWithValue("@carrier", carrier);
                cmd.Parameters.AddWithValue("@country_code", country_code);
                cmd.Parameters.AddWithValue("@country_prefix", country_prefix);
                cmd.Parameters.AddWithValue("@number", number);
                cmd.Parameters.AddWithValue("@reqeustId", requestId);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@dateCreated", dateCreated);

                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();

                return result;
            }
            catch (Exception)
            {
                throw;
            }



        }

        [DataObjectMethod(DataObjectMethodType.Select)]

        public int SelectValidPhoneNumberCount(String international_format)
        {
            List<phoneNumInfo> data = null;
            try
            {
                using (SummerIntern db = new SummerIntern())
                {
                    data = db.phoneNumInfoes.Where(e => string.Equals(e.international_format, international_format)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return data.Count;
        }
        public int SelectInvalidPhoneNumberCount(String number)
        {
            List<phoneNumInfo> data = null;
            try
            {
                string result = "False";
                using (SummerIntern db = new SummerIntern())
                {
                    data = db.phoneNumInfoes.Where(e => string.Equals(e.number, number) && string.Equals(e.valid, result)).ToList();


                }

            }
            catch (Exception)
            {
                throw;
            }
            return data.Count;
        }

        public List<phoneNumberInfoDto> SelectValidPhoneNumberInfo(String international_format)
        {
            List<phoneNumInfo> data = null;
            List<phoneNumberInfoDto> values = null;

            try
            {
                using (SummerIntern db = new SummerIntern())
                {
                    data = (from e in db.phoneNumInfoes
                            where string.Equals(e.international_format, international_format)
                            select e).ToList();

                    values = data.Select(er => new phoneNumberInfoDto
                    {
                        number = er.number,
                        valid = er.valid,
                        local_format = er.local_format,
                        international_format = er.international_format,
                        country_prefix = er.country_prefix,
                        country_code = er.country_code,
                        country_name = er.country_name,
                        location = er.pn_location,
                        carrier = er.carrier,
                        line_type = er.line_type,
                        username = er.username,
                        requestId=er.requestId
                       

                    }).ToList();
                }    
            }
            catch(Exception)
            {
                throw;
            }
 
            return values;
        }

        public List<phoneNumberInfoDto> SelectInvalidPhoneNumberInfo(String number)
        {
            List<phoneNumInfo> data = null;
            List<phoneNumberInfoDto> values = null;
            try
            {
                string result = "False";
                using (SummerIntern db = new SummerIntern())
                {
                    data = db.phoneNumInfoes.Where(e => string.Equals(e.number, number) && string.Equals(e.valid, result)).ToList();


                    values = data.Select(er => new phoneNumberInfoDto
                    {
                        number = er.number,
                        valid = er.valid,
                        local_format = er.local_format,
                        international_format = er.international_format,
                        country_prefix = er.country_prefix,
                        country_code = er.country_code,
                        country_name = er.country_name,
                        location = er.pn_location,
                        carrier = er.carrier,
                        line_type = er.line_type,
                        username = er.username,
                        requestId = er.requestId


                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return values;
        }

    }
}