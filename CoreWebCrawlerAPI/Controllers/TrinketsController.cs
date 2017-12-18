using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreWebCrawlerAPI.Interfaces;
using CoreWebCrawlerAPI.Models;
namespace CoreWebCrawlerAPI.Controllers
{
    [Route("api/[controller]")]
    public class TrinketsController : Controller
    {
        readonly ITrinkets _trinkets;

        public TrinketsController(ITrinkets trinkets)
        {
            _trinkets = trinkets;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_trinkets.All);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Trinket trinket)
        {
            try
            {
                if (trinket == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TrinketNameLinkPriceDiscountRequired.ToString());
                }
                bool trinketExist = _trinkets.DoesTrinketExist(trinket.TrinketId);
                if (trinketExist)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TrinketIDInUse.ToString());
                }
                _trinkets.Insert(trinket);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateTrinket.ToString());
            }
            return Ok(trinket);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Trinket trinket)
        {
            try
            {
                if (trinket == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TrinketNameLinkPriceDiscountRequired.ToString());
                }
                var existingTrinket = _trinkets.Find(trinket.TrinketId);
                if (existingTrinket == null)
                {
                    return NotFound(ErrorCode.TrinketNotFound.ToString());
                }
                _trinkets.Update(trinket);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateTrinket.ToString());
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string tId)
        {
            try
            {
                var trinket = _trinkets.Find(tId);
                if (trinket == null)
                {
                    return NotFound(ErrorCode.TrinketNotFound.ToString());
                }
                _trinkets.Delete(tId);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteTrinket.ToString());
            }
            return NoContent();
        }
    }

    public enum ErrorCode
    {
        TrinketNameLinkPriceDiscountRequired,
        TrinketIDInUse,
        TrinketNotFound,
        CouldNotCreateTrinket,
        CouldNotUpdateTrinket,
        CouldNotDeleteTrinket
    }
}
