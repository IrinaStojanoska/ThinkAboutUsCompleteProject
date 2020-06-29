using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThinkAboutUs.API.Data.Context;
using ThinkAboutUs.API.Data.Entities;

namespace ThinkAboutUs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ThinkAboutUsContext _context;

        public SizesController(ThinkAboutUsContext context)
        {
            _context = context;
        }

        // GET: api/Sizes
        [HttpGet]
        public IEnumerable<SizeEntity> GetSizes()
        {
            return _context.Sizes;
        }

        // GET: api/Sizes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSizeEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sizeEntity = await _context.Sizes.FindAsync(id);

            if (sizeEntity == null)
            {
                return NotFound();
            }

            return Ok(sizeEntity);
        }
    }
}