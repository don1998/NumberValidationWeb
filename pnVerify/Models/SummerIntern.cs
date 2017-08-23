namespace pnVerify.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SummerIntern : DbContext
    {
        public SummerIntern()
            : base("name=SummerIntern2")
        {
        }

        public virtual DbSet<phoneNumInfo> phoneNumInfoes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<phoneNumInfo>()
                .Property(e => e.valid)
                .IsUnicode(false);

            modelBuilder.Entity<phoneNumInfo>()
                .Property(e => e.international_format)
                .IsUnicode(false);

            modelBuilder.Entity<phoneNumInfo>()
                .Property(e => e.country_name)
                .IsUnicode(false);

            modelBuilder.Entity<phoneNumInfo>()
                .Property(e => e.carrier)
                .IsUnicode(false);

            modelBuilder.Entity<phoneNumInfo>()
                .Property(e => e.line_type)
                .IsUnicode(false);

            modelBuilder.Entity<phoneNumInfo>()
                .Property(e => e.country_prefix)
                .IsUnicode(false);

            modelBuilder.Entity<phoneNumInfo>()
                .Property(e => e.pn_location)
                .IsUnicode(false);

            modelBuilder.Entity<phoneNumInfo>()
                .Property(e => e.country_code)
                .IsUnicode(false);

            modelBuilder.Entity<phoneNumInfo>()
                .Property(e => e.local_format)
                .IsUnicode(false);

            modelBuilder.Entity<phoneNumInfo>()
                .Property(e => e.number)
                .IsUnicode(false);

            modelBuilder.Entity<phoneNumInfo>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<phoneNumInfo>()
                .Property(e => e.requestId)
                .IsUnicode(false);

            modelBuilder.Entity<phoneNumInfo>()
                .Property(e => e.dateCreated)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.fullName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.department)
                .IsUnicode(false);
        }
    }
}
