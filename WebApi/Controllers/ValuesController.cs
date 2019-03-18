using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Shared;
using Domain.UseCases.Reports;
using Microsoft.AspNetCore.Mvc;

namespace SpecificationPatternDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUseCase<ReadReportsRequest, ReadReportsResponse> _readReportsUseCase;

        public ValuesController(IUseCase<ReadReportsRequest, ReadReportsResponse> readReportsUseCase)
        {
            _readReportsUseCase = readReportsUseCase;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _readReportsUseCase.Execute(new ReadReportsRequest
            {
                Limit = 100,
                Offset = 0
            });

            return Ok(response);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
