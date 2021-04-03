using Microsoft.AspNetCore.Mvc;

namespace WebService.Controller
{
    [Route("api/")]
    [ApiController]
    public class ArknightDataController : ControllerBase
    {
        [Route("test")]
        [HttpPost]
        public ActionResult<Test> Home()
        {
            var test = new Test("Test", 1111);
            return Ok(test);
        }
    }
    public class Test
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public Test(string name,int number)
        {
            Name = name;
            Number = number;
        }
    }
}
