using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using INTRAC.Api.Repository;
using INTRAC.Api.Repository.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace INTRAC.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {


        private readonly eventmoduleDbContext _dbContext;
        private readonly string connectionString = "Data Source=DESKTOP-6SEBQ8S\\SQLEXPRESS;Initial Catalog=INTRAC88;Integrated Security=True;TrustServerCertificate=True;";
        public EventController(eventmoduleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetAllEvents")]
        public ActionResult<List<Eventmodule>> GetAllEvents()
        {
            var events = _dbContext.Eventmodules.Take(600).ToList();
            return Ok(events);
        }





       
    



    [HttpGet("getNextId")]
        public ActionResult<int> GetNextId()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT NEXT VALUE FOR BAS_IDGEN_SEQ", connection))
                    {
                        int nextId = Convert.ToInt32(command.ExecuteScalar());
                        return Ok(nextId);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }



        [HttpGet("GetEventtypeTitles")]
        public ActionResult<IEnumerable<string>> GetEventtypeTitles()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT Title FROM eventtype WHERE Company_RID = 128075", connection))
                    {
                        List<string> titles = new List<string>();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string title = reader["Title"].ToString();
                                titles.Add(title);
                            }
                        }

                        return Ok(titles);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }




        [HttpGet("worksitetype")]
        public ActionResult<IEnumerable<string>> worksitetype()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT Name FROM worksitetype where Company_RID=128075", connection))
                    {
                        List<string> Names = new List<string>();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string Name = reader["Name"].ToString();
                                Names.Add(Name);
                            }
                        }

                        return Ok(Names);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }






        [HttpGet("organization")]
        public ActionResult<IEnumerable<string>> organization()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("select Name from organization where Company_RID=128075", connection))
                    {
                        List<string> Names = new List<string>();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string Name = reader["Name"].ToString();
                                Names.Add(Name);
                            }
                        }

                        return Ok(Names);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }










        [HttpGet("timezone")]
        public ActionResult<IEnumerable<string>> timezone()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("select Name from timezone where Company_RID=128075", connection))
                    {
                        List<string> Names = new List<string>();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string Name = reader["Name"].ToString();
                                Names.Add(Name);
                            }
                        }

                        return Ok(Names);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }











        [HttpGet("reportinggroup")]
        public ActionResult<IEnumerable<string>> reportinggroup()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("select Name from reportinggroup where Company_RID=128075", connection))
                    {
                        List<string> Names = new List<string>();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string Name = reader["Name"].ToString();
                                Names.Add(Name);
                            }
                        }

                        return Ok(Names);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }






        [HttpGet("region")]
        public ActionResult<IEnumerable<string>> region()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("select Name from region where Company_RID=128075", connection))
                    {
                        List<string> Names = new List<string>();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string Name = reader["Name"].ToString();
                                Names.Add(Name);
                            }
                        }

                        return Ok(Names);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }
        //[HttpPost("CreateEventss")]
        //public ActionResult<Eventmodule> CreateEventss([FromBody] Eventmodule eventItem)
        //{
        //    if (eventItem == null)
        //    {
        //        return BadRequest("Event data is null");
        //    }

        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            // Default table name
        //            string tableName = "eventtype";

        //            // Determine the table based on the CompanyRid
        //            switch (eventItem.CompanyRid.ToString()) // Convert to lowercase for case-insensitivity
        //            {
        //                case "eventtype1":
        //                    tableName = "eventtype";
        //                    break;
        //                case "eventtype2":
        //                    tableName = "worksitetype";
        //                    break;
        //                // Add more cases for other CompanyRid values and corresponding table names
        //                default:
        //                    return BadRequest("Invalid CompanyRid");
        //            }

        //            // Construct the SQL query with placeholders for columns and values
        //            string sqlQuery = $"INSERT INTO {tableName} (CompanyRid, Title, ...) VALUES (@CompanyRid, @Title, ...)";

        //            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
        //            {
        //                // Set parameters based on your actual model and database columns
        //                command.Parameters.AddWithValue("@CompanyRid", eventItem.CompanyRid);
        //                command.Parameters.AddWithValue("@Title", eventItem.CompanyRid); // Replace with the actual property
        //                                                                            // Add more parameters as needed

        //                command.ExecuteNonQuery();
        //            }

        //            return CreatedAtAction("GetEventById", new { id = eventItem.Id }, eventItem);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return StatusCode(500, "Internal Server Error");
        //    }
        //}


        //[HttpPost("InsertDataAndRetrieve")]
        //public ActionResult<Eventmodule> InsertDataAndRetrieve(Eventmodule eventItem)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();


        //            using (SqlCommand insertEventTypeCommand = new SqlCommand("INSERT INTO EventType (Company_RID, ClientName) VALUES (128075, @ClientName)", connection))
        //            {
        //                insertEventTypeCommand.Parameters.AddWithValue("@ClientName", eventItem.ClientName);
        //                insertEventTypeCommand.ExecuteNonQuery();
        //            }


        //            using (SqlCommand insertWorksiteTypeCommand = new SqlCommand("INSERT INTO WorksiteType (Company_RID, Comment) VALUES (128075, @Comment)", connection))
        //            {
        //                insertWorksiteTypeCommand.Parameters.AddWithValue("@Comment", eventItem.Comment);
        //                insertWorksiteTypeCommand.ExecuteNonQuery();
        //            }




        //            using (SqlCommand retrieveEventTypeCommand = new SqlCommand("SELECT Title FROM EventType WHERE Company_RID = 128075", connection))
        //            {
        //                List<string> eventTypeTitles = new List<string>();

        //                using (SqlDataReader reader = retrieveEventTypeCommand.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        string title = reader["Title"].ToString();
        //                        eventTypeTitles.Add(title);
        //                    }
        //                }

        //                return Ok(eventTypeTitles);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return StatusCode(500, "Internal Server Error");
        //    }
        //}
















        [HttpGet("{id}", Name = "GetEventById")]
        public ActionResult<Eventmodule> GetEventById(int id)
        {
            var eventItem = _dbContext.Eventmodules.Find(id);

            if (eventItem == null)
            {
                return NotFound();
            }

            return Ok(eventItem);
        }

        //[HttpPost(Name = "CreateEvent")]
        //public ActionResult<Eventmodule> CreateEvent(Eventmodule eventItem)
        //{
        //    _dbContext.Eventmodules.Add(eventItem);
        //    _dbContext.SaveChanges();

        //    return CreatedAtAction("GetEventById", new { id = eventItem.Id }, eventItem);
        //}










