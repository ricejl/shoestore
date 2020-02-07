using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using flowery.Models;
using flowery.Services;
using Microsoft.AspNetCore.Mvc;

namespace flowery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlowerController : ControllerBase
    {
        private readonly FlowerService _fs;
        public FlowerController(FlowerService fs)
        {
            _fs = fs;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Flower>> Get()
        {
            try
            {
                return Ok(_fs.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Flower> GetById(int id)
        {
            try
            {
                return Ok(_fs.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<IEnumerable<Flower>> Create([FromBody] Flower newFlower)
        {
            try
            {
                return Ok(_fs.Create(newFlower));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Flower>> Edit(int id, [FromBody] Flower update)
        {
            try
            {
                update.Id = id;
                return Ok(_fs.Edit(update));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<String> Delete(int id)
        {
            try
            {
                return Ok(_fs.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
