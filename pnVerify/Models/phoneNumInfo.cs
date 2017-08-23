namespace pnVerify.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("phoneNumInfo")]
    public partial class phoneNumInfo
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string valid { get; set; }

        [StringLength(20)]
        public string international_format { get; set; }

        [StringLength(20)]
        public string country_name { get; set; }

        [StringLength(20)]
        public string carrier { get; set; }

        [StringLength(20)]
        public string line_type { get; set; }

        [StringLength(5)]
        public string country_prefix { get; set; }

        [StringLength(20)]
        public string pn_location { get; set; }

        [StringLength(5)]
        public string country_code { get; set; }

        [StringLength(20)]
        public string local_format { get; set; }

        [StringLength(20)]
        public string number { get; set; }

        [StringLength(30)]
        public string username { get; set; }

        [StringLength(20)]
        public string requestId { get; set; }

        [StringLength(50)]
        public string dateCreated { get; set; }

        public virtual User User { get; set; }
    }
}
