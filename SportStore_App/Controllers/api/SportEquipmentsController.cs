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
    public class SportEquipmentsController : ApiController
    {
        // GET: api/SportEquipments
        public static string connString = "Data Source=LAPTOP-P4F5KURV;Initial Catalog=SportStoreDB;Integrated Security=True;Pooling=False";
        public SportStoreDContextDataContext MyDataContext = new SportStoreDContextDataContext(connString);
        // GET: api/SportEquipments
        public IHttpActionResult Get()

        {
            try
            {
                List<SportEquipment> equipmentList = MyDataContext.SportEquipments.ToList();
                return Ok(new { equipmentList });

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

        // GET: api/SportEquipments/5
        public IHttpActionResult Get(int id)
        {
            try
            {

                SportEquipment chosenEquipment = MyDataContext.SportEquipments.First(equip => equip.Id == id);
                if (chosenEquipment.Company == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(new { chosenEquipment });

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

        // POST: api/SportEquipments
        public IHttpActionResult Post([FromBody] SportEquipment EquipToAdd)
        {
            try
            {

                MyDataContext.SportEquipments.InsertOnSubmit(EquipToAdd);
                MyDataContext.SubmitChanges();

                return Ok("Added Equipment Successfully");
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

        // PUT: api/SportEquipments/5
        public IHttpActionResult Put(int id, [FromBody] SportEquipment EditedEquipment)
        {
            try
            {

                SportEquipment chosenItem = MyDataContext.SportEquipments.First(equip => equip.Id == id);
                chosenItem.Id = EditedEquipment.Id;
                chosenItem.Company = EditedEquipment.Company;
                chosenItem.WhatSport = EditedEquipment.WhatSport;
                chosenItem.ProductName = EditedEquipment.ProductName;
                chosenItem.Price = EditedEquipment.Price;
                chosenItem.Quantity = EditedEquipment.Quantity;
                chosenItem.TeamId = EditedEquipment.TeamId;
                chosenItem.Pic = EditedEquipment.Pic;


                MyDataContext.SubmitChanges();

                return Ok(new { EditedThisShoe = EditedEquipment });
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

        // DELETE: api/SportEquipments/5
        public IHttpActionResult Delete(int id)
        {
            try
            {

                SportEquipment ChosenItem = MyDataContext.SportEquipments.First(equip => equip.Id == id);
                MyDataContext.SportEquipments.DeleteOnSubmit(ChosenItem);
                MyDataContext.SubmitChanges();

                return Ok(new { DeletedShoeIs = ChosenItem });
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
