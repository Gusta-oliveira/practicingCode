using Microsoft.AspNetCore.Mvc;
using RestWithASPNet.Services;
using System.Reflection.Metadata.Ecma335;

namespace RestWithASPNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Sub(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound("Usuário não encontrado");

            return Ok(person);
        }




        //[HttpGet("mult/{firsNumber}&{secondNumber}")]
        //public IActionResult Mult(string firstNumber, string secondNumber)
        //{
        //    if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
        //        return Ok(mult.ToString());
        //    }
        //    return BadRequest();
        //}

        //[HttpGet("div/{firsNumber}&{secondNumber}")]
        //public IActionResult Div(string firstNumber, string secondNumber)
        //{
        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        var first = ConvertToDecimal(firstNumber);
        //        if(first == 0)
        //            return BadRequest("Valor informado não pode ser dividido");

        //        var mult =  first/ ConvertToDecimal(secondNumber);
        //        return Ok(mult.ToString());
        //    }
        //    return BadRequest();
        //}

        //[HttpGet("average/{firsNumber}&{secondNumber}")]
        //public IActionResult Average(string firstNumber, string secondNumber)
        //{
        //    decimal average = 0;
        //    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        //    {
        //        average = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;

        //        return Ok(average.ToString());
        //    }
        //    return BadRequest();
        //}

        //[HttpGet("sqrt/{firsNumber}")]
        //public IActionResult Square(string firstNumber)
        //{
        //    if (IsNumeric(firstNumber))
        //    {
        //        var sqrt = (double)ConvertToDecimal(firstNumber);

        //        Math.Sqrt(sqrt);

        //        return Ok(sqrt.ToString());
        //    }
        //    return BadRequest();
        //}

        //private bool IsNumeric(string number)
        //{
        //    double value = 0;
        //    bool isNumeric = false;

        //    isNumeric = double.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out value);

        //    return isNumeric;
        //}

        //private decimal ConvertToDecimal(string number)
        //{
        //    decimal decimalValue;

        //    if (decimal.TryParse(number, out decimalValue))
        //    {
        //        return decimalValue;
        //    }
        //    return 0;
        //}

    }
}
