using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using WebApiReport.Controllers.Customer;
using WebApiReport.ModelCibaliungDanMalingping;
using WebApiReport.ModelPanembong;
using WebApiReport.Models;

namespace WebApiReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblCustomersController : ControllerBase
    {
        private readonly mixradius_radDBContext _context;
        private readonly PenembongDBContext _contextPanembong;
        private readonly CibaliungDBContext _contextCibaliung;

        public TblCustomersController(mixradius_radDBContext context, PenembongDBContext contextPanembong, CibaliungDBContext contextCibaliung)
        {
            _context = context;
            _contextPanembong = contextPanembong;
            _contextCibaliung = contextCibaliung;
        }
        // GET: api/TblCustomers
        [HttpGet]
        [Route("GetAllCustomers")]


        public async Task<ActionResult<IEnumerable<CustomerResponse>>> GetAllCustomers()
        {
            
            var result = await (from a in _context.TblCustomers
                                join b in _context.TblCustomersMaps
                                on a.Id equals b.CustomerId into customerMapGroup
                                from b in customerMapGroup.DefaultIfEmpty()
                                select new CustomerResponse
                                {

                                   // SELECT a.id, a.member_id, a.type, a.servicetype, a.username, a.password, a.fullname, a.email, a.phonenumber, a.address, a.plan_name, a.renewed_on, a.expired_on, a.trx_invoice, a.trx_status, a.payment_type,b.latitude, b.longitude FROM tbl_customers a LEFT JOIN tbl_customers_map b ON b.customer_id = a.id

                                    Id = a.Id,
                                    MemberId = a.MemberId,
                                    Type = a.Type,
                                    Servicetype = a.Servicetype,
                                    Username = a.Username,
                                    Password = a.Password,
                                    Fullname = a.Fullname,
                                    Email = a.Email,
                                    Phonenumber = a.Phonenumber,
                                    Address = a.Address,
                                    PlanName = a.PlanName,
                                    //RenewedOn = a.RenewedOn,
                                    //ExpiredOn = a.ExpiredOn,
                                    TrxInvoice = a.TrxInvoice,
                                    TrxStatus = a.TrxStatus,
                                    PaymentType = a.PaymentType,
                                    Latitude =  b.Latitude ,
                                    Longitude = b.Longitude 
                                }).Take(1000).ToListAsync();

            if (result == null)
            {
                return StatusCode(404, NotFound());
            }
            return StatusCode(201,result);
            //return await _context.TblCustomers.ToListAsync();
        }

        [HttpGet]
        [Route("GetCustomersByFilter")]


        public async Task<ActionResult<IEnumerable<CustomerResponse>>> GetCustomersByFilter(string SearchData)
        {

            try
            {
                var dbContext1Result = await (from a in _context.TblCustomers
                                              join b in _context.TblCustomersMaps
                                              on a.Id equals b.CustomerId into customerMapGroup
                                              from b in customerMapGroup.DefaultIfEmpty()
                                              where a.Email.ToLower() == SearchData.ToLower()
                                                 || a.Phonenumber.ToLower() == SearchData.ToLower()
                                                 || a.Fullname.ToLower() == SearchData.ToLower()
                                              select new CustomerResponse
                                              {
                                                  Id = a.Id,
                                                  Site = "Pandeglang",
                                                  MemberId = a.MemberId,
                                                  Type = a.Type,
                                                  Servicetype = a.Servicetype,
                                                  Username = a.Username,
                                                  Password = a.Password,
                                                  Fullname = a.Fullname,
                                                  Email = a.Email,
                                                  Phonenumber = a.Phonenumber,
                                                  Address = a.Address,
                                                  PlanName = a.PlanName,
                                                  TrxInvoice = a.TrxInvoice,
                                                  TrxStatus = a.TrxStatus,
                                                  PaymentType = a.PaymentType,
                                                  Latitude = b.Latitude,
                                                  Longitude = b.Longitude
                                              }).ToListAsync();

                var dbContext2Result = await (from a in _contextPanembong.TblCustomers
                                              join b in _contextPanembong.TblCustomersMaps
                                              on a.Id equals b.CustomerId into customerMapGroup
                                              from b in customerMapGroup.DefaultIfEmpty()
                                              where a.Email.ToLower() == SearchData.ToLower()
                                                 || a.Phonenumber.ToLower() == SearchData.ToLower()
                                                 || a.Fullname.ToLower() == SearchData.ToLower()
                                              select new CustomerResponse
                                              {
                                                  Id = a.Id,
                                                  Site = "Panimbangan",
                                                  MemberId = a.MemberId,
                                                  Type = a.Type,
                                                  Servicetype = a.Servicetype,
                                                  Username = a.Username,
                                                  Password = a.Password,
                                                  Fullname = a.Fullname,
                                                  Email = a.Email,
                                                  Phonenumber = a.Phonenumber,
                                                  Address = a.Address,
                                                  PlanName = a.PlanName,
                                                  TrxInvoice = a.TrxInvoice,
                                                  TrxStatus = a.TrxStatus,
                                                  PaymentType = a.PaymentType,
                                                  Latitude = b.Latitude,
                                                  Longitude = b.Longitude
                                              }).ToListAsync();

                var dbContext3Result = await (from a in _contextCibaliung.TblCustomers
                                              join b in _contextCibaliung.TblCustomersMaps
                                              on a.Id equals b.CustomerId into customerMapGroup
                                              from b in customerMapGroup.DefaultIfEmpty()
                                              where a.Email.ToLower() == SearchData.ToLower()
                                                 || a.Phonenumber.ToLower() == SearchData.ToLower()
                                                 || a.Fullname.ToLower() == SearchData.ToLower()
                                              select new CustomerResponse
                                              {
                                                  Id = a.Id,
                                                  Site = "CiBaliung",
                                                  MemberId = a.MemberId,
                                                  Type = a.Type,
                                                  Servicetype = a.Servicetype,
                                                  Username = a.Username,
                                                  Password = a.Password,
                                                  Fullname = a.Fullname,
                                                  Email = a.Email,
                                                  Phonenumber = a.Phonenumber,
                                                  Address = a.Address,
                                                  PlanName = a.PlanName,
                                                  TrxInvoice = a.TrxInvoice,
                                                  TrxStatus = a.TrxStatus,
                                                  PaymentType = a.PaymentType,
                                                  Latitude = b.Latitude,
                                                  Longitude = b.Longitude
                                              }).ToListAsync();

                // Repeat for dbContext3 and dbContext4

                // Combine the results using Union (Union eliminates duplicates)
                var allResults = dbContext1Result
                    .Union(dbContext2Result)
                    .Union(dbContext3Result)
                    //.Union(dbContext4Result)
                    .Take(1000) // Limit the results to 1000
                    .ToList();

                // Return the results
                if (allResults == null || !allResults.Any())
                {
                    return StatusCode(404, NotFound());
                }
                return StatusCode(201, allResults);
            }
            catch (Exception ex)
            {
              
                return StatusCode(500, ex.ToString());
            }


        }
        [HttpGet]
        [Route("GetAllCustomersSearchByDataKey")]


        public async Task<ActionResult<IEnumerable<CustomerResponse>>> GetAllCustomersbyAccount(string SearchData)
        {

            //var result = await (from a in _context.TblCustomers
            //                    join b in _context.TblCustomersMaps
            //                    on a.Id equals b.CustomerId into customerMapGroup
            //                    from b in customerMapGroup.DefaultIfEmpty()
            //                    where a.Email.ToLower().Contains(SearchData) || a.Phonenumber.ToLower().Contains(SearchData)
            //                     || a.Username.ToLower().Contains(SearchData) || a.Type.ToLower().Contains(SearchData)


            //                    select new CustomerResponse
            //                    {

            //                       // SELECT a.id, a.member_id, a.type, a.servicetype, a.username, a.password, a.fullname, a.email, a.phonenumber, a.address, a.plan_name, a.renewed_on, a.expired_on, a.trx_invoice, a.trx_status, a.payment_type,b.latitude, b.longitude FROM tbl_customers a LEFT JOIN tbl_customers_map b ON b.customer_id = a.id

            //                        Id = a.Id,
            //                        MemberId = a.MemberId,
            //                        Type = a.Type,
            //                        Servicetype = a.Servicetype,
            //                        Username = a.Username,
            //                        Password = a.Password,
            //                        Fullname = a.Fullname,
            //                        Email = a.Email,
            //                        Phonenumber = a.Phonenumber,
            //                        Address = a.Address,
            //                        PlanName = a.PlanName,
            //                        //RenewedOn = a.RenewedOn,
            //                        //ExpiredOn = a.ExpiredOn,
            //                        TrxInvoice = a.TrxInvoice,
            //                        TrxStatus = a.TrxStatus,
            //                        PaymentType = a.PaymentType,
            //                        Latitude =  b.Latitude ,
            //                        Longitude = b.Longitude 
            //                    }).Take(1000).ToListAsync();

            //if (result == null)
            //{
            //    return StatusCode(404, NotFound());
            //}
            //return StatusCode(201,result);
            ////return await _context.TblCustomers.ToListAsync();
            ///
            try
            {
                var dbContext1Result = await (from a in _context.TblCustomers
                                              join b in _context.TblCustomersMaps
                                              on a.Id equals b.CustomerId into customerMapGroup
                                              from b in customerMapGroup.DefaultIfEmpty()
                                              where a.Email.ToLower().Contains(SearchData) || a.Phonenumber.ToLower().Contains(SearchData)
                                                                   || a.Username.ToLower().Contains(SearchData) || a.Type.ToLower().Contains(SearchData)
                                              select new CustomerResponse
                                              {
                                                  Id = a.Id,
                                                  Site = "Pandeglang",
                                                  MemberId = a.MemberId,
                                                  Type = a.Type,
                                                  Servicetype = a.Servicetype,
                                                  Username = a.Username,
                                                  Password = a.Password,
                                                  Fullname = a.Fullname,
                                                  Email = a.Email,
                                                  Phonenumber = a.Phonenumber,
                                                  Address = a.Address,
                                                  PlanName = a.PlanName,
                                                  TrxInvoice = a.TrxInvoice,
                                                  TrxStatus = a.TrxStatus,
                                                  PaymentType = a.PaymentType,
                                                  Latitude = b.Latitude,
                                                  Longitude = b.Longitude
                                              }).ToListAsync();

                var dbContext2Result = await (from a in _contextPanembong.TblCustomers
                                              join b in _contextPanembong.TblCustomersMaps
                                              on a.Id equals b.CustomerId into customerMapGroup
                                              from b in customerMapGroup.DefaultIfEmpty()
                                              where a.Email.ToLower().Contains(SearchData) || a.Phonenumber.ToLower().Contains(SearchData)
                                                                 || a.Username.ToLower().Contains(SearchData) || a.Type.ToLower().Contains(SearchData)
                                              select new CustomerResponse
                                              {
                                                  Id = a.Id,
                                                  Site = "Panimbangan",
                                                  MemberId = a.MemberId,
                                                  Type = a.Type,
                                                  Servicetype = a.Servicetype,
                                                  Username = a.Username,
                                                  Password = a.Password,
                                                  Fullname = a.Fullname,
                                                  Email = a.Email,
                                                  Phonenumber = a.Phonenumber,
                                                  Address = a.Address,
                                                  PlanName = a.PlanName,
                                                  TrxInvoice = a.TrxInvoice,
                                                  TrxStatus = a.TrxStatus,
                                                  PaymentType = a.PaymentType,
                                                  Latitude = b.Latitude,
                                                  Longitude = b.Longitude
                                              }).ToListAsync();

                var dbContext3Result = await (from a in _contextCibaliung.TblCustomers
                                              join b in _contextCibaliung.TblCustomersMaps
                                              on a.Id equals b.CustomerId into customerMapGroup
                                              from b in customerMapGroup.DefaultIfEmpty()
                                              where a.Email.ToLower().Contains(SearchData) || a.Phonenumber.ToLower().Contains(SearchData)
                                                                 || a.Username.ToLower().Contains(SearchData) || a.Type.ToLower().Contains(SearchData)
                                              select new CustomerResponse
                                              {
                                                  Id = a.Id,
                                                  Site = "CiBaliung",
                                                  MemberId = a.MemberId,
                                                  Type = a.Type,
                                                  Servicetype = a.Servicetype,
                                                  Username = a.Username,
                                                  Password = a.Password,
                                                  Fullname = a.Fullname,
                                                  Email = a.Email,
                                                  Phonenumber = a.Phonenumber,
                                                  Address = a.Address,
                                                  PlanName = a.PlanName,
                                                  TrxInvoice = a.TrxInvoice,
                                                  TrxStatus = a.TrxStatus,
                                                  PaymentType = a.PaymentType,
                                                  Latitude = b.Latitude,
                                                  Longitude = b.Longitude
                                              }).ToListAsync();

                // Repeat for dbContext3 and dbContext4

                // Combine the results using Union (Union eliminates duplicates)
                var allResults = dbContext1Result
                    .Union(dbContext2Result)
                    .Union(dbContext3Result)
                    //.Union(dbContext4Result)
                    .Take(1000) // Limit the results to 1000
                    .ToList();

                // Return the results
                if (allResults == null || !allResults.Any())
                {
                    return StatusCode(404, NotFound());
                }
                return StatusCode(201, allResults);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.ToString());
            }

        }
        [HttpGet]
        [Route("GetAllCustomersbyUserName")]


        public async Task<ActionResult<IEnumerable<CustomerResponse>>> GetAllCustomersbyUserName(string username)
        {
            if ( string.IsNullOrEmpty(username) )
            {
                return StatusCode(404, "User Name not empty.");
            }
            //var result = await (from a in _context.TblCustomers
            //                    join b in _context.TblCustomersMaps
            //                    on a.Id equals b.CustomerId into customerMapGroup
            //                    from b in customerMapGroup.DefaultIfEmpty()
            //                    where a.Username == username
            //                    select new CustomerResponse
            //                    {

            //                       // SELECT a.id, a.member_id, a.type, a.servicetype, a.username, a.password, a.fullname, a.email, a.phonenumber, a.address, a.plan_name, a.renewed_on, a.expired_on, a.trx_invoice, a.trx_status, a.payment_type,b.latitude, b.longitude FROM tbl_customers a LEFT JOIN tbl_customers_map b ON b.customer_id = a.id

            //                        Id = a.Id,
            //                        MemberId = a.MemberId,
            //                        Type = a.Type,
            //                        Servicetype = a.Servicetype,
            //                        Username = a.Username,
            //                        Password = a.Password,
            //                        Fullname = a.Fullname,
            //                        Email = a.Email,
            //                        Phonenumber = a.Phonenumber,
            //                        Address = a.Address,
            //                        PlanName = a.PlanName,
            //                        //RenewedOn = a.RenewedOn,
            //                        //ExpiredOn = a.ExpiredOn,
            //                        TrxInvoice = a.TrxInvoice,
            //                        TrxStatus = a.TrxStatus,
            //                        PaymentType = a.PaymentType,
            //                        Latitude =  b.Latitude ,
            //                        Longitude = b.Longitude 
            //                    }).Take(1000).ToListAsync();

            //if (result == null)
            //{
            //    return StatusCode(404, NotFound());
            //}
            //return StatusCode(201,result);
            //return await _context.TblCustomers.ToListAsync();
            try
            {
                var dbContext1Result = await (from a in _context.TblCustomers
                                              join b in _context.TblCustomersMaps
                                              on a.Id equals b.CustomerId into customerMapGroup
                                              from b in customerMapGroup.DefaultIfEmpty()
                                              where a.Username == username
                                              select new CustomerResponse
                                              {
                                                  Id = a.Id,
                                                  Site = "Pandeglang",
                                                  MemberId = a.MemberId,
                                                  Type = a.Type,
                                                  Servicetype = a.Servicetype,
                                                  Username = a.Username,
                                                  Password = a.Password,
                                                  Fullname = a.Fullname,
                                                  Email = a.Email,
                                                  Phonenumber = a.Phonenumber,
                                                  Address = a.Address,
                                                  PlanName = a.PlanName,
                                                  TrxInvoice = a.TrxInvoice,
                                                  TrxStatus = a.TrxStatus,
                                                  PaymentType = a.PaymentType,
                                                  Latitude = b.Latitude,
                                                  Longitude = b.Longitude
                                              }).ToListAsync();

                var dbContext2Result = await (from a in _contextPanembong.TblCustomers
                                              join b in _contextPanembong.TblCustomersMaps
                                              on a.Id equals b.CustomerId into customerMapGroup
                                              from b in customerMapGroup.DefaultIfEmpty()
                                              where a.Username == username
                                              select new CustomerResponse
                                              {
                                                  Id = a.Id,
                                                  Site = "Panimbangan",
                                                  MemberId = a.MemberId,
                                                  Type = a.Type,
                                                  Servicetype = a.Servicetype,
                                                  Username = a.Username,
                                                  Password = a.Password,
                                                  Fullname = a.Fullname,
                                                  Email = a.Email,
                                                  Phonenumber = a.Phonenumber,
                                                  Address = a.Address,
                                                  PlanName = a.PlanName,
                                                  TrxInvoice = a.TrxInvoice,
                                                  TrxStatus = a.TrxStatus,
                                                  PaymentType = a.PaymentType,
                                                  Latitude = b.Latitude,
                                                  Longitude = b.Longitude
                                              }).ToListAsync();

                var dbContext3Result = await (from a in _contextCibaliung.TblCustomers
                                              join b in _contextCibaliung.TblCustomersMaps
                                              on a.Id equals b.CustomerId into customerMapGroup
                                              from b in customerMapGroup.DefaultIfEmpty()
                                              where a.Username == username
                                              select new CustomerResponse
                                              {
                                                  Id = a.Id,
                                                  Site = "CiBaliung",
                                                  MemberId = a.MemberId,
                                                  Type = a.Type,
                                                  Servicetype = a.Servicetype,
                                                  Username = a.Username,
                                                  Password = a.Password,
                                                  Fullname = a.Fullname,
                                                  Email = a.Email,
                                                  Phonenumber = a.Phonenumber,
                                                  Address = a.Address,
                                                  PlanName = a.PlanName,
                                                  TrxInvoice = a.TrxInvoice,
                                                  TrxStatus = a.TrxStatus,
                                                  PaymentType = a.PaymentType,
                                                  Latitude = b.Latitude,
                                                  Longitude = b.Longitude
                                              }).ToListAsync();

                // Repeat for dbContext3 and dbContext4

                // Combine the results using Union (Union eliminates duplicates)
                var allResults = dbContext1Result
                    .Union(dbContext2Result)
                    .Union(dbContext3Result)
                    //.Union(dbContext4Result)
                    .Take(1000) // Limit the results to 1000
                    .ToList();

                // Return the results
                if (allResults == null || !allResults.Any())
                {
                    return StatusCode(404, NotFound());
                }
                return StatusCode(201, allResults);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.ToString());
            }
        }
        [HttpPost]
        [Route("LoginCust")]


        public async Task<ActionResult<TblCustomerResponse>> LoginCust([FromBody] LoginRequest request)
        {

            if (request == null || string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                return StatusCode(400,"Invalid request");
            }

            //// Retrieve the customer based on username
            //var customer = await _context.TblCustomers
            //    .SingleOrDefaultAsync(x => x.Username == request.UserName);


            //if (customer == null)
            //{

            //    // Return a BadRequest response with a message
            //    return StatusCode(400,new { Message = "Customer not found." });
            //}


            //return StatusCode(201,customer);
            try
            {
                // Query from the first DbContext
                var context1Result = await _context.TblCustomers
                    .Where(x => x.Username == request.UserName)
                    .Select(x => new TblCustomerResponse
                    {
                        Id = x.Id,
                        Site = "Pandeglang",
                        Secret = x.Secret,
                        MemberId = x.MemberId,
                        Type = x.Type,
                        Servicetype = x.Servicetype,
                        Nasporttype = x.Nasporttype,
                        ServerName = x.ServerName,
                        Method = x.Method,
                        Username = x.Username,
                        Password = x.Password,
                        Fullname = x.Fullname,
                        Email = x.Email,
                        IdentityNumber = x.IdentityNumber,
                        Phonenumber = x.Phonenumber,
                        Address = x.Address,
                        CreatedAt = x.CreatedAt,
                        PlanName = x.PlanName,
                        Price = x.Price,
                        SellerFee = x.SellerFee,
                        SetupFee = x.SetupFee,
                        DeviceFee = x.DeviceFee,
                        Tax = x.Tax,
                        Total = x.Total,
                        RenewedOn = x.RenewedOn,
                        ExpiredOn = x.ExpiredOn,
                        LastLogin = x.LastLogin,
                        LocalAddress = x.LocalAddress,
                        RemoteAddress = x.RemoteAddress,
                        Note = x.Note,
                        SmsAlert = x.SmsAlert,
                        EmailAlert = x.EmailAlert,
                        WaAlert = x.WaAlert,
                        TrxInvoice = x.TrxInvoice,
                        InvoiceDate = x.InvoiceDate,
                        TrxStatus = x.TrxStatus,
                        PaymentType = x.PaymentType,
                        PaymentStatus = x.PaymentStatus,
                        AuthStatus = x.AuthStatus,
                        InputStatus = x.InputStatus,
                        BindMac = x.BindMac,
                        MacAddress = x.MacAddress,
                        OwnerId = x.OwnerId,
                        OwnerName = x.OwnerName,
                    })
                    .ToListAsync();

                // Query from the second DbContext
                var context2Result = await _contextPanembong.TblCustomers
                    .Where(x => x.Username == request.UserName)
                    .Select(x => new TblCustomerResponse
                    {

                        Id = x.Id,
                        Site = "Panimbangan",
                        Secret = x.Secret,
                        MemberId = x.MemberId,
                        Type = x.Type,
                        Servicetype = x.Servicetype,
                        Nasporttype = x.Nasporttype,
                        ServerName = x.ServerName,
                        Method = x.Method,
                        Username = x.Username,
                        Password = x.Password,
                        Fullname = x.Fullname,
                        Email = x.Email,                      
                        IdentityNumber = x.IdentityNumber,
                        Phonenumber = x.Phonenumber,
                        Address = x.Address,
                        CreatedAt = x.CreatedAt,
                        PlanName = x.PlanName,
                        Price = x.Price,
                        SellerFee = x.SellerFee,
                        SetupFee = x.SetupFee,
                        DeviceFee = x.DeviceFee,
                        Tax = x.Tax,
                        Total = x.Total,
                        RenewedOn = x.RenewedOn,
                        ExpiredOn = x.ExpiredOn,
                        LastLogin = x.LastLogin,
                        LocalAddress = x.LocalAddress,
                        RemoteAddress = x.RemoteAddress,
                        Note = x.Note,
                        SmsAlert = x.SmsAlert,
                        EmailAlert = x.EmailAlert,
                        WaAlert = x.WaAlert,
                        TrxInvoice = x.TrxInvoice,
                        InvoiceDate = x.InvoiceDate,
                        TrxStatus = x.TrxStatus,
                        PaymentType = x.PaymentType,
                        PaymentStatus = x.PaymentStatus,
                        AuthStatus = x.AuthStatus,
                        InputStatus = x.InputStatus,
                        BindMac = x.BindMac,
                        MacAddress=x.MacAddress,
                        OwnerId=x.OwnerId,
                        OwnerName = x.OwnerName,
                        
                    })
                    .ToListAsync();

                // Query from the third DbContext
                var context3Result = await _contextCibaliung.TblCustomers
                    .Where(x => x.Username == request.UserName)
                    .Select(x => new TblCustomerResponse
                    {
                        Id = x.Id,
                        Site = "Cibaliung",
                        Secret = x.Secret,
                        MemberId = x.MemberId,
                        Type = x.Type,
                        Servicetype = x.Servicetype,
                        Nasporttype = x.Nasporttype,
                        ServerName = x.ServerName,
                        Method = x.Method,
                        Username = x.Username,
                        Password = x.Password,
                        Fullname = x.Fullname,
                        Email = x.Email,
                        IdentityNumber = x.IdentityNumber,
                        Phonenumber = x.Phonenumber,
                        Address = x.Address,
                        CreatedAt = x.CreatedAt,
                        PlanName = x.PlanName,
                        Price = x.Price,
                        SellerFee = x.SellerFee,
                        SetupFee = x.SetupFee,
                        DeviceFee = x.DeviceFee,
                        Tax = x.Tax,
                        Total = x.Total,
                        RenewedOn = x.RenewedOn,
                        ExpiredOn = x.ExpiredOn,
                        LastLogin = x.LastLogin,
                        LocalAddress = x.LocalAddress,
                        RemoteAddress = x.RemoteAddress,
                        Note = x.Note,
                        SmsAlert = x.SmsAlert,
                        EmailAlert = x.EmailAlert,
                        WaAlert = x.WaAlert,
                        TrxInvoice = x.TrxInvoice,
                        InvoiceDate = x.InvoiceDate,
                        TrxStatus = x.TrxStatus,
                        PaymentType = x.PaymentType,
                        PaymentStatus = x.PaymentStatus,
                        AuthStatus = x.AuthStatus,
                        InputStatus = x.InputStatus,
                        BindMac = x.BindMac,
                        MacAddress = x.MacAddress,
                        OwnerId = x.OwnerId,
                        OwnerName = x.OwnerName,
                    })
                    .ToListAsync();

                // Combine the results using Union (ignoring duplicates)
                var combinedResults = context1Result
                    .Union(context2Result)
                    .Union(context3Result)
                    .FirstOrDefault(); // Get the first match, or null if no match

                if (combinedResults == null)
                {
                    return StatusCode(404, "Customer not found in any context.");
                }

                return StatusCode(201, combinedResults); // Returning OK with the result
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, ex.ToString());
            }



            //return await _context.TblCustomers.ToListAsync();
        }

        [HttpGet("type/{type}")]
        public async Task<ActionResult<IEnumerable<CustomerResponse>>> GetAllCustomersByType(string type)
        {

            if ( string.IsNullOrEmpty(type))
            {
                return StatusCode(404, " type not empty.");
            }

            try
            {
                // Query from the first DbContext
                var context1Result = await (from a in _context.TblCustomers
                                            join b in _context.TblCustomersMaps
                                            on a.Id equals b.CustomerId into customerMapGroup
                                            from b in customerMapGroup.DefaultIfEmpty()
                                            where a.Type == type
                                            select new CustomerResponse
                                            {
                                                Id = a.Id,
                                                Site = "Pandeglang",
                                                MemberId = a.MemberId,
                                                Type = a.Type,
                                                Servicetype = a.Servicetype,
                                                Username = a.Username,
                                                Password = a.Password,
                                                Fullname = a.Fullname,
                                                Email = a.Email,
                                                Phonenumber = a.Phonenumber,
                                                Address = a.Address,
                                                PlanName = a.PlanName,
                                                RenewedOn = a.RenewedOn,
                                                ExpiredOn = a.ExpiredOn,
                                                TrxInvoice = a.TrxInvoice,
                                                TrxStatus = a.TrxStatus,
                                                PaymentType = a.PaymentType,
                                                Latitude = b.Latitude,
                                                Longitude = b.Longitude
                                            }).ToListAsync();

                // Query from the second DbContext
                var context2Result = await (from a in _contextPanembong.TblCustomers
                                            join b in _contextPanembong.TblCustomersMaps
                                            on a.Id equals b.CustomerId into customerMapGroup
                                            from b in customerMapGroup.DefaultIfEmpty()
                                            where a.Type == type
                                            select new CustomerResponse
                                            {
                                                Id = a.Id,
                                                Site ="Panimbangan",
                                                MemberId = a.MemberId,
                                                Type = a.Type,
                                                Servicetype = a.Servicetype,
                                                Username = a.Username,
                                                Password = a.Password,
                                                Fullname = a.Fullname,
                                                Email = a.Email,
                                                Phonenumber = a.Phonenumber,
                                                Address = a.Address,
                                                PlanName = a.PlanName,
                                                RenewedOn = a.RenewedOn,
                                                ExpiredOn = a.ExpiredOn,
                                                TrxInvoice = a.TrxInvoice,
                                                TrxStatus = a.TrxStatus,
                                                PaymentType = a.PaymentType,
                                                Latitude = b.Latitude,
                                                Longitude = b.Longitude
                                            }).ToListAsync();

                // Query from the third DbContext
                var context3Result = await (from a in _contextCibaliung.TblCustomers
                                            join b in _contextCibaliung.TblCustomersMaps
                                            on a.Id equals b.CustomerId into customerMapGroup
                                            from b in customerMapGroup.DefaultIfEmpty()
                                            where a.Type == type
                                            select new CustomerResponse
                                            {
                                                Id = a.Id,
                                                Site = "Cibaliung",
                                                MemberId = a.MemberId,
                                                Type = a.Type,
                                                Servicetype = a.Servicetype,
                                                Username = a.Username,
                                                Password = a.Password,
                                                Fullname = a.Fullname,
                                                Email = a.Email,
                                                Phonenumber = a.Phonenumber,
                                                Address = a.Address,
                                                PlanName = a.PlanName,
                                                RenewedOn = a.RenewedOn,
                                                ExpiredOn = a.ExpiredOn,
                                                TrxInvoice = a.TrxInvoice,
                                                TrxStatus = a.TrxStatus,
                                                PaymentType = a.PaymentType,
                                                Latitude = b.Latitude,
                                                Longitude = b.Longitude
                                            }).ToListAsync();

                // Combine the results using Union (ignoring duplicates)
                var combinedResults = context1Result
                    .Union(context2Result) // Combining both query results from context1 and context2
                    .Union(context3Result) // Adding the results from context3
                    .ToList(); // Convert to list to perform further operations if needed

                if (combinedResults == null || !combinedResults.Any())
                {
                    return StatusCode(404, "No customers found matching the type.");
                }

                return StatusCode(200, combinedResults); // Return the combined results
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }

        }

        // GET: api/TblCustomers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.TblCustomer>> GetTblCustomer(int id)
        {
            var tblCustomer = await _context.TblCustomers.FindAsync(id);

            if (tblCustomer == null)
            {
                return NotFound();
            }

            return tblCustomer;
        }

        // PUT: api/TblCustomers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCustomer(int id, Models.TblCustomer tblCustomer)
        {
            if (id != tblCustomer.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TblCustomers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.TblCustomer>> PostTblCustomer(Models.TblCustomer tblCustomer)
        {
            _context.TblCustomers.Add(tblCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCustomer", new { id = tblCustomer.Id }, tblCustomer);
        }

        // DELETE: api/TblCustomers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCustomer(int id)
        {
            var tblCustomer = await _context.TblCustomers.FindAsync(id);
            if (tblCustomer == null)
            {
                return NotFound();
            }

            _context.TblCustomers.Remove(tblCustomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblCustomerExists(int id)
        {
            return _context.TblCustomers.Any(e => e.Id == id);
        }
    }

    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