//        USE[INTRAC88]
//GO
///****** Object:  StoredProcedure [dbo].[InsertEventData]    Script Date: 1/17/2024 8:36:15 AM ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//ALTER PROCEDURE[dbo].[InsertEventData]
//        AS
//BEGIN
//    BEGIN TRANSACTION;

//        DECLARE @Company_RID INT;
//    SET @Company_RID = 128075;

//        DECLARE @BASVERSION INT; 
//    SET @BASVERSION = 0;

//        DECLARE @ScoreCard NVARCHAR(255);
//        SET @ScoreCard = '';

//        DECLARE @BASTIMESTAMP DATETIME; 
//    SET @BASTIMESTAMP = ''; -- Assuming this is the correct format, adjust if needed

//    DECLARE @Description NVARCHAR(255);
//        SET @Description = '';

//        DECLARE @Name NVARCHAR(255); 
//    SET @Name = '';

//        DECLARE @Company_REN INT;
//    SET @Company_REN = 0;

//        DECLARE @Company_RMA NVARCHAR(255);
//        SET @Company_RMA = '';

//        DECLARE @Status NVARCHAR(255);
//        SET @Status = '';

//        DECLARE @Goals NVARCHAR(255);
//        SET @Goals = '';

//        DECLARE @WTID INT; 
//    SET @WTID = 0;

//        DECLARE @OrgID INT; 
//    SET @OrgID = 0;



//        DECLARE @RepGrpID INT; 
//    SET @RepGrpID = 0;

//        DECLARE @TZID INT;
//    SET @TZID = 0;

