using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;



namespace ApiJwtDemo.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class AuthController : Controller
    {

        [HttpPost("token")]
        public IActionResult GetToken()
        {

            //security key  <-- this should not be in here.  save it elsewhere but this is for demo
            string securityKey = "this is my super long security key for the API demo 11/21/2019";

            //semetric security key
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            //signing credentials
            var singingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            //create token
            var token = new JwtSecurityToken(
                issuer: "smesk.in",
                audience: "readers",
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: singingCredentials
            );
            
            //return token
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
        



    }



}