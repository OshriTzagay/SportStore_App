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
    public class ClothesController : ApiController
    {
        public static string connString = "Data Source=LAPTOP-P4F5KURV;Initial Catalog=SportStoreDB;Integrated Security=True;Pooling=False";
        public SportStoreDContextDataContext MyDataContext = new SportStoreDContextDataContext(connString);
        // GET: api/SportShoes
        public IHttpActionResult Get()

        {

            try
            {

                List<Clothe> ClothesList = MyDataContext.Clothes.ToList();
                return Ok(new { ClothesList });
            }
            catch (SqlException)
            {
                return BadRequest("Bad Sql Exception.");
            }
        }

        // GET: api/SportShoes/5
        public IHttpActionResult Get(int id)
        {
            try
            {

                Clothe chosenClothe = MyDataContext.Clothes.First(item => item.Id == id);
                if (chosenClothe.ClothType == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(new { chosenClothe });

                }
            }
            catch (SqlException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/SportShoes
        public IHttpActionResult Post([FromBody] Clothe AddedCloth)
        {
            try
            {

                MyDataContext.Clothes.InsertOnSubmit(AddedCloth);
                MyDataContext.SubmitChanges();

                return Ok("Added Clothes to the table Successfully");
            }
            catch (SqlException)
            {
                return BadRequest("SQL Exception");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/SportShoes/5
        public IHttpActionResult Put(int id, [FromBody] Clothe EditedClothe)
        {
            try
            {

                Clothe chosenClothe = MyDataContext.Clothes.First(item => item.Id == id);

                chosenClothe.Id = EditedClothe.Id;
                chosenClothe.ClothType = EditedClothe.ClothType;
                chosenClothe.Brand = EditedClothe.Brand;
                chosenClothe.isDrifit = EditedClothe.isDrifit;
                chosenClothe.Gender = EditedClothe.Gender;
                chosenClothe.isShort = EditedClothe.isShort;
                chosenClothe.Pic = EditedClothe.Pic;
                chosenClothe.Price = EditedClothe.Price;

                MyDataContext.SubmitChanges();

                return Ok(new { EditedThisOne = EditedClothe });
            }
            catch (SqlException)
            {
                return BadRequest();
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

                Clothe ChosenClothes = MyDataContext.Clothes.First(item => item.Id == id);
                MyDataContext.Clothes.DeleteOnSubmit(ChosenClothes);
                MyDataContext.SubmitChanges();

                return Ok(new { DeletedShoeIs = ChosenClothes });
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