//        DECLARE @Organization_REN INT; 
//    SET @Organization_REN = 0;

//        DECLARE @Organization_RID INT;
//    SET @Organization_RID = 0;

//        DECLARE @Organization_RMA INT;
//    SET @Organization_RMA = 0;

//        DECLARE @Title NVARCHAR(255);
//        SET @Title = '';

//        DECLARE @LeadingOrLagging NVARCHAR(255);
//        SET @LeadingOrLagging = '';

//        DECLARE @EventTypeClass_REN NVARCHAR(255);
//        SET @EventTypeClass_REN = '';

//        DECLARE @EventTypeClass_RID INT;
//    SET @EventTypeClass_RID = 0;

//        DECLARE @EventTypeClass_RMA INT;
//    SET @EventTypeClass_RMA = 0;

//        DECLARE @RestrictEventAccess NVARCHAR(255);
//        SET @RestrictEventAccess = '';

//        DECLARE @InjuryRestricted NVARCHAR(255);
//        SET @InjuryRestricted = '';

//        DECLARE @HRRestricted NVARCHAR(255);
//        SET @HRRestricted = '';

//        DECLARE @SecurityRestricted NVARCHAR(255);
//        SET @SecurityRestricted = '';

//        DECLARE @OrderNumber INT;
//    SET @OrderNumber = 0;

//        DECLARE @HRHealthRestricted NVARCHAR(255);
//        SET @HRHealthRestricted = '';

//        DECLARE @OperationsRestricted NVARCHAR(255);
//        SET @OperationsRestricted = '';

//        DECLARE @ETID INT;
//    SET @ETID = 0;

//        DECLARE @CreatedByAPI NVARCHAR(255);
//        SET @CreatedByAPI = '';

//    -- Use variables to store the result of NEXT VALUE FOR
//   DECLARE @eventtypeID INT;
//    SET @eventtypeID = NEXT VALUE FOR BAS_IDGEN_SEQ;

//    DECLARE @WorksiteTypeID INT;
//    SET @WorksiteTypeID = NEXT VALUE FOR BAS_IDGEN_SEQ;

//    DECLARE @OrganizationID INT;
//    SET @OrganizationID = NEXT VALUE FOR BAS_IDGEN_SEQ;

//    DECLARE @ReportingGroupID INT;
//    SET @ReportingGroupID = NEXT VALUE FOR BAS_IDGEN_SEQ;

//    DECLARE @TimezoneID INT;
//    SET @TimezoneID = NEXT VALUE FOR BAS_IDGEN_SEQ;

//    DECLARE @RegionID INT;
//    SET @RegionID = NEXT VALUE FOR BAS_IDGEN_SEQ; -- Ensure unique ID

//    INSERT INTO[INTRAC88].[dbo].[eventtype]
//        (ID, BASVERSION, BASTIMESTAMP, ScoreCard, Description, Company_REN, Company_RID, Company_RMA, Goals, Title, Status, LeadingOrLagging, EventTypeClass_REN, EventTypeClass_RID, EventTypeClass_RMA, RestrictEventAccess, InjuryRestricted, HRRestricted, SecurityRestricted, OrderNumber, HRHealthRestricted, OperationsRestricted, ETID, CreatedByAPI)
//    VALUES(@eventtypeID, @BASVERSION, @BASTIMESTAMP, @ScoreCard, @Description, @Company_REN, @Company_RID, @Company_RMA, @Goals, @Title, @Status, @LeadingOrLagging, @EventTypeClass_REN, @EventTypeClass_RID, @EventTypeClass_RMA, @RestrictEventAccess, @InjuryRestricted, @HRRestricted, @SecurityRestricted, @OrderNumber, @HRHealthRestricted, @OperationsRestricted, @ETID, @CreatedByAPI);

//        INSERT INTO[INTRAC88].[dbo].[worksitetype]
//        (ID, BASVERSION, BASTIMESTAMP, Name, Status, Company_REN, Company_RID, Company_RMA, WTID)
//        VALUES(@WorksiteTypeID, @BASVERSION, @BASTIMESTAMP, @Name, @Status, @Company_REN, @Company_RID, @Company_RMA, @WTID);

