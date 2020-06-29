using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThinkAboutUs.API.Business;
using ThinkAboutUs.API.Dtos;

namespace ThinkAboutUs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly IDogService _dogService;

        public DogsController(IDogService dogService)
        {
            _dogService = dogService;
        }

        
        // GET: api/Dogs
        [HttpGet]
        [Route("all")]
        public IEnumerable<DogDto> GetDogs()
        {
            var dogs = _dogService.GetAll();

            return dogs;
        }

        // GET: api/dogs/homeless
        [HttpGet]
        [Route("homeless")]
        public IEnumerable<DogDto> GetHomelessDogs()
        {
            var dogs = _dogService.GetHomeless();

            return dogs;
        }

        // GET: api/dogs/lost
        [HttpGet]
        [Route("lost")]
        public IEnumerable<DogDto> GetLostDogs()
        {
            var dogs = _dogService.GetLost();

            return dogs;
        }

        // GET: api/dogs/adoptedAndFound
        [HttpGet]
        [Route("adoptedAndFound")]
        public IEnumerable<DogDto> GetAdoptedAndFoundDogs()
        {
            var dogsA = _dogService.GetAdoptedDogs();
            var dogsF = _dogService.GetFoundDogs().ToList();

            foreach(var d in dogsA)
            {
                dogsF.Add(d);
            }

            return dogsF;
        }

        // GET: api/dogs/adopted
        [HttpGet]
        [Route("adopted")]
        public IEnumerable<DogDto> GetAdoptedDogs()
        {
            var dogs = _dogService.GetAdoptedDogs();

            return dogs;
        }

        // GET: api/dogs/found
        [HttpGet]
        [Route("found")]
        public IEnumerable<DogDto> GetFoundDogs()
        {
            var dogs = _dogService.GetFoundDogs();

            return dogs;
        }

        // GET: api/Dogs/5
        [HttpGet]
        [Route("single/{id:int}")]
        public IActionResult GetDog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dog = _dogService.Get(id);

            if (dog == null)
            {
                return NotFound();
            }

            return Ok(dog);
        }

        // PUT: api/Dogs/5
        [HttpPut("{id}")]
        public IActionResult PutDog([FromRoute] int id, [FromBody] DogDto dog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dog.Id)
            {
                return BadRequest();
            }

            _dogService.Update(dog);

            return NoContent();
        }

        // POST: api/Dogs
        [HttpPost]
        public IActionResult PostDog([FromBody] CreateDogDto dog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdDog = _dogService.Add(dog);

            return CreatedAtAction("GetDog", new { id = createdDog.Id }, createdDog);
        }

        // DELETE: api/Dogs/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteDog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deleted = _dogService.Delete(id);
            if (deleted == false)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}