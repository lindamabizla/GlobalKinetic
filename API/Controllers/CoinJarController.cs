using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CoinJarController : ControllerBase
    {
        private readonly ICoinJar _iCoinJar;

        public CoinJarController(ICoinJar iCoinJar)
        {
            _iCoinJar = iCoinJar;
        }

        [HttpPost]
        public IActionResult AddCoin([FromBody] CoinJarHeaderModel model)
        {
            ICoin coin = new CoinJarHeaderModel
            {
                Amount = model.Amount,
                Volume = model.Volume
            };
            
            _iCoinJar.AddCoin(coin);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public IActionResult GetTotalAmount()
        {
            var result = _iCoinJar.GetTotalAmount();
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "No content available");
            }
        }

        [HttpGet]
        public IActionResult Reset()
        {
            _iCoinJar.Reset();
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        public IActionResult GetAllCoins()
        {
            var result = _iCoinJar.GetAllCoins();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "No content available");
            }
        }
    }
}
