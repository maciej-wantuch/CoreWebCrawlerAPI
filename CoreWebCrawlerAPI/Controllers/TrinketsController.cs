using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreWebCrawlerAPI.Interfaces;
using CoreWebCrawlerAPI.Models;
namespace CoreWebCrawlerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpGet]
        public IActionResult Search()
        {
            return Ok(_trinkets.Search());
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
