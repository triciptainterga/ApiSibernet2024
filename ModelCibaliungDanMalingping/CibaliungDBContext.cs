using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace WebApiReport.ModelCibaliungDanMalingping
{
    public partial class CibaliungDBContext : DbContext
    {
        public IConfiguration Configuration { get; }
        public CibaliungDBContext()
        {
        }

        public CibaliungDBContext(DbContextOptions<CibaliungDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Na> Nas { get; set; }
        public virtual DbSet<Radacct> Radaccts { get; set; }
        public virtual DbSet<Radcheck> Radchecks { get; set; }
        public virtual DbSet<Radgroupcheck> Radgroupchecks { get; set; }
        public virtual DbSet<Radgroupreply> Radgroupreplies { get; set; }
        public virtual DbSet<Radippool> Radippools { get; set; }
        public virtual DbSet<Radpostauth> Radpostauths { get; set; }
        public virtual DbSet<Radreply> Radreplies { get; set; }
        public virtual DbSet<Radusergroup> Radusergroups { get; set; }
        public virtual DbSet<TblActivation> TblActivations { get; set; }
        public virtual DbSet<TblAppconfig> TblAppconfigs { get; set; }
        public virtual DbSet<TblBandwidth> TblBandwidths { get; set; }
        public virtual DbSet<TblCalledstation> TblCalledstations { get; set; }
        public virtual DbSet<TblCustomer> TblCustomers { get; set; }
        public virtual DbSet<TblCustomersMap> TblCustomersMaps { get; set; }
        public virtual DbSet<TblHotspotDn> TblHotspotDns { get; set; }
        public virtual DbSet<TblIsolirPool> TblIsolirPools { get; set; }
        public virtual DbSet<TblLanguage> TblLanguages { get; set; }
        public virtual DbSet<TblLog> TblLogs { get; set; }
        public virtual DbSet<TblMessageTpl> TblMessageTpls { get; set; }
        public virtual DbSet<TblOdpDatum> TblOdpData { get; set; }
        public virtual DbSet<TblPayout> TblPayouts { get; set; }
        public virtual DbSet<TblPlan> TblPlans { get; set; }
        public virtual DbSet<TblProfileGroup> TblProfileGroups { get; set; }
        public virtual DbSet<TblTicketsContent> TblTicketsContents { get; set; }
        public virtual DbSet<TblTicketsRequest> TblTicketsRequests { get; set; }
        public virtual DbSet<TblTransactionResponse> TblTransactions { get; set; }
        public virtual DbSet<TblTrxDuitku> TblTrxDuitkus { get; set; }
        public virtual DbSet<TblTrxIpaymu> TblTrxIpaymus { get; set; }
        public virtual DbSet<TblTrxMidtran> TblTrxMidtrans { get; set; }
        public virtual DbSet<TblTrxNicepay> TblTrxNicepays { get; set; }
        public virtual DbSet<TblTrxPaypal> TblTrxPaypals { get; set; }
        public virtual DbSet<TblTrxXendit> TblTrxXendits { get; set; }
        public virtual DbSet<TblTrxXenditVa> TblTrxXenditVas { get; set; }
        public virtual DbSet<TblUsageReport> TblUsageReports { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<TblUsersfund> TblUsersfunds { get; set; }
        public virtual DbSet<TblVoucher> TblVouchers { get; set; }
        public virtual DbSet<TblVouchersEvc> TblVouchersEvcs { get; set; }
        public virtual DbSet<TblVouchersTpl> TblVouchersTpls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(Configuration.GetConnectionString("SqlConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Na>(entity =>
            {
                entity.ToTable("nas");

                entity.HasIndex(e => e.Nasname, "nasname");

                entity.HasIndex(e => e.Shortname, "shortname");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.ApiPassword)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("api_password");

                entity.Property(e => e.ApiPort)
                    .HasColumnType("int(5)")
                    .HasColumnName("api_port");

                entity.Property(e => e.ApiUsername)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("api_username");

                entity.Property(e => e.Community)
                    .HasMaxLength(60)
                    .HasColumnName("community")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'''RADIUS Client'''");

                entity.Property(e => e.Nasname)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("nasname");

                entity.Property(e => e.Ports)
                    .HasColumnType("int(5)")
                    .HasColumnName("ports")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RedirectUrl)
                    .HasMaxLength(128)
                    .HasColumnName("redirect_url")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnName("region");

                entity.Property(e => e.Secret)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("secret")
                    .HasDefaultValueSql("'''secret'''");

                entity.Property(e => e.Server)
                    .HasMaxLength(60)
                    .HasColumnName("server")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Shortname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("shortname");

                entity.Property(e => e.Timezone)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("timezone");

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .HasColumnName("type")
                    .HasDefaultValueSql("'''other'''");
            });

            modelBuilder.Entity<Radacct>(entity =>
            {
                entity.ToTable("radacct");

                entity.HasIndex(e => e.Acctinterval, "acctinterval");

                entity.HasIndex(e => e.Acctsessionid, "acctsessionid");

                entity.HasIndex(e => e.Acctsessiontime, "acctsessiontime");

                entity.HasIndex(e => e.Acctstarttime, "acctstarttime");

                entity.HasIndex(e => e.Acctstoptime, "acctstoptime");

                entity.HasIndex(e => e.Acctuniqueid, "acctuniqueid")
                    .IsUnique();

                entity.HasIndex(e => e.Framedipaddress, "framedipaddress");

                entity.HasIndex(e => e.Nasipaddress, "nasipaddress");

                entity.HasIndex(e => e.Username, "username");

                entity.Property(e => e.Radacctid)
                    .HasColumnType("bigint(21)")
                    .HasColumnName("radacctid");

                entity.Property(e => e.Acctauthentic)
                    .HasMaxLength(32)
                    .HasColumnName("acctauthentic")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Acctinputoctets)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("acctinputoctets")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Acctinterval)
                    .HasColumnType("int(12)")
                    .HasColumnName("acctinterval")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Acctoutputoctets)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("acctoutputoctets")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Acctsessionid)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("acctsessionid")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Acctsessiontime)
                    .HasColumnType("int(12) unsigned")
                    .HasColumnName("acctsessiontime")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Acctstarttime)
                    .HasColumnName("acctstarttime")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Acctstoptime)
                    .HasColumnName("acctstoptime")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Acctterminatecause)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("acctterminatecause")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Acctuniqueid)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("acctuniqueid")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Acctupdatetime)
                    .HasColumnName("acctupdatetime")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Calledstationid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("calledstationid")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Callingstationid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("callingstationid")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.ConnectinfoStart)
                    .HasMaxLength(50)
                    .HasColumnName("connectinfo_start")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ConnectinfoStop)
                    .HasMaxLength(50)
                    .HasColumnName("connectinfo_stop")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Framedipaddress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("framedipaddress")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Framedprotocol)
                    .HasMaxLength(32)
                    .HasColumnName("framedprotocol")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Groupname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("groupname")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Nasipaddress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("nasipaddress")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Nasportid)
                    .HasMaxLength(15)
                    .HasColumnName("nasportid")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nasporttype)
                    .HasMaxLength(32)
                    .HasColumnName("nasporttype")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nasshortname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("nasshortname")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Realm)
                    .HasMaxLength(64)
                    .HasColumnName("realm")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Servicetype)
                    .HasMaxLength(32)
                    .HasColumnName("servicetype")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Radcheck>(entity =>
            {
                entity.ToTable("radcheck");

                entity.HasIndex(e => e.Username, "username");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("attribute")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Method)
                    .IsRequired()
                    .HasColumnType("enum('MEMBER','VOUCHER')")
                    .HasColumnName("method");

                entity.Property(e => e.Op)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("op")
                    .HasDefaultValueSql("'''=='''")
                    .IsFixedLength(true);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("enum('HOTSPOT','PPP')")
                    .HasColumnName("type");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(253)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Radgroupcheck>(entity =>
            {
                entity.ToTable("radgroupcheck");

                entity.HasIndex(e => e.Groupname, "groupname");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("attribute")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Groupname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("groupname")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Op)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("op")
                    .HasDefaultValueSql("'''=='''")
                    .IsFixedLength(true);

                entity.Property(e => e.PlanId)
                    .HasColumnType("int(11)")
                    .HasColumnName("plan_id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(253)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Radgroupreply>(entity =>
            {
                entity.ToTable("radgroupreply");

                entity.HasIndex(e => e.Groupname, "groupname");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("attribute")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Groupname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("groupname")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Op)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("op")
                    .HasDefaultValueSql("'''='''")
                    .IsFixedLength(true);

                entity.Property(e => e.PlanId)
                    .HasColumnType("int(11)")
                    .HasColumnName("plan_id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(253)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Radippool>(entity =>
            {
                entity.ToTable("radippool");

                entity.HasIndex(e => e.Framedipaddress, "framedipaddress");

                entity.HasIndex(e => new { e.Nasipaddress, e.PoolKey, e.Framedipaddress }, "radippool_nasip_poolkey_ipaddress");

                entity.HasIndex(e => new { e.PoolName, e.ExpiryTime }, "radippool_poolname_expire");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Calledstationid)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("calledstationid");

                entity.Property(e => e.Callingstationid)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("callingstationid");

                entity.Property(e => e.ExpiryTime)
                    .HasColumnName("expiry_time")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Framedipaddress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("framedipaddress")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Nasipaddress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("nasipaddress")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.PoolKey)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("pool_key");

                entity.Property(e => e.PoolName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("pool_name");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Radpostauth>(entity =>
            {
                entity.ToTable("radpostauth");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Calledstationid)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("calledstationid")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Callingstationid)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("callingstationid")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Nas)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("nas")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Reply)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("reply")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Radreply>(entity =>
            {
                entity.ToTable("radreply");

                entity.HasIndex(e => e.Username, "username");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("attribute")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Method)
                    .IsRequired()
                    .HasColumnType("enum('MEMBER','VOUCHER')")
                    .HasColumnName("method");

                entity.Property(e => e.Op)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("op")
                    .HasDefaultValueSql("'''='''")
                    .IsFixedLength(true);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("enum('HOTSPOT','PPP')")
                    .HasColumnName("type");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(253)
                    .HasColumnName("value")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<Radusergroup>(entity =>
            {
                entity.ToTable("radusergroup");

                entity.HasIndex(e => e.Username, "username");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Groupname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("groupname")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Method)
                    .IsRequired()
                    .HasColumnType("enum('MEMBER','VOUCHER')")
                    .HasColumnName("method");

                entity.Property(e => e.Priority)
                    .HasColumnType("int(11)")
                    .HasColumnName("priority")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("enum('HOTSPOT','PPP')")
                    .HasColumnName("type");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<TblActivation>(entity =>
            {
                entity.ToTable("tbl_activation");

                entity.Property(e => e.Id)
                    .HasColumnType("enum('1')")
                    .HasColumnName("id");

                entity.Property(e => e.ActivationDate).HasColumnName("activation_date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("email")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.HardwareId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("hardware_id")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.RequestId)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("request_id")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.SoftwareKey)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("software_key")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<TblAppconfig>(entity =>
            {
                entity.ToTable("tbl_appconfig");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Setting)
                    .IsRequired()
                    .HasColumnName("setting");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TblBandwidth>(entity =>
            {
                entity.ToTable("tbl_bandwidth");

                entity.HasIndex(e => e.NameBw, "name_bw");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.HasIndex(e => e.OwnerName, "owner_name");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.MaxRateDown)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("max_rate_down");

                entity.Property(e => e.MaxRateDownUnit)
                    .IsRequired()
                    .HasColumnType("enum('Kbps','Mbps')")
                    .HasColumnName("max_rate_down_unit");

                entity.Property(e => e.MaxRateUp)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("max_rate_up");

                entity.Property(e => e.MaxRateUpUnit)
                    .IsRequired()
                    .HasColumnType("enum('Kbps','Mbps')")
                    .HasColumnName("max_rate_up_unit");

                entity.Property(e => e.MinRateDown)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("min_rate_down");

                entity.Property(e => e.MinRateDownUnit)
                    .IsRequired()
                    .HasColumnType("enum('Kbps','Mbps')")
                    .HasColumnName("min_rate_down_unit");

                entity.Property(e => e.MinRateUp)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("min_rate_up");

                entity.Property(e => e.MinRateUpUnit)
                    .IsRequired()
                    .HasColumnType("enum('Kbps','Mbps')")
                    .HasColumnName("min_rate_up_unit");

                entity.Property(e => e.NameBw)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name_bw");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");
            });

            modelBuilder.Entity<TblCalledstation>(entity =>
            {
                entity.ToTable("tbl_calledstation");

                entity.HasIndex(e => e.Calledstation, "calledstation");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.HasIndex(e => e.Type, "type");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Calledstation)
                    .HasMaxLength(128)
                    .HasColumnName("calledstation")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Nas)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("nas");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("enum('HOTSPOT','PPP')")
                    .HasColumnName("type");
            });

            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.ToTable("tbl_customers");

                entity.HasIndex(e => e.AuthStatus, "auth_status");

                entity.HasIndex(e => e.ExpiredOn, "expired_on");

                entity.HasIndex(e => e.Fullname, "fullname");

                entity.HasIndex(e => e.MemberId, "member_id");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.HasIndex(e => e.OwnerName, "owner_name");

                entity.HasIndex(e => e.PlanName, "plan_name");

                entity.HasIndex(e => e.RenewedOn, "renewed_on");

                entity.HasIndex(e => e.TrxInvoice, "trx_invoice");

                entity.HasIndex(e => e.TrxStatus, "trx_status");

                entity.HasIndex(e => e.Type, "type");

                entity.HasIndex(e => e.Username, "username");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.AuthStatus)
                    .IsRequired()
                    .HasColumnType("enum('Enabled-Users','Disabled-Users')")
                    .HasColumnName("auth_status")
                    .HasDefaultValueSql("'''Enabled-Users'''");

                entity.Property(e => e.BindMac)
                    .IsRequired()
                    .HasColumnType("enum('NO','YES')")
                    .HasColumnName("bind_mac")
                    .HasDefaultValueSql("'''NO'''");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DeviceFee)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("device_fee")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("email");

                entity.Property(e => e.EmailAlert)
                    .IsRequired()
                    .HasColumnType("enum('A0','A1','A2','A3')")
                    .HasColumnName("email_alert")
                    .HasDefaultValueSql("'''A1'''");

                entity.Property(e => e.ExpiredOn)
                    .HasColumnName("expired_on")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("fullname");

                entity.Property(e => e.IdentityNumber)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("identity_number")
                    .HasDefaultValueSql("'''d012T2EvUUtrSCtXQWlhb09QaE5oREkzVStoN1FSWW5MdEVmNWpZTTFIWT0='''");

                entity.Property(e => e.InputStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("input_status")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoice_date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LastLogin)
                    .HasColumnName("last_login")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LocalAddress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("local_address");

                entity.Property(e => e.MacAddress)
                    .HasMaxLength(17)
                    .HasColumnName("mac_address")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("member_id")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.Method)
                    .IsRequired()
                    .HasColumnType("enum('MEMBER')")
                    .HasColumnName("method");

                entity.Property(e => e.Nasporttype)
                    .HasMaxLength(20)
                    .HasColumnName("nasporttype")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Note)
                    .HasMaxLength(128)
                    .HasColumnName("note")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("password");

                entity.Property(e => e.PaymentStatus)
                    .HasColumnName("payment_status")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasColumnType("enum('PREPAID','POSTPAID')")
                    .HasColumnName("payment_type")
                    .HasDefaultValueSql("'''PREPAID'''");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(20)
                    .HasColumnName("phonenumber")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PlanName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("plan_name");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("price")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.RemoteAddress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("remote_address");

                entity.Property(e => e.RenewedOn)
                    .HasColumnName("renewed_on")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Secret)
                    .IsRequired()
                    .HasColumnName("secret");

                entity.Property(e => e.SellerFee)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("seller_fee")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.ServerName)
                    .HasMaxLength(128)
                    .HasColumnName("server_name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Servicetype)
                    .HasMaxLength(20)
                    .HasColumnName("servicetype")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SetupFee)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("setup_fee")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.SmsAlert)
                    .IsRequired()
                    .HasColumnType("enum('A0','A1','A2','A3')")
                    .HasColumnName("sms_alert")
                    .HasDefaultValueSql("'''A1'''");

                entity.Property(e => e.Tax)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("tax")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.Total)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("total")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.TrxInvoice)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("trx_invoice");

                entity.Property(e => e.TrxStatus)
                    .IsRequired()
                    .HasColumnType("enum('PAID','UNPAID','PENDING')")
                    .HasColumnName("trx_status")
                    .HasDefaultValueSql("'''PAID'''");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("enum('HOTSPOT','PPP')")
                    .HasColumnName("type");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username");

                entity.Property(e => e.WaAlert)
                    .IsRequired()
                    .HasColumnType("enum('A0','A1','A2','A3')")
                    .HasColumnName("wa_alert")
                    .HasDefaultValueSql("'''A1'''");
            });

            modelBuilder.Entity<TblCustomersMap>(entity =>
            {
                entity.ToTable("tbl_customers_map");

                entity.HasIndex(e => e.CustomerId, "customer_id");

                entity.HasIndex(e => e.OdpId, "odp_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("longitude");

                entity.Property(e => e.OdpId)
                    .HasColumnType("int(11)")
                    .HasColumnName("odp_id");
            });

            modelBuilder.Entity<TblHotspotDn>(entity =>
            {
                entity.ToTable("tbl_hotspot_dns");

                entity.HasIndex(e => e.EvoucherVisibility, "evoucher_visibility");

                entity.HasIndex(e => e.HotspotDomain, "hotspot_domain");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.EvoucherVisibility)
                    .HasColumnType("int(1)")
                    .HasColumnName("evoucher_visibility");

                entity.Property(e => e.HotspotDomain)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("hotspot_domain");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");
            });

            modelBuilder.Entity<TblIsolirPool>(entity =>
            {
                entity.ToTable("tbl_isolir_pool");

                entity.HasIndex(e => e.Framedipaddress, "framedipaddress");

                entity.HasIndex(e => new { e.Nasipaddress, e.Framedipaddress }, "isolir_nasip_ipaddress");

                entity.HasIndex(e => new { e.PoolName, e.ExpiryTime }, "isolir_poolname_expire");

                entity.HasIndex(e => e.Username, "username");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Calledstationid)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("calledstationid");

                entity.Property(e => e.Callingstationid)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("callingstationid");

                entity.Property(e => e.ExpiryTime)
                    .HasColumnName("expiry_time")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Framedipaddress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("framedipaddress")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Nasipaddress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("nasipaddress")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.PoolName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("pool_name");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''''''");
            });

            modelBuilder.Entity<TblLanguage>(entity =>
            {
                entity.ToTable("tbl_language");

                entity.HasIndex(e => e.Name, "name");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasMaxLength(60)
                    .HasColumnName("author")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Folder)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("folder");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TblLog>(entity =>
            {
                entity.ToTable("tbl_logs");

                entity.HasIndex(e => e.Date, "date");

                entity.HasIndex(e => e.Date, "date_2");

                entity.HasIndex(e => e.Type, "type");

                entity.HasIndex(e => e.Type, "type_2");

                entity.HasIndex(e => e.Userid, "userid");

                entity.HasIndex(e => e.Userid, "userid_2");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasDefaultValueSql("'''2018-01-01 00:00:00'''");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip");

                entity.Property(e => e.Nas)
                    .HasMaxLength(32)
                    .HasColumnName("nas")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.Property(e => e.Userid)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<TblMessageTpl>(entity =>
            {
                entity.ToTable("tbl_message_tpl");

                entity.HasIndex(e => e.Channel, "channel");

                entity.HasIndex(e => e.Vendor, "vendor");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Channel)
                    .IsRequired()
                    .HasColumnType("enum('WHATSAPP','SMS','TELEGRAM')")
                    .HasColumnName("channel");

                entity.Property(e => e.DueinfoMsg)
                    .HasColumnName("dueinfo_msg")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RegistrationMsg)
                    .HasColumnName("registration_msg")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RenewalMsg)
                    .HasColumnName("renewal_msg")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Vendor)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("vendor");
            });

            modelBuilder.Entity<TblOdpDatum>(entity =>
            {
                entity.ToTable("tbl_odp_data");

                entity.HasIndex(e => e.OdpArea, "odp_area");

                entity.HasIndex(e => e.OdpName, "odp_name");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.OdpArea)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("odp_area");

                entity.Property(e => e.OdpLatitude)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("odp_latitude");

                entity.Property(e => e.OdpLongitude)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("odp_longitude");

                entity.Property(e => e.OdpName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("odp_name");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");
            });

            modelBuilder.Entity<TblPayout>(entity =>
            {
                entity.ToTable("tbl_payout");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.HasIndex(e => e.OwnerName, "owner_name");

                entity.HasIndex(e => e.PayoutDate, "payout_date");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");

                entity.Property(e => e.PaidBy)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("paid_by");

                entity.Property(e => e.PayoutAmount)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("payout_amount");

                entity.Property(e => e.PayoutDate).HasColumnName("payout_date");

                entity.Property(e => e.PayoutDescription)
                    .IsRequired()
                    .HasColumnName("payout_description");

                entity.Property(e => e.PayoutType)
                    .IsRequired()
                    .HasColumnType("enum('Operational','Others')")
                    .HasColumnName("payout_type")
                    .HasDefaultValueSql("'''Operational'''");
            });

            modelBuilder.Entity<TblPlan>(entity =>
            {
                entity.ToTable("tbl_plans");

                entity.HasIndex(e => e.BwName, "bw_name");

                entity.HasIndex(e => e.EvoucherVisibility, "evoucher_visibility");

                entity.HasIndex(e => e.NamePlan, "name_plan");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.HasIndex(e => e.OwnerName, "owner_name");

                entity.HasIndex(e => e.PlanVisibility, "plan_visibility");

                entity.HasIndex(e => e.Type, "type");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.BurstBw)
                    .HasMaxLength(128)
                    .HasColumnName("burst_bw")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.BwName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("bw_name");

                entity.Property(e => e.DataLimit)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("data_limit")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DataUnit)
                    .HasColumnType("enum('M','G')")
                    .HasColumnName("data_unit")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EvoucherVisibility)
                    .HasColumnType("int(1)")
                    .HasColumnName("evoucher_visibility");

                entity.Property(e => e.LimitType)
                    .HasColumnType("enum('Time_Limit','Data_Limit','Both_Limit')")
                    .HasColumnName("limit_type")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NamePlan)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name_plan");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");

                entity.Property(e => e.PlanVisibility)
                    .HasColumnType("int(1)")
                    .HasColumnName("plan_visibility")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("price");

                entity.Property(e => e.Priority)
                    .IsRequired()
                    .HasColumnType("enum('1','2','3','4','5','6','7','8')")
                    .HasColumnName("priority")
                    .HasDefaultValueSql("'''8'''");

                entity.Property(e => e.ProfileGroup)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("profile_group");

                entity.Property(e => e.SellPrice)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("sell_price");

                entity.Property(e => e.SharedUsers)
                    .HasColumnType("int(11)")
                    .HasColumnName("shared_users")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tax)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("tax")
                    .HasDefaultValueSql("'''0%'''");

                entity.Property(e => e.TimeLimit)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("time_limit")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TimeUnit)
                    .HasColumnType("enum('H','D','M','Min')")
                    .HasColumnName("time_unit")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("enum('HOTSPOT','PPP')")
                    .HasColumnName("type");

                entity.Property(e => e.Typebp)
                    .HasColumnType("enum('Unlimited','Limited')")
                    .HasColumnName("typebp")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Validity)
                    .HasColumnType("int(11)")
                    .HasColumnName("validity");

                entity.Property(e => e.ValidityUnit)
                    .IsRequired()
                    .HasColumnType("enum('H','D','M','Min')")
                    .HasColumnName("validity_unit");
            });

            modelBuilder.Entity<TblProfileGroup>(entity =>
            {
                entity.ToTable("tbl_profile_group");

                entity.HasIndex(e => e.Name, "name");

                entity.HasIndex(e => e.Nasshortname, "nasshortname");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.HasIndex(e => e.OwnerName, "owner_name");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DnsServers)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("dns_servers");

                entity.Property(e => e.FirstAddress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("first_address");

                entity.Property(e => e.LastAddress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("last_address");

                entity.Property(e => e.LocalAddress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("local_address");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");

                entity.Property(e => e.Nasshortname)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("nasshortname");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");

                entity.Property(e => e.ParentName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("parent_name");

                entity.Property(e => e.PoolModule)
                    .IsRequired()
                    .HasColumnType("enum('mikrotik-ippool','sql-ippool')")
                    .HasColumnName("pool_module")
                    .HasDefaultValueSql("'''sql-ippool'''");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("enum('HOTSPOT','PPP')")
                    .HasColumnName("type");
            });

            modelBuilder.Entity<TblTicketsContent>(entity =>
            {
                entity.ToTable("tbl_tickets_content");

                entity.HasIndex(e => e.ReplyStatus, "reply_status");

                entity.HasIndex(e => e.TicketId, "ticket_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message");

                entity.Property(e => e.RepliedBy)
                    .IsRequired()
                    .HasColumnType("enum('department','customer')")
                    .HasColumnName("replied_by");

                entity.Property(e => e.ReplyDate).HasColumnName("reply_date");

                entity.Property(e => e.ReplyStatus)
                    .HasColumnType("int(1)")
                    .HasColumnName("reply_status")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TicketId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ticket_id");
            });

            modelBuilder.Entity<TblTicketsRequest>(entity =>
            {
                entity.ToTable("tbl_tickets_request");

                entity.HasIndex(e => e.CustomerId, "customer_id");

                entity.HasIndex(e => e.MemberId, "member_id");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.HasIndex(e => e.OwnerName, "owner_name");

                entity.HasIndex(e => e.Status, "status");

                entity.HasIndex(e => e.TicketNumber, "ticket_number");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("department");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("email");

                entity.Property(e => e.LastUpdate).HasColumnName("last_update");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("member_id")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");

                entity.Property(e => e.Priority)
                    .IsRequired()
                    .HasColumnType("enum('low','normal','high')")
                    .HasColumnName("priority")
                    .HasDefaultValueSql("'''normal'''");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('opened','closed')")
                    .HasColumnName("status");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("subject");

                entity.Property(e => e.TicketNumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("ticket_number");
            });

            modelBuilder.Entity<TblTransactionResponse>(entity =>
            {
                entity.ToTable("tbl_transactions");

                entity.HasIndex(e => e.CustomerId, "customer_id");

                entity.HasIndex(e => e.ExpiredOn, "expired_on");

                entity.HasIndex(e => e.Invoice, "invoice");

                entity.HasIndex(e => e.MemberId, "member_id");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.HasIndex(e => e.OwnerName, "owner_name");

                entity.HasIndex(e => e.PaymentMethod, "payment_method");

                entity.HasIndex(e => e.RenewedOn, "renewed_on");

                entity.HasIndex(e => e.TrxStatus, "trx_status");

                entity.HasIndex(e => e.Type, "type");

                entity.HasIndex(e => e.Username, "username");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.DeviceFee)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("device_fee")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("email");

                entity.Property(e => e.ExpiredOn)
                    .HasColumnName("expired_on")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("fullname");

                entity.Property(e => e.InputStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("input_status")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.Invoice)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("invoice");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoice_date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("member_id")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.Method)
                    .IsRequired()
                    .HasColumnType("enum('VOUCHER','MEMBER')")
                    .HasColumnName("method");

                entity.Property(e => e.Nasporttype)
                    .HasMaxLength(20)
                    .HasColumnName("nasporttype")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(32)
                    .HasColumnName("payment_method")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasColumnType("enum('PREPAID','POSTPAID')")
                    .HasColumnName("payment_type")
                    .HasDefaultValueSql("'''PREPAID'''");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(20)
                    .HasColumnName("phonenumber")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PlanName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("plan_name");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("price")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.RenewedOn)
                    .HasColumnName("renewed_on")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SellerFee)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("seller_fee")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.ServerName)
                    .HasMaxLength(128)
                    .HasColumnName("server_name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Servicetype)
                    .HasMaxLength(20)
                    .HasColumnName("servicetype")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SetupFee)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("setup_fee")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.Tax)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("tax")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.Total)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("total")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.TrxStatus)
                    .IsRequired()
                    .HasColumnType("enum('PAID','UNPAID','PENDING')")
                    .HasColumnName("trx_status")
                    .HasDefaultValueSql("'''PAID'''");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("enum('HOTSPOT','PPP')")
                    .HasColumnName("type");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<TblTrxDuitku>(entity =>
            {
                entity.ToTable("tbl_trx_duitku");

                entity.HasIndex(e => e.CustomerId, "customer_id");

                entity.HasIndex(e => e.Invoice, "invoice");

                entity.HasIndex(e => e.MerchantCode, "merchant_code");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.HasIndex(e => e.OwnerName, "owner_name");

                entity.HasIndex(e => e.Reference, "reference");

                entity.HasIndex(e => e.Username, "username");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("amount");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.ExpiredOn)
                    .HasColumnName("expired_on")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Invoice)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("invoice");

                entity.Property(e => e.MerchantCode)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("merchant_code");

                entity.Property(e => e.OrderKey)
                    .HasMaxLength(8)
                    .HasColumnName("order_key")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");

                entity.Property(e => e.PaymentChannel)
                    .HasColumnName("payment_channel")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PaymentCode)
                    .HasColumnName("payment_code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PaymentUrl)
                    .HasMaxLength(255)
                    .HasColumnName("payment_url")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PlanName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("plan_name");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("reference");

                entity.Property(e => e.StatusCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("status_code");

                entity.Property(e => e.TransactionStatus)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("transaction_status");

                entity.Property(e => e.TransactionTime).HasColumnName("transaction_time");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<TblTrxIpaymu>(entity =>
            {
                entity.ToTable("tbl_trx_ipaymu");

                entity.HasIndex(e => e.CustomerId, "customer_id");

                entity.HasIndex(e => e.Invoice, "invoice");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.HasIndex(e => e.OwnerName, "owner_name");

                entity.HasIndex(e => e.SessionId, "session_id");

                entity.HasIndex(e => e.TrxId, "trx_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("amount");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.ExpiredOn)
                    .HasColumnName("expired_on")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Fee)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("fee");

                entity.Property(e => e.Invoice)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("invoice");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");

                entity.Property(e => e.PaymentChannel)
                    .HasColumnName("payment_channel")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PaymentCode)
                    .HasColumnName("payment_code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasColumnName("payment_type");

                entity.Property(e => e.PlanName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("plan_name");

                entity.Property(e => e.SessionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("session_id");

                entity.Property(e => e.StatusCode)
                    .IsRequired()
                    .HasColumnType("enum('0','1','2','3')")
                    .HasColumnName("status_code");

                entity.Property(e => e.Total)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("total");

                entity.Property(e => e.TransactionStatus)
                    .IsRequired()
                    .HasColumnType("enum('pending','berhasil','batal','refund')")
                    .HasColumnName("transaction_status");

                entity.Property(e => e.TransactionTime).HasColumnName("transaction_time");

                entity.Property(e => e.TrxId)
                    .HasColumnType("int(11)")
                    .HasColumnName("trx_id");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<TblTrxMidtran>(entity =>
            {
                entity.ToTable("tbl_trx_midtrans");

                entity.HasIndex(e => e.CustomerId, "customer_id");

                entity.HasIndex(e => e.OrderId, "order_id");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.HasIndex(e => e.OwnerName, "owner_name");

                entity.HasIndex(e => e.TransactionId, "transaction_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasMaxLength(40)
                    .HasColumnName("amount")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.Fee)
                    .HasMaxLength(40)
                    .HasColumnName("fee")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FraudStatus)
                    .IsRequired()
                    .HasColumnType("enum('accept','deny','challenge')")
                    .HasColumnName("fraud_status");

                entity.Property(e => e.GrossAmount)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("gross_amount");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("member_id")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.MerchantId)
                    .HasMaxLength(16)
                    .HasColumnName("merchant_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("order_id");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");

                entity.Property(e => e.PaidAt)
                    .HasColumnName("paid_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PaymentChannel)
                    .HasColumnName("payment_channel")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PaymentCode)
                    .HasColumnName("payment_code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasColumnName("payment_type");

                entity.Property(e => e.PlanName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("plan_name");

                entity.Property(e => e.SettlementTime)
                    .HasColumnName("settlement_time")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SignatureKey)
                    .IsRequired()
                    .HasColumnName("signature_key");

                entity.Property(e => e.StatusCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("status_code");

                entity.Property(e => e.TransactionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("transaction_id");

                entity.Property(e => e.TransactionStatus)
                    .IsRequired()
                    .HasColumnType("enum('authorize','capture','settlement','deny','pending','cancel','refund','partial_refund','chargeback','partial_chargeback','expire','failure')")
                    .HasColumnName("transaction_status");

                entity.Property(e => e.TransactionTime).HasColumnName("transaction_time");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<TblTrxNicepay>(entity =>
            {
                entity.ToTable("tbl_trx_nicepay");

                entity.HasIndex(e => e.CustomerId, "customer_id");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.HasIndex(e => e.OwnerName, "owner_name");

                entity.HasIndex(e => e.Reference, "reference");

                entity.HasIndex(e => e.TrxId, "trx_id");

                entity.HasIndex(e => e.Username, "username");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("amount");

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.ExpiredOn)
                    .HasColumnName("expired_on")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Fee)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("fee");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");

                entity.Property(e => e.PaymentChannel)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("payment_channel");

                entity.Property(e => e.PaymentCode)
                    .HasColumnName("payment_code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("payment_type");

                entity.Property(e => e.PlanName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("plan_name");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("reference");

                entity.Property(e => e.StatusCode)
                    .IsRequired()
                    .HasColumnType("enum('0','1','2','3','4','5','9')")
                    .HasColumnName("status_code");

                entity.Property(e => e.Total)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("total");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("date")
                    .HasColumnName("transaction_date");

                entity.Property(e => e.TransactionStatus)
                    .IsRequired()
                    .HasColumnType("enum('success','failed','refund','reversal','paid','unpaid','expired','cancel','readytopaid')")
                    .HasColumnName("transaction_status");

                entity.Property(e => e.TransactionTime).HasColumnName("transaction_time");

                entity.Property(e => e.TrxId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("trx_id");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<TblTrxPaypal>(entity =>
            {
                entity.ToTable("tbl_trx_paypal");

                entity.HasIndex(e => e.CustomerId, "customer_id");

                entity.HasIndex(e => e.Email, "email");

                entity.HasIndex(e => e.Invoice, "invoice");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.HasIndex(e => e.OwnerName, "owner_name");

                entity.HasIndex(e => e.TrxId, "trx_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("amount");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("email");

                entity.Property(e => e.Fee)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("fee");

                entity.Property(e => e.Invoice)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("invoice");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");

                entity.Property(e => e.PlanName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("plan_name");

                entity.Property(e => e.Total)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("total");

                entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");

                entity.Property(e => e.TransactionStatus)
                    .IsRequired()
                    .HasColumnType("enum('completed','failed','refund','request')")
                    .HasColumnName("transaction_status");

                entity.Property(e => e.TrxId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("trx_id");

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TblTrxXendit>(entity =>
            {
                entity.ToTable("tbl_trx_xendit");

                entity.HasIndex(e => e.ExternalId, "external_id");

                entity.HasIndex(e => e.Invoice, "invoice");

                entity.HasIndex(e => e.MemberId, "member_id");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.HasIndex(e => e.OwnerName, "owner_name");

                entity.HasIndex(e => e.TrxId, "trx_id");

                entity.HasIndex(e => e.Username, "username");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Amount)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("amount");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ExpiredOn)
                    .HasColumnName("expired_on")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ExternalId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("external_id");

                entity.Property(e => e.Fee)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("fee");

                entity.Property(e => e.Invoice)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("invoice");

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("member_id");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");

                entity.Property(e => e.PaidAmount)
                    .HasMaxLength(40)
                    .HasColumnName("paid_amount")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PaidAt)
                    .HasColumnName("paid_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PaymentChannel)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("payment_channel");

                entity.Property(e => e.PaymentCode)
                    .HasColumnName("payment_code")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PlanName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("plan_name");

                entity.Property(e => e.Total)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("total");

                entity.Property(e => e.TransactionStatus)
                    .IsRequired()
                    .HasColumnType("enum('PENDING','PAID','EXPIRED','CANCEL','REFUND')")
                    .HasColumnName("transaction_status");

                entity.Property(e => e.TrxId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("trx_id");

                entity.Property(e => e.Updated).HasColumnName("updated");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<TblTrxXenditVa>(entity =>
            {
                entity.ToTable("tbl_trx_xendit_va");

                entity.HasIndex(e => e.CustomerId, "customer_id");

                entity.HasIndex(e => e.ExternalId, "external_id");

                entity.HasIndex(e => e.FvaId, "fva_id");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.HasIndex(e => e.OwnerName, "owner_name");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("customer_id");

                entity.Property(e => e.ExpectedAmount)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("expected_amount");

                entity.Property(e => e.ExpiredOn).HasColumnName("expired_on");

                entity.Property(e => e.ExternalId)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("external_id");

                entity.Property(e => e.FvaId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("fva_id");

                entity.Property(e => e.MerchantCode)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("merchant_code");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");

                entity.Property(e => e.PaymentChannel)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("payment_channel");

                entity.Property(e => e.PaymentCode)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("payment_code");

                entity.Property(e => e.SignatureKey)
                    .IsRequired()
                    .HasMaxLength(37)
                    .HasColumnName("signature_key");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('ACTIVE','INACTIVE')")
                    .HasColumnName("status");

                entity.Property(e => e.Updated).HasColumnName("updated");
            });

            modelBuilder.Entity<TblUsageReport>(entity =>
            {
                entity.ToTable("tbl_usage_reports");

                entity.HasIndex(e => e.ExpiredOn, "expired_on");

                entity.HasIndex(e => e.Method, "method");

                entity.HasIndex(e => e.RenewedOn, "renewed_on");

                entity.HasIndex(e => e.Type, "type");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.HasIndex(e => e.Username, "username");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ExpiredOn)
                    .HasColumnName("expired_on")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LastDevice)
                    .HasMaxLength(17)
                    .HasColumnName("last_device")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LastSessionId)
                    .HasMaxLength(64)
                    .HasColumnName("last_session_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LastUniqueId)
                    .HasMaxLength(32)
                    .HasColumnName("last_unique_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Method)
                    .IsRequired()
                    .HasColumnType("enum('VOUCHER','MEMBER')")
                    .HasColumnName("method");

                entity.Property(e => e.OnlineTime)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("online_time")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.QuotaUsed)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("quota_used")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.RenewedOn)
                    .HasColumnName("renewed_on")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("enum('HOTSPOT','PPP')")
                    .HasColumnName("type");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tbl_users");

                entity.HasIndex(e => e.IdentityNumber, "identity_number");

                entity.HasIndex(e => e.Invoice, "invoice");

                entity.HasIndex(e => e.TopupDate, "topup_date");

                entity.HasIndex(e => e.UserType, "user_type");

                entity.HasIndex(e => e.Username, "username");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Creationdate).HasColumnName("creationdate");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("fullname");

                entity.Property(e => e.Funds)
                    .HasColumnType("int(11)")
                    .HasColumnName("funds")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FundsStatus)
                    .HasColumnType("enum('active','pending')")
                    .HasColumnName("funds_status")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FundsType)
                    .HasColumnType("enum('cash','credit')")
                    .HasColumnName("funds_type")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IdentityNumber)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("identity_number")
                    .HasDefaultValueSql("'''d012T2EvUUtrSCtXQWlhb09QaE5oREkzVStoN1FSWW5MdEVmNWpZTTFIWT0='''");

                entity.Property(e => e.Invoice)
                    .HasMaxLength(64)
                    .HasColumnName("invoice")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LastLogin)
                    .HasColumnName("last_login")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Note)
                    .HasMaxLength(128)
                    .HasColumnName("note")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.PaymentStatus)
                    .HasColumnName("payment_status")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Permission)
                    .IsRequired()
                    .HasColumnName("permission");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(20)
                    .HasColumnName("phonenumber")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProfileImg)
                    .HasMaxLength(128)
                    .HasColumnName("profile_img")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TopupDate)
                    .HasColumnName("topup_date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TopupPayment)
                    .HasColumnType("enum('paid','unpaid')")
                    .HasColumnName("topup_payment")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TopupSystem)
                    .IsRequired()
                    .HasColumnType("enum('enabled','disabled')")
                    .HasColumnName("topup_system")
                    .HasDefaultValueSql("'''disabled'''");

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasColumnType("enum('Administrator','Manager','Operator')")
                    .HasColumnName("user_type");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<TblUsersfund>(entity =>
            {
                entity.ToTable("tbl_usersfunds");

                entity.HasIndex(e => e.AdminId, "admin_id");

                entity.HasIndex(e => e.AdminName, "admin_name");

                entity.HasIndex(e => e.Invoice, "invoice");

                entity.HasIndex(e => e.TopupDate, "topup_date");

                entity.HasIndex(e => e.TrxType, "trx_type");

                entity.HasIndex(e => e.Userid, "userid");

                entity.HasIndex(e => e.Username, "username");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ActiveDate)
                    .HasColumnName("active_date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.AdminId)
                    .HasColumnType("int(11)")
                    .HasColumnName("admin_id")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.AdminName)
                    .HasMaxLength(55)
                    .HasColumnName("admin_name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Credit)
                    .HasColumnType("int(11)")
                    .HasColumnName("credit");

                entity.Property(e => e.Debit)
                    .HasColumnType("int(11)")
                    .HasColumnName("debit");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .HasColumnName("email")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("fullname");

                entity.Property(e => e.FundsB)
                    .HasColumnType("int(11)")
                    .HasColumnName("funds_b");

                entity.Property(e => e.FundsN)
                    .HasColumnType("int(11)")
                    .HasColumnName("funds_n");

                entity.Property(e => e.FundsStatus)
                    .IsRequired()
                    .HasColumnType("enum('-','active','pending')")
                    .HasColumnName("funds_status");

                entity.Property(e => e.FundsType)
                    .IsRequired()
                    .HasColumnType("enum('-','cash','credit')")
                    .HasColumnName("funds_type")
                    .HasDefaultValueSql("'''cash'''");

                entity.Property(e => e.Invoice)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("invoice");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("payment_method")
                    .HasDefaultValueSql("'''manual'''");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(20)
                    .HasColumnName("phonenumber")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TopupDate)
                    .HasColumnName("topup_date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TopupPayment)
                    .IsRequired()
                    .HasColumnType("enum('-','paid','unpaid')")
                    .HasColumnName("topup_payment");

                entity.Property(e => e.TotalTopup)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("total_topup");

                entity.Property(e => e.TrxType)
                    .IsRequired()
                    .HasColumnType("enum('topup','debit','credit')")
                    .HasColumnName("trx_type")
                    .HasDefaultValueSql("'''topup'''");

                entity.Property(e => e.Userid)
                    .HasColumnType("int(11)")
                    .HasColumnName("userid");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<TblVoucher>(entity =>
            {
                entity.ToTable("tbl_vouchers");

                entity.HasIndex(e => e.Code, "code");

                entity.HasIndex(e => e.EvcEmail, "evc_email");

                entity.HasIndex(e => e.EvcOrderId, "evc_order_id");

                entity.HasIndex(e => e.EvcStatus, "evc_status");

                entity.HasIndex(e => e.ExpiredOn, "expired_on");

                entity.HasIndex(e => e.OwnerId, "owner_id");

                entity.HasIndex(e => e.OwnerName, "owner_name");

                entity.HasIndex(e => e.PlanName, "plan_name");

                entity.HasIndex(e => e.Status, "status");

                entity.HasIndex(e => e.TrxStatus, "trx_status");

                entity.HasIndex(e => e.Type, "type");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AuthStatus)
                    .IsRequired()
                    .HasColumnType("enum('Enabled-Users','Disabled-Users')")
                    .HasColumnName("auth_status")
                    .HasDefaultValueSql("'''Enabled-Users'''");

                entity.Property(e => e.Bandwidth)
                    .HasMaxLength(55)
                    .HasColumnName("bandwidth")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.BindMac)
                    .IsRequired()
                    .HasColumnType("enum('NO','YES')")
                    .HasColumnName("bind_mac")
                    .HasDefaultValueSql("'''NO'''");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("code");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date");

                entity.Property(e => e.EvcChannel)
                    .HasMaxLength(32)
                    .HasColumnName("evc_channel")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EvcEmail)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("evc_email")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.EvcFullname)
                    .HasMaxLength(64)
                    .HasColumnName("evc_fullname")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EvcOrderId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("evc_order_id")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.EvcPayment)
                    .HasMaxLength(32)
                    .HasColumnName("evc_payment")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.EvcStatus)
                    .HasColumnType("int(1)")
                    .HasColumnName("evc_status");

                entity.Property(e => e.EvcWanumber)
                    .HasMaxLength(64)
                    .HasColumnName("evc_wanumber")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ExpiredOn)
                    .HasColumnName("expired_on")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.MacAddress)
                    .HasMaxLength(17)
                    .HasColumnName("mac_address")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Method)
                    .IsRequired()
                    .HasColumnType("enum('VOUCHER')")
                    .HasColumnName("method");

                entity.Property(e => e.Nasporttype)
                    .HasMaxLength(20)
                    .HasColumnName("nasporttype")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("owner_name");

                entity.Property(e => e.PlanName)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("plan_name");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("price");

                entity.Property(e => e.Secret)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("secret");

                entity.Property(e => e.SellerFee)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("seller_fee");

                entity.Property(e => e.ServerName)
                    .HasMaxLength(128)
                    .HasColumnName("server_name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Servicetype)
                    .HasMaxLength(20)
                    .HasColumnName("servicetype")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("status");

                entity.Property(e => e.Tax)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("tax");

                entity.Property(e => e.Total)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("total");

                entity.Property(e => e.TrxInvoice)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("trx_invoice");

                entity.Property(e => e.TrxStatus)
                    .IsRequired()
                    .HasColumnType("enum('WAITING','FINISH')")
                    .HasColumnName("trx_status")
                    .HasDefaultValueSql("'''WAITING'''");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("enum('HOTSPOT','PPP')")
                    .HasColumnName("type");

                entity.Property(e => e.Validity)
                    .HasMaxLength(40)
                    .HasColumnName("validity")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<TblVouchersEvc>(entity =>
            {
                entity.ToTable("tbl_vouchers_evc");

                entity.HasIndex(e => e.Email, "email");

                entity.HasIndex(e => e.OrderId, "order_id");

                entity.HasIndex(e => e.OrderStatus, "order_status");

                entity.HasIndex(e => e.PgTrxId, "pg_trx_id");

                entity.HasIndex(e => e.PlanName, "plan_name");

                entity.HasIndex(e => e.StatusCode, "status_code");

                entity.HasIndex(e => e.Wanumber, "wanumber");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.BwName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("bw_name");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("email")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("fullname");

                entity.Property(e => e.HsDomain)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("hs_domain");

                entity.Property(e => e.MerchantName)
                    .HasMaxLength(64)
                    .HasColumnName("merchant_name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("order_id")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasColumnType("enum('paid','unpaid')")
                    .HasColumnName("order_status");

                entity.Property(e => e.PaidDate)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("paid_date")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.PaymentChannel)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("payment_channel");

                entity.Property(e => e.PaymentUrl)
                    .HasColumnName("payment_url")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PgTrxId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("pg_trx_id")
                    .HasDefaultValueSql("''''''");

                entity.Property(e => e.PlanName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("plan_name");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("price")
                    .HasDefaultValueSql("'''0'''");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(4)")
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.StatusCode)
                    .IsRequired()
                    .HasColumnType("enum('0','1')")
                    .HasColumnName("status_code");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("enum('HOTSPOT','PPP')")
                    .HasColumnName("type");

                entity.Property(e => e.Wanumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("wanumber");
            });

            modelBuilder.Entity<TblVouchersTpl>(entity =>
            {
                entity.ToTable("tbl_vouchers_tpl");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("file_name");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('Enable','Disable')")
                    .HasColumnName("status")
                    .HasDefaultValueSql("'''Enable'''");

                entity.Property(e => e.TemplateName)
                    .IsRequired()
                    .HasColumnName("template_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
