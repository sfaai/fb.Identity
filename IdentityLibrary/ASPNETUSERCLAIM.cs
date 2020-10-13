namespace IdentityLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Firebird.ASPNETUSERCLAIMS")]
    public partial class ASPNETUSERCLAIM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string USERID { get; set; }

        [StringLength(8170)]
        public string CLAIMTYPE { get; set; }

        [StringLength(8170)]
        public string CLAIMVALUE { get; set; }

        public virtual ASPNETUSER ASPNETUSER { get; set; }
    }
}
