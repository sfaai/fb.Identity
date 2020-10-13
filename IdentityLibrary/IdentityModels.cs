namespace IdentityLibrary
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IdentityModels : DbContext
    {
        public IdentityModels()
            : base("name=IdentityModels")
        {
        }

        public virtual DbSet<ASPNETROLE> ASPNETROLES { get; set; }
        public virtual DbSet<ASPNETUSERCLAIM> ASPNETUSERCLAIMS { get; set; }
        public virtual DbSet<ASPNETUSERLOGIN> ASPNETUSERLOGINS { get; set; }
        public virtual DbSet<ASPNETUSER> ASPNETUSERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ASPNETROLE>()
                .HasMany(e => e.ASPNETUSERS)
                .WithMany(e => e.ASPNETROLES)
                .Map(m => m.ToTable("ASPNETUSERROLES", "Firebird").MapLeftKey("ROLEID").MapRightKey("USERID"));

            modelBuilder.Entity<ASPNETUSER>()
                .Property(e => e.EMAILCONFIRMED)
                .IsFixedLength();

            modelBuilder.Entity<ASPNETUSER>()
                .Property(e => e.PHONENUMBERCONFIRMED)
                .IsFixedLength();

            modelBuilder.Entity<ASPNETUSER>()
                .Property(e => e.TWOFACTORENABLED)
                .IsFixedLength();

            modelBuilder.Entity<ASPNETUSER>()
                .Property(e => e.LOCKOUTENABLED)
                .IsFixedLength();

            modelBuilder.Entity<ASPNETUSER>()
                .HasMany(e => e.ASPNETUSERCLAIMS)
                .WithRequired(e => e.ASPNETUSER)
                .HasForeignKey(e => e.USERID);

            modelBuilder.Entity<ASPNETUSER>()
                .HasMany(e => e.ASPNETUSERLOGINS)
                .WithRequired(e => e.ASPNETUSER)
                .HasForeignKey(e => e.USERID);
        }
    }
}
