using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Swagger.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        /// <summary>
        /// Get All Samples
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<SampleViewModel>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(1);
        }

        /// <summary>
        /// Get a specific Sample by unique SampleId
        /// </summary>
        /// <param name="id" example="1"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(SampleViewModel), StatusCodes.Status200OK)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(2);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateSampleModel model)
        {
            return Ok(3);
        }
    }
}