//        INSERT INTO[INTRAC88].[dbo].[organization]
//        (ID, BASVERSION, BASTIMESTAMP, Company_REN, Company_RID, Company_RMA, Name, Status, OrgID)
//        VALUES(@OrganizationID, @BASVERSION, @BASTIMESTAMP, @Company_REN, @Company_RID, @Company_RMA, @Name, @Status, @OrgID);

//        INSERT INTO[INTRAC88].[dbo].[region]
//        (ID, BASVERSION, BASTIMESTAMP, Company_REN, Company_RID, Company_RMA, Name, Status, Organization_REN, Organization_RID, Organization_RMA, RegionID)
//        VALUES(@RegionID, @BASVERSION, @BASTIMESTAMP, @Company_REN, @Company_RID, @Company_RMA, @Name, @Status, @Organization_REN, @Organization_RID, @Organization_RMA, @RegionID);

//        INSERT INTO[INTRAC88].[dbo].[reportinggroup]
//        (ID, BASVERSION, BASTIMESTAMP, Name, Status, Company_REN, Company_RID, Company_RMA, RepGrpID)
//        VALUES(@ReportingGroupID, @BASVERSION, @BASTIMESTAMP, @Name, @Status, @Company_REN, @Company_RID, @Company_RMA, @RepGrpID);

//        INSERT INTO[INTRAC88].[dbo].[timezone]
//        (ID, BASVERSION, BASTIMESTAMP, Name, Status, Company_REN, Company_RID, Company_RMA, TZID)
//        VALUES(@TimezoneID, @BASVERSION, @BASTIMESTAMP, @Name, @Status, @Company_REN, @Company_RID, @Company_RMA, @TZID);

//        COMMIT;
//END;












        [HttpPost(Name = "CreateEvent")]
        public ActionResult<Eventmodule> CreateEvent(Eventmodule eventItem)
        {
            try
            {
                _dbContext.Eventmodules.Add(eventItem);

                
                _dbContext.SaveChanges();

                
                _dbContext.Database.ExecuteSqlRaw("EXEC InsertEventData");

              
                _dbContext.Entry(eventItem).Reload();

                return CreatedAtAction("GetEventById", new { id = eventItem.Id }, eventItem);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }






        //public ActionResult<Eventmodule> CreateEventsss(Eventmodule eventItem)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        Eventtype comuny_rid = new Eventtype { };
        //        Table2 table2Item = new Table2 { };
        //        Table3 table3Item = new Table3 { };
        //        Table4 table4Item = new Table4 { };
        //        Table5 table5Item = new Table5 { };


        //        eventItem.Table1 = table1Item;
        //        eventItem.Table2 = table2Item;
        //        eventItem.Table3 = table3Item;
        //        eventItem.Table4 = table4Item;
        //        eventItem.Table5 = table5Item;


        //        _dbContext.Eventmodules.Add(eventItem);
        //        _dbContext.Table1.Add(table1Item);
        //        _dbContext.Table2.Add(table2Item);
        //        _dbContext.Table3.Add(table3Item);
        //        _dbContext.Table4.Add(table4Item);
        //        _dbContext.Table5.Add(table5Item);


        //        _dbContext.SaveChanges();

        //        return CreatedAtAction("GetEventById", new { id = eventItem.Id }, eventItem);
        //    }

        //}




        [HttpPut("{id}", Name = "UpdateEvent")]
        public IActionResult UpdateEvent(int id, Eventmodule updatedEvent)
        {
            if (id != updatedEvent.Id)
            {
                return BadRequest("Invalid ID");
            }

            _dbContext.Entry(updatedEvent).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEvent")]
        public ActionResult<Eventmodule> DeleteEvent(int id)
        {
            var eventItem = _dbContext.Eventmodules.Find(id);

            if (eventItem == null)
            {
                return NotFound();
            }

            _dbContext.Eventmodules.Remove(eventItem);
            _dbContext.SaveChanges();

            return Ok(eventItem);
        }
    }
}
