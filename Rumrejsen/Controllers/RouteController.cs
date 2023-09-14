using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rumrejsen.Helpers;
using Rumrejsen.Models;
using Rumrejsen.Services;

namespace Rumrejsen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        TokenService _tokenService;
        DBHelper _dbHelper;
        
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] User user)
        {
            //Gets the name, password and role from the database based on the user input from the client.
            User currentUser = await _dbHelper.GetUser(user.Name);

            //If the user found users name and password matches the user input generate a new JWT token then save said token on the user in the DB and then return it ot the client.
            if (user.Name == currentUser.Name && user.Password == currentUser.Password)
            {
                var token = _tokenService.GenerateJwtToken(currentUser);
                await _dbHelper.SaveToken(user.Name, token);
                return Ok(new { Token = token });
            }
            //If the user input doesn't match the one from the DB return unauthorized.
            return Unauthorized();
        }

        [HttpGet("GetRoutes")]
        //Only authorize JWT tokens with a role set to Cadet or Captain.
        [Authorize(Roles ="Captain, Cadet")]
        public async Task<ActionResult> GetRoutes()
        {
            //Get the data from the header of the request which carries the JWT token data.
            HttpContext.Request.Headers.TryGetValue("Authorization", out var headerAuth);
            //Remove unneccesary parts of the string from the JWT token.
            string jwtToken = headerAuth.First().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];

            SpaceRoute spaceRoute = new SpaceRoute();
            List<SpaceRoute> spaceRoutes = new List<SpaceRoute>();
            //Get the role of a user from the DB based on the JWT token string.
            User user = await _dbHelper.GetRole(jwtToken);
            //Get the id of the user from the DB based on the JWT token string.
            int id = await _dbHelper.GetId(jwtToken);

            if (user.Role == "Captain")
            {
                //Adds the routes to be returned to the user based on the Captain role.
                spaceRoutes = spaceRoute.GetCaptainRoutes();
                //Add the request time + id to the DB.
                await _dbHelper.StoreRequest(id);
            }
            else if (user.Role == "Cadet")
            {
                //Get a list of all requests made by the Cadet from the DB.
                List<DateTime> dateTimes = await _dbHelper.GetRequests(id);
                //Create a seperate list and then only add the ones from the previous list that are less than 30 minutes old.
                List<DateTime> filteredTimesList = new List<DateTime>();
                foreach (DateTime date in dateTimes)
                {
                    if (date > DateTime.Now.AddMinutes(-30))
                    {
                        filteredTimesList.Add(date);
                    }
                }
                
                //Check if the list containing the 30 mins or newer times has less than 5 entries in which case the new request should be handled.
                if (filteredTimesList.Count < 5)
                {
                    //Adds the routes to be returned to the user based on the Cadet role.
                    spaceRoutes = spaceRoute.GetCadetRoutes();
                    //Add the request time + id to the DB.
                    await _dbHelper.StoreRequest(id);
                }
                else
                {
                    //Notify the user that they have reached the limit of requests.
                    return Ok("You have exceded your limit of 5 requests pr 30 minutes - please try again later");
                }
            }
            //Returns the list of routes to the user.
            return Ok(spaceRoutes);
        }

        public RouteController(TokenService tokenService, DBHelper dbHelper)
        {
            _tokenService = tokenService;
            _dbHelper = dbHelper;
        }
    }
}
