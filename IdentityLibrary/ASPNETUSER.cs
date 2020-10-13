namespace IdentityLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Firebird.ASPNETUSERS")]
    public partial class ASPNETUSER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ASPNETUSER()
        {
            ASPNETUSERCLAIMS = new HashSet<ASPNETUSERCLAIM>();
            ASPNETUSERLOGINS = new HashSet<ASPNETUSERLOGIN>();
            ASPNETROLES = new HashSet<ASPNETROLE>();
        }

        public string ID { get; set; }

        [StringLength(256)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(1)]
        public string EMAILCONFIRMED { get; set; }

        [StringLength(8190)]
        public string PASSWORDHASH { get; set; }

        [StringLength(8190)]
        public string SECURITYSTAMP { get; set; }

        [StringLength(8190)]
        public string PHONENUMBER { get; set; }

        [Required]
        [StringLength(1)]
        public string PHONENUMBERCONFIRMED { get; set; }

        [Required]
        [StringLength(1)]
        public string TWOFACTORENABLED { get; set; }

        public DateTime? LOCKOUTENDDATEUTC { get; set; }

        [Required]
        [StringLength(1)]
        public string LOCKOUTENABLED { get; set; }

        public int ACCESSFAILEDCOUNT { get; set; }

        [Required]
        [StringLength(256)]
        public string USERNAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASPNETUSERCLAIM> ASPNETUSERCLAIMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASPNETUSERLOGIN> ASPNETUSERLOGINS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASPNETROLE> ASPNETROLES { get; set; }
    }
}
