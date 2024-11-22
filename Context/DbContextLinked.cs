using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;


namespace WebApiReport.Context
{
    public class DbContextLinked : DbContext
    {
        public IConfiguration Configuration { get; }
        public DbContextLinked()
        {
        }

        public DbContextLinked(DbContextOptions<DbContextLinked> options)
            : base(options)
        {
        }

        public virtual DbSet<tTicket> tTickets { get; set; }
        public virtual DbSet<MsUser> MsUsers { get; set; }
        public virtual DbSet<SubCategoryLv3> SubCategoryLv3s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tTicket>(entity =>
            {
                entity.ToTable("tTicket");

                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .ValueGeneratedOnAdd() // Auto-increment or identity column
                    .HasColumnName("ID"); // Column name in the database

                entity.Property(e => e.NIK)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NIK");

                entity.Property(e => e.TicketNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TicketNumber");

                // Add other properties as needed
                entity.Property(e => e.GroupTicketNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GroupTicketNumber");

                entity.Property(e => e.Channel_Code)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Channel_Code");
            });


            modelBuilder.Entity<SubCategoryLv3>(entity =>
            {
                entity.ToTable("mSubCategoryLv3");

                entity.HasKey(e => e.ID);

                entity.Property(e => e.CustomerID)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CustomerID");

                entity.Property(e => e.IDKamus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IDKamus");

                entity.Property(e => e.CategoryID)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CategoryID");

                entity.Property(e => e.SubCategory1ID)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SubCategory1ID");

                entity.Property(e => e.SubCategory2ID)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SubCategory2ID");

                entity.Property(e => e.SubCategory3ID)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SubCategory3ID");

                entity.Property(e => e.SubName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SubName");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("Description");

                entity.Property(e => e.TujuanEskalasi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TujuanEskalasi");

                entity.Property(e => e.Priority)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Priority");

                entity.Property(e => e.Severity)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Severity");

                entity.Property(e => e.NA)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NA");

                entity.Property(e => e.SLA)
                    .HasColumnName("SLA");

                entity.Property(e => e.ReasonCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ReasonCode");

                entity.Property(e => e.Response_Agent)
                    .HasColumnType("varchar(max)")
                    .HasColumnName("Response_Agent");

                entity.Property(e => e.Status_Customer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Status_Customer");

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Version");

                entity.Property(e => e.Contract_Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("Contract_Startdate");

                entity.Property(e => e.Contract_Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("Contract_Enddate");

                entity.Property(e => e.License)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("License");

                entity.Property(e => e.UserCreate)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("UserCreate");

                entity.Property(e => e.DateCreate)
                    .HasColumnType("datetime")
                    .HasColumnName("DateCreate");

                entity.Property(e => e.UserUpdate)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("UserUpdate");

                entity.Property(e => e.DateUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("DateUpdate");

                entity.Property(e => e.Layer)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Layer");
            });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MsUser>(entity =>
            {
                // Table name
                entity.ToTable("msUser");

                // Primary key
                entity.HasKey(e => e.UserId);

                // Property configurations
                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(max)");

               

                entity.Property(e => e.Acd)
                    .HasMaxLength(50);

                entity.Property(e => e.Authority)
                    .HasMaxLength(50);

                entity.Property(e => e.Include)
                    .HasMaxLength(3);

                entity.Property(e => e.State)
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .HasMaxLength(50);


                entity.Property(e => e.Linkstate)
                    .HasMaxLength(3);

           

                entity.Property(e => e.Password)
                    .HasMaxLength(150);

                entity.Property(e => e.PassTemp)
                    .HasMaxLength(10);

                entity.Property(e => e.Flag)
                    .HasMaxLength(50);

                entity.Property(e => e.Organization)
                    .HasMaxLength(50);

            

                entity.Property(e => e.Path)
                    .HasMaxLength(500);

                entity.Property(e => e.IdAux)
                    .HasMaxLength(4);

                entity.Property(e => e.DescAux)
                    .HasMaxLength(150);

                entity.Property(e => e.KirimEmail)
                    .HasMaxLength(10);

              

                entity.Property(e => e.Description)
                    .HasMaxLength(1000);

                entity.Property(e => e.Color)
                    .HasMaxLength(50);

              
                entity.Property(e => e.TokenMeta)
                    .HasColumnType("nvarchar(max)");

                // Default values
                entity.Property(e => e.Inbound)
                    .HasDefaultValue(false);

                entity.Property(e => e.Outbound)
                    .HasDefaultValue(false);

                entity.Property(e => e.Fax)
                    .HasDefaultValue(false);

                entity.Property(e => e.Sms)
                    .HasDefaultValue(false);

                entity.Property(e => e.Email)
                    .HasDefaultValue(false);

                entity.Property(e => e.Facebook)
                    .HasDefaultValue(false);

                entity.Property(e => e.Twitter)
                    .HasDefaultValue(false);

                entity.Property(e => e.AdminTool)
                    .HasDefaultValue(false);

                entity.Property(e => e.Smsblast)
                    .HasDefaultValue(false);

                entity.Property(e => e.Chat)
                    .HasDefaultValue(false);

                entity.Property(e => e.Sosmed)
                    .HasDefaultValue(false);

                entity.Property(e => e.Telemarketing)
                    .HasDefaultValue(false);

                entity.Property(e => e.Collections)
                    .HasDefaultValue(false);

              

                // Relationships can be configured here if there are any
                // For example:
                // entity.HasOne(e => e.Role)
                //       .WithMany(r => r.MsUsers)
                //       .HasForeignKey(e => e.RoleId);
            });
        }
    }
}
