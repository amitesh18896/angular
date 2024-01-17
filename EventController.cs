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
