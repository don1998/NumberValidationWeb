using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace pnVerify.Models
{
    public class phoneNumberInfoDto
    {
        [DataMember]
        public String valid { get; set; }

        [DataMember]
        public String local_format { get; set; }

        [DataMember]
        public String international_format { get; set; }

        [DataMember]
        public String country_prefix { get; set; }

        [DataMember]
        public String country_code { get; set; }

        [DataMember]
        public String country_name { get; set; }

        [DataMember]
        public String location { get; set; }

        [DataMember]
        public String carrier { get; set; }

        [DataMember]
        public String line_type { get; set; }

        [DataMember]
        public String number { get; set; }

        public String username { get; set; }

        public String requestId { get; set; }

    }
}