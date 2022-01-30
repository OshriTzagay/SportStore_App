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
    public class SportShoesController : ApiController
    {
        public static string connString = "Data Source=LAPTOP-P4F5KURV;Initial Catalog=SportStoreDB;Integrated Security=True;Pooling=False";
        public SportStoreDContextDataContext MyDataContext = new SportStoreDContextDataContext(connString);
        // GET: api/SportShoes
        public IHttpActionResult Get()

        {
            try
            {
                List<Shoe> shoeList = MyDataContext.Shoes.ToList();
                return Ok(new { shoeList });

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

        // GET: api/SportShoes/5
        public IHttpActionResult Get(int id)
        {
            try
            {

                Shoe chosenShoe = MyDataContext.Shoes.First(shoe => shoe.Id == id);
                if (chosenShoe.Company == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(new { chosenShoe });

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

        // POST: api/SportShoes
        public IHttpActionResult Post([FromBody] Shoe ShoeToAdd)
        {
            try
            {

                MyDataContext.Shoes.InsertOnSubmit(ShoeToAdd);
                MyDataContext.SubmitChanges();

                return Ok("Added Shoe Successfully");
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

        // PUT: api/SportShoes/5
        public IHttpActionResult Put(int id, [FromBody] Shoe EditedShoe)
        {
            try
            {

                Shoe chosenShoe = MyDataContext.Shoes.First(shoe => shoe.Id == id);
                chosenShoe.Id = EditedShoe.Id;
                chosenShoe.Brand = EditedShoe.Brand;
                chosenShoe.IsSale = EditedShoe.IsSale;
                chosenShoe.Price = EditedShoe.Price;
                chosenShoe.Quantity = EditedShoe.Quantity;
                chosenShoe.Company = EditedShoe.Company;
                chosenShoe.Pic = EditedShoe.Pic;

                MyDataContext.SubmitChanges();

                return Ok(new { EditedThisShoe = EditedShoe });
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

        // DELETE: api/SportShoes/5
        public IHttpActionResult Delete(int id)
        {
            try
            {

                Shoe chosenShoe = MyDataContext.Shoes.First(shoe => shoe.Id == id);
                MyDataContext.Shoes.DeleteOnSubmit(chosenShoe);
                MyDataContext.SubmitChanges();

                return Ok(new { DeletedShoeIs = chosenShoe });
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
