using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiReport.Context;
using Microsoft.EntityFrameworkCore;
using WebApiReport.Controllers.Customer;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using MySqlX.XDevAPI.Common;
using Microsoft.Extensions.Configuration;

namespace WebApiReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UIdeskController : ControllerBase
    {
        private readonly DbContextLinked _context;
        private readonly string _connectionString;

        public UIdeskController(DbContextLinked context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("SqlServerConnection");  // Adjust the connection string name
        }

        [HttpGet]
        [Route("GetDataTaskBoard")]


        public async Task<IEnumerable<TicketData>> GetDataTaskBoard(string CustomerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var command = new SqlCommand("GetTicketData", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Add parameters
                 command.Parameters.Add(new SqlParameter("@CustomerId", SqlDbType.NVarChar) { Value = CustomerId });

                // Execute the reader
                var reader = await command.ExecuteReaderAsync();

                var ticketDataList = new List<TicketData>();
                var ListData = new List<ListData>();
              
                while (await reader.ReadAsync())
                {
                    ListData.Add(new ListData
                    {
                        NumberRow = reader["NumberRow"].ToString(),
                        Status = reader["Status"].ToString(),
                        TicketPosition = reader["TicketPosition"].ToString(),
                        TicketNumber = reader["TicketNumber"].ToString(),
                        NamePIC = reader["NamePIC"].ToString(),
                        DetailComplaint = reader["DetailComplaint"].ToString(),
                        NamaPelapor = reader["NAMA_PELAPOR"].ToString(),
                        PhonePelapor = reader["PHONE_PELAPOR"].ToString(),
                        SLA = reader["SLA"].ToString(),
                        UsedDaySLAOK = reader["UsedDaySLAOK"].ToString(),
                        UnitKerja = reader["UnitKerja"].ToString(),
                        KeteranganWrittenVerbal = reader["KeteranganWrittenVerbal"].ToString(),
                        CategoryName = reader["CategoryName"].ToString(),
                        SubCategory1Name = reader["SubCategory1Name"].ToString(),
                        SubCategory2Name = reader["SubCategory2Name"].ToString(),
                        SubCategory3Name = reader["SubCategory3Name"].ToString(),
                        DateCreate = reader["datecreate"] as DateTime?,
                        LastResponseDate = reader["LastResponseDate"] as DateTime?,
                        ParentNumberID = reader["ParentNumberID"].ToString()
                    });
                }


                var statusCounts = new List<TicketData>
                    {
                        new TicketData { Status = "Semua", Total = ListData.Count(),ListDatas=ListData.ToList() },
                        new TicketData {  Status = "Prosess", Total = ListData.Where(x => x.Status != "Closed").Count(),ListDatas=ListData.Where(x => x.Status != "Closed").ToList() },
                        new TicketData { Status = "Selesai",Total = ListData.Where(x => x.Status == "Closed").Count(),ListDatas=ListData.Where(x => x.Status == "Closed").ToList() },

                    };


                return statusCounts;
            }
        }


        [HttpGet]
        [Route("GetTicketAll")]


        public async Task<ActionResult<IEnumerable<tTicket>>> GetAllCustomers(string TicketNumber)
        {

            return await _context.tTickets.Where(x => x.TicketNumber == TicketNumber).ToListAsync();

        }

        [HttpGet]
        [Route("GetTicketByCustomerId")]


        public async Task<ActionResult<IEnumerable<tTicket>>> GetTicketByCustomerId(string CustomerId)
        {

            return await _context.tTickets.Where(a => a.NIK == CustomerId).ToListAsync();

        }

        [HttpGet]
        [Route("GetStatusTicketByCustomerId")]


        public async Task<ActionResult<IEnumerable<StatusCountResult>>> GetStatusTicketByCustomerId(string CustomerId)
        {

            var statusCounts = new List<StatusCountResult>
                    {
                        new StatusCountResult { Status = "Open", Jumlah = _context.tTickets.Where(a => a.Status == "Open" && a.NIK == CustomerId).Count() },
                        new StatusCountResult { Status = "Closed", Jumlah = _context.tTickets.Where(a => a.Status == "Closed" && a.NIK == CustomerId).Count() },
                        new StatusCountResult { Status = "Pending", Jumlah = _context.tTickets.Where(a => a.Status == "Pending" && a.NIK == CustomerId).Count() },
                        new StatusCountResult { Status = "In progress", Jumlah = _context.tTickets.Where(a => a.Status == "In progress" && a.NIK == CustomerId).Count() },

                    };


            return statusCounts.ToList();

        }

        [HttpGet]
        [Route("GetTop3DataTicket")]
        public async Task<ActionResult<IEnumerable<tTicket>>> GetTop3Data(string CustomerId)
        {
            // Define the query to get the top 3 records
            var top3SubCategories = await _context.tTickets
                .OrderByDescending(s => s.DateCreate)
                .Where(x => x.NIK == CustomerId && x.Status != "Closed")
                .Take(3)
                .ToListAsync();

            return Ok(top3SubCategories);
        }


        [HttpPost]
        [Route("LoginTeknisi")]
        public async Task<ActionResult<IEnumerable<tTicket>>> LoginTeknisi([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                return StatusCode(400, "Invalid request");
            }

            // Retrieve the customer based on username
            var Teknisi = await _context.MsUsers
                .SingleOrDefaultAsync(x => x.LevelUser == "Layer 3" && x.Username == request.UserName && x.Password == x.Password);


            if (Teknisi == null)
            {

                // Return a BadRequest response with a message
                return StatusCode(400, new { Message = "Teknisi not found." });
            }


            return StatusCode(201, Teknisi);





        }
        [HttpGet]
        [Route("DetailPekerjaan")]
        public async Task<ActionResult<IEnumerable<tTicket>>> DetailPekerjaan(string Start, string End)
        {
            if (string.IsNullOrEmpty(Start) || string.IsNullOrEmpty(End))
            {
                return StatusCode(400, "Invalid request");
            }

            if (!DateTime.TryParse(Start, out DateTime startDate) || !DateTime.TryParse(End, out DateTime endDate))
            {
                return StatusCode(400, "Invalid date format");

            }

            endDate = DateTime.Parse(End).AddDays(1).AddTicks(-1);
            // Retrieve the customer based on username
            var Status = await _context.tTickets.Where(x => x.DateCreate >= DateTime.Parse(Start) && x.DateCreate <= endDate).Select(x => x.Status).ToListAsync();

            var ListData = await _context.tTickets.Where(x => x.DateCreate >= DateTime.Parse(Start) && x.DateCreate <= endDate).ToListAsync();


            if (Status == null)
            {

                // Return a BadRequest response with a message
                return StatusCode(400, new { Message = "Teknisi not found." });
            }
            var result = new Dictionary<string, object>();

            foreach (var sts in Status)
            {
                var ticketsByStatus = ListData
               .Where(x => x.Status == sts)
               .ToList();



                result[sts] = new
                {
                    Status = sts,
                    Total = ticketsByStatus.Count,
                    detailData = ticketsByStatus
                };
            }



            return StatusCode(201, result);





        }

        [HttpGet]
        [Route("GetTicketByTicketNumber")]
        public async Task<ActionResult<IEnumerable<tTicket>>> GetTicketByTicketNumber(string TicketNumber)
        {
            if (string.IsNullOrEmpty(TicketNumber))
            {
                return StatusCode(400, "Invalid request");
            }





            var result = await _context.tTickets.Where(x => x.TicketNumber == TicketNumber).ToListAsync();



            if (result == null)
            {

                // Return a BadRequest response with a message
                return StatusCode(400, new { Message = "Data not found." });
            }



            return StatusCode(201, result);





        }
        [HttpPost]
        [Route("EskalasiTeknisi")]
        public async Task<ActionResult<IEnumerable<tTicket>>> EskalasiTeknisi([FromBody] RequestData request)
        {
            if (string.IsNullOrEmpty(request.TicketNumber) || string.IsNullOrEmpty(request.agentResponse))
            {
                return StatusCode(400, "Invalid request");
            }





            var result = await _context.tTickets.Where(x => x.TicketNumber == request.TicketNumber).FirstOrDefaultAsync();



            if (result == null)
            {

                // Return a BadRequest response with a message
                return StatusCode(400, new { Message = "Data not found." });
            }

            result.Status = request.Status;
            result.TicketPosition = request.TicketPOsition;
            result.ResponComplaint = request.agentResponse;

            // Save changes to the database
            _context.tTickets.Update(result);
            await _context.SaveChangesAsync();



            return Ok(new
            {
                Status = "Success",
                Message = "Ticket updated successfully.",
                Data = result
            });





        }


        public class StatusCountResult
        {
            public int Jumlah { get; set; }
            public string Status { get; set; }
        }
        public class RequestData
        {
            public string TicketNumber { get; set; }
            public string Status { get; set; }
            public string agentResponse { get; set; }
            public string TicketPOsition { get; set; }
        }

        public class TicketData
        {
            public string Status { get; set; }
            public int Total { get; set; }
            public List<ListData> ListDatas { get; set; }


        }
        public class ListData
        {
            public string NumberRow { get; set; }
            public string Status { get; set; }
            public string TicketPosition { get; set; }
            public string TicketNumber { get; set; }
            public string NamePIC { get; set; }
            public string DetailComplaint { get; set; }
            public string NamaPelapor { get; set; }
            public string PhonePelapor { get; set; }
            public string SLA { get; set; }
            public string UsedDaySLAOK { get; set; }
            public string UnitKerja { get; set; }
            public string KeteranganWrittenVerbal { get; set; }
            public string CategoryName { get; set; }
            public string SubCategory1Name { get; set; }
            public string SubCategory2Name { get; set; }
            public string SubCategory3Name { get; set; }
            public DateTime? DateCreate { get; set; }
            public DateTime? LastResponseDate { get; set; }
            public string ParentNumberID { get; set; }
        }




    }
}
