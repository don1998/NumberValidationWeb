namespace pnVerify.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmailAddress")]
    public partial class EmailAddress
    {
        [Key]
        public int e_id { get; set; }

        [StringLength(50)]
        public string emails { get; set; }

        [StringLength(50)]
        public string did_you_mean { get; set; }

        [StringLength(50)]
        public string users { get; set; }

        [StringLength(50)]
        public string format_valid { get; set; }

        [StringLength(10)]
        public string mx_found { get; set; }

        [StringLength(10)]
        public string smtp_check { get; set; }

        [StringLength(10)]
        public string catch_all { get; set; }

        [StringLength(10)]
        public string roles { get; set; }

        [StringLength(10)]
        public string disposable { get; set; }

        [StringLength(10)]
        public string free { get; set; }

        public decimal? score { get; set; }

        [StringLength(20)]
        public string domain { get; set; }
    }
}
