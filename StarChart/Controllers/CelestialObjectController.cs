using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarChart.Data;

namespace StarChart.Controllers
{

    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var celestialObject = _context.CelestialObjects
                .Include(x => x.Satellites)
                .FirstOrDefault(x => x.Id == id);

            if(celestialObject is null) return NotFound();

            return Ok(celestialObject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name:int}")]
        public IActionResult GetByName(string name)
        {
            var celestialObject = _context.CelestialObjects
                .Include(x => x.Satellites)
                .FirstOrDefault(x => x.Name == name);

            if(celestialObject is null) return NotFound();

            return Ok(celestialObject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var celestialObject = _context.CelestialObjects
                .Include(x => x.Satellites)
                .ToList();

            return Ok(celestialObject);
        }
    }
}
