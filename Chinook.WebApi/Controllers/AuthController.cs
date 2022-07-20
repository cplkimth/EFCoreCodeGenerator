using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Chinook.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Chinook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    public IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    [Produces("text/plain")]
    public Task<string> SignInAsync([FromBody] AuthInfo authInfo) => Task.Run(() => SignIn(authInfo));

    private string SignIn(AuthInfo authInfo )
    {
        // var employee = Dao.Employee.GetFirst(x => x.LastName == authInfo.UserName && x.FirstName == authInfo.Password);
        var employee = Dao.Employee.GetFirst(x => x.EmployeeId == int.Parse(authInfo.UserName));
        if (employee == null)
            return "Wrong";

        var claims = new[] {
                               new Claim(JwtRegisteredClaimNames.Sub, employee.EmployeeId.ToString()),
                               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                               new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                               new Claim(JwtRegisteredClaimNames.Name, employee.FullName),
                           };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [HttpGet("identify")]
    [Produces("application/json")]
    public string Identify()
    {
        var userId = User.Claims.GetSubClaimValue(x => int.Parse(x));
            
        var userName = User.Claims.GetClaimValue(JwtRegisteredClaimNames.Name);
            
        return $"{userId} / {userName}";
    }
}

public class AuthInfo
{
    public string UserName { get; set; }
    
    // [JsonIgnore]
    public string Password { get; set; }
}