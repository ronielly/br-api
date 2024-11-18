using System.ComponentModel.DataAnnotations;
using System.Net;
using BrApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BrApi
{

    [ApiController]
    [Route("api/vi/[controller]")]
    public class BankController : ControllerBase
    {
        public readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet("get/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _bankService.GetAllBanks();

            if(response.HttpStatusCode == HttpStatusCode.OK){
                return Ok(response.Data);
            }
            else
            {
                return StatusCode((int)response.HttpStatusCode, response.Error);
            }
        }

        [HttpGet("get/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([RegularExpression("^[0-9]*$")]string code)
        {
            var response = await _bankService.GetBankByCode(code);

            if(response.HttpStatusCode == HttpStatusCode.OK)
            {
                return Ok(response.Data);
            }
            else
            {
                return StatusCode((int)response.HttpStatusCode, response.Error);
            }
        }
    }
}