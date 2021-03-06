using AdminAPIServices.Authentication;
using AdminAPIServices.Models;
using AdminAPIServices.Entities;
using AdminAPIServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminAPIServices.Controllers
{
    
    [Authorize]
    [Route("api/v1.0/flight")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public readonly IAdminService _adminSrvice;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public AdminController(IAdminService adminService, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this._adminSrvice = adminService;
            this._jwtAuthenticationManager = jwtAuthenticationManager;
        }
        [HttpGet]
        public string Hello()
        {
            return "Hello from Admin API Service";
        }
        [AllowAnonymous]
        [HttpGet("Authenticate")]
        public IActionResult GetAuthentication(string username, string password)
        {
            var token = _jwtAuthenticationManager.Authenticate(username, password);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }
        }




        [HttpGet("getallairlines")]
        //[Route("getallairlines")]
        public ActionResult GetAllAirlines()
        {
            try
            {
                return Ok(_adminSrvice.GetAllAirlines());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getairline/{id}")]
       
        public ActionResult GetAirline(Guid id)
        {
            try
            {
                return Ok(_adminSrvice.GetAirline(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("airline/register")]
        
        public ActionResult SaveAirline(AirlineModel airlineModel)
        {
            try
            {
                return Ok(_adminSrvice.SaveAirline(airlineModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("airline/inventory/add")]
      
        public ActionResult ScheduleFlight(FlightModel flightModel)
        {
            try
            {
                return Ok(_adminSrvice.ScheduleFlight(flightModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getflight/{id}")]
      
        public ActionResult GetFlight(Guid id)
        {
            try
            {
                return Ok(_adminSrvice.GetFlight(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        [AllowAnonymous]
        [HttpPost("admin/login")]
        public ActionResult UserLogin(LoginModel loginModel)
        {
            try
            {
                var token = _jwtAuthenticationManager.Authenticate(loginModel.Email, loginModel.Password);
                if (token == null)
                {
                    return Unauthorized();
                }
                else
                {
                    loginModel.Token = token;
                }

                UserRegistrestion userRegistrestion = _adminSrvice.UserLogIn(loginModel);
                if (userRegistrestion != null)
                {
                    loginModel.Role = userRegistrestion.Role;
                }
                return Ok(loginModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost("usersignup")]
       
        public ActionResult UserSignUp(UserRegistrestionModel userRegistrestionModel)
        {
            try
            {
                return Ok(_adminSrvice.UserSignUp(userRegistrestionModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getallflights")]
        
        public ActionResult GetAllFlights()
        {
            try
            {
                return Ok(_adminSrvice.GetAllFlights());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getairlinelu")]
       
        public ActionResult GetAirlineLookup()
        {
            try
            {
                return Ok(_adminSrvice.GetAirlineLu());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getdiscount/{id}")]
       
        public ActionResult GetDiscount(Guid id)
        {
            try
            {
                return Ok(_adminSrvice.GetDiscount(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("getdiscounts")]
       
        public ActionResult GetDiscounts()
        {
            try
            {
                return Ok(_adminSrvice.GetDiscounts());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("savediscount")]
      
        public ActionResult SaveDiscount(DiscountModel discountModel)
        {
            try
            {
                return Ok(_adminSrvice.SaveDiscount(discountModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("activeincctiveadmin/{tableName}/{id}/{status}")]
        public ActionResult ActiveInActive(string tableName, Guid id, string status)
        {
            try
            {
                return Ok(_adminSrvice.ActiveInActive(tableName, id, status));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
