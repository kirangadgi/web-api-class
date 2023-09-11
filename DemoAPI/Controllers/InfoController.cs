using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace DemoAPI.Controllers;

public class InfoController : ControllerBase
{
    [HttpGet("/info")]
    public async Task<ActionResult> GetTheInfo()
    {
        return Ok("The Controller is working, thanks for trying");
    }

    [HttpGet("/blog/{year:int:min(2005)}/{month:int:min(1):max(12)}/{day:int:min(1):max(31)}")]
    public async Task<ActionResult> Blog(int year, int month, int day)
    {
        return Ok($"Got it {year} {month} {day}");
    }

    //Get /colors/{color}

    [HttpGet("/colors")]
    public async Task<ActionResult> GetColors([FromQuery] string color = "Blue")
    {
        return Ok($"Color is {color}");
    }

    [HttpGet("/employees")]

    public async Task<ActionResult> GetEmployees([FromQuery] string department = "All")

    {

        var employees = new List<Employee>

        {

            new Employee("Bob Smith", "dev"),

            new Employee("Joe Jones", "dev"),

            new Employee("Sue Blue", "ceo")

        };

        if (department != "All")

        {

            var response = employees.Where(e => e.Department == department).ToList();

            return Ok(new ResponseType<List<Employee>>(response, department));

        }

        return Ok(new ResponseType<List<Employee>>(employees, department));

    }
    [HttpGet("/WhoAmI")]
    public async Task<ActionResult> WhoAmi([FromHeader(Name ="User-Agent")]string userAgent)
    {
        return Ok($"You are running {userAgent}");

    }

    [HttpPost("/bug-reports")]
    public async Task<ActionResult> AddBugReport([FromBody] CreateBugReportRequest request)
    {
        return Ok(request);
    }


    public record ResponseType<T>(T data, string Filter);

    public record Employee(string Name, string Department);

    public record CreateBugReportRequest
    {
        public string Application { get; set; } = string.Empty;
        public string Issue { get; set; } = string.Empty;

        public int Priority { get; set; }
    }
}


