using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // api/Calculator/Add?x=45&y=98
        [HttpGet]
        public int Add(int a, int b)
        {
            return a + b;
        }
        // api/Calculator/Add?x=95&y=9
        [HttpPut]
        public int Subtraction(int a, int b)
        {
            return a - b;
        }
        // api/Calculator/Add?x=95&y=9
        [HttpPost]

        public int Multiplication(int a, int b)
        {
            return a * b;
        }
        // api/Calculator/Add?x=65&y=13
        [HttpDelete]

        public int Divide(int a, int b)
        {
            return a / b;
        }
    }
}
