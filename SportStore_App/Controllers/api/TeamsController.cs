using SportStore_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportStore_App.Controllers.api
{
    public class TeamsController : ApiController
    {
        public static string connString = "Data Source=LAPTOP-P4F5KURV;Initial Catalog=SportStoreDB;Integrated Security=True;Pooling=False";
        public SportStoreDContextDataContext MyDataContext = new SportStoreDContextDataContext(connString);
        // GET: api/Teams//
        public IHttpActionResult Get()

        {
            try
            {
                List<Team> TeamList = MyDataContext.Teams.ToList();
                return Ok(new { TeamList });

            }
            catch (SqlException)
            {
                return BadRequest("Sql Exception.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Teams/5
        public IHttpActionResult Get(int id)
        {
            try
            {

                Team ChosenTeam = MyDataContext.Teams.First(shoe => shoe.Id == id);
                if (ChosenTeam.TeamName == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(new { ChosenTeam });

                }
            }
            catch (SqlException)
            {
                return BadRequest("Sql Exception.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Teams
        public IHttpActionResult Post([FromBody] Team TeamToAdd)
        {
            try
            {

                MyDataContext.Teams.InsertOnSubmit(TeamToAdd);
                MyDataContext.SubmitChanges();

                return Ok("Added Team Successfully");
            }
            catch (SqlException)
            {
                return BadRequest("Sql Exception");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Teams/5
        public IHttpActionResult Put(int id, [FromBody] Team TeamToEdit)
        {
            try
            {

                Team ChosenTeam = MyDataContext.Teams.First(team => team.Id == id);
                ChosenTeam.Id = TeamToEdit.Id;
                ChosenTeam.TeamName = TeamToEdit.TeamName;


                MyDataContext.SubmitChanges();

                return Ok("Edited Successfully");
            }
            catch (SqlException)
            {
                return BadRequest("Sql Exception.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/Teams/5
        public IHttpActionResult Delete(int id)
        {
            try
            {

                Team TheChosenTeam = MyDataContext.Teams.First(team => team.Id == id);
                MyDataContext.Teams.DeleteOnSubmit(TheChosenTeam);
                MyDataContext.SubmitChanges();

                return Ok(new { DeletedShoeIs = TheChosenTeam });
            }

            catch (SqlException)
            {
                return BadRequest("SQL Exception.");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
