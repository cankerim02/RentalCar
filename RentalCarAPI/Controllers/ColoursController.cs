﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentalCarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoursController : ControllerBase
    {
        IColourService _colourService;

        public ColoursController(IColourService colourService)
        {
            _colourService = colourService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colourService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpPost("add")]
        public IActionResult Add(Colour colour)
        {
            var result = _colourService.Add(colour);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(Colour colour)
        {
            var result = _colourService.Delete(colour);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(Colour colour)
        {
            var result = _colourService.Update(colour);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}

