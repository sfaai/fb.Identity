namespace IdentityLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Firebird.ASPNETUSERLOGINS")]
    public partial class ASPNETUSERLOGIN
    {
        [Key]
        [Column(Order = 0)]
        public string LOGINPROVIDER { get; set; }

        [Key]
        [Column(Order = 1)]
        public string PROVIDERKEY { get; set; }

        [Key]
        [Column(Order = 2)]
        public string USERID { get; set; }

        public virtual ASPNETUSER ASPNETUSER { get; set; }
    }
}
