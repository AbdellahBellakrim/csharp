using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace CityInfo.Api.src.controllers;

[Route("api/[controller]")]
public class authenticationController : ControllerBase
{
    public authenticationController(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }
    private readonly IConfiguration _configuration;
    public class AuthRequestBody
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class CityUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public CityUser(int id, string username, string firstName, string lastName, string city)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            City = city;
        }
    }

    private CityUser validateUser(string? username, string? password)
    {
        return new CityUser(1, "username", "firstName", "lastName", "city");
    }

    [HttpPost("login")]
    public ActionResult<string> Login([FromBody] AuthRequestBody body)
    {
        // step 1: validate the request body
        var user = validateUser(body.Username, body.Password);
        if (user == null)
        {
            return BadRequest("Invalid username or password");
        }
        // step 2: generate a token
        var secretForKey = _configuration["Authentication:SecretForKey"];
        if (secretForKey == null)
        {
            return BadRequest("Secret key is missing");
        }
        var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(secretForKey));
        var sigingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("sub", user.Id.ToString()));
        claimsForToken.Add(new Claim("username", user.Username));
        claimsForToken.Add(new Claim("firstName", user.FirstName));
        claimsForToken.Add(new Claim("lastName", user.LastName));
        claimsForToken.Add(new Claim("city", user.City));

        var token = new JwtSecurityToken(
            issuer: _configuration["Authentication:Issuer"],
            audience: _configuration["Authentication:Audience"],
            claims: claimsForToken,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: sigingCredentials
        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return Ok(tokenString);
    }
}