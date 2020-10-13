namespace IdentityLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Firebird.ASPNETROLES")]
    public partial class ASPNETROLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ASPNETROLE()
        {
            ASPNETUSERS = new HashSet<ASPNETUSER>();
        }

        public string ID { get; set; }

        [Required]
        [StringLength(256)]
        public string NAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASPNETUSER> ASPNETUSERS { get; set; }
    }
}
