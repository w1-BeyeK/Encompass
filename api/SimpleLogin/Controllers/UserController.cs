using Microsoft.AspNetCore.Mvc;
using API.Models.Exceptions;
using API.Models.Results;
using API.Services;
using System;
using System.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class UserController: Controller
    {
        // Servicelayer
        IUserService _service;

        // Constructor
        public UserController()
        {
            _service = new UserService();
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            try
            {
               return Ok(_service.Get());
            }
            catch (SqlException se)
            {
                return BadRequest(se.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Login endpoint
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Login([FromBody] FilterDTO filters)
        {
            try
            {
                return Ok(_service.Login(filters));
            }
            catch(SqlException se)
            {
                return BadRequest(se.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Update([FromBody] FilterDTO filters)
        {
            try
            {
                return Ok(_service.Update(filters));
            }
            catch (SqlException se)
            {
                return BadRequest(se.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/cards")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Cards([FromRoute] int id)
        {
            try
            {
                return Ok(_service.GetCards(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("{userId}/cards/{cardId}/update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateCard([FromBody] FilterDTO filters, [FromRoute] int userId, [FromRoute] int cardId)
        {
            try
            {
                return Ok(_service.UpdateCard(filters, cardId, userId));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("{id}/cards/delete")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult DeleteCard([FromBody] FilterDTO filters)
        {
            try
            {
                return Ok(_service.DeleteCard(filters));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
