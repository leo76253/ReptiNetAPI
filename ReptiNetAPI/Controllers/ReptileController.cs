using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReptiNetAPI.Data;
using ReptiNetAPI.Models;

namespace ReptiNetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReptileController : ControllerBase
    {

        private readonly DataContext _context;

        public ReptileController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Reptile>>> GetReptiles()
        {
            var reptiles = await _context.Reptiles.ToListAsync();

            return Ok(reptiles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reptile>> GetReptile(int id)
        {
            var reptile = await _context.Reptiles.FindAsync(id);

            if (reptile == null)
            {
                return NotFound();
            }

            return Ok(reptile);
        }

        [HttpPost]
        public async Task<ActionResult<Reptile>> CreateReptile(Reptile reptile)
        {
            _context.Reptiles.Add(reptile);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<Reptile>> UpdateReptile(Reptile reptile)
        {
            var dbReptile = await _context.Reptiles.FindAsync(reptile.ID);
           
            if (dbReptile == null)
            {
                return NotFound();
            }

            dbReptile.Name = reptile.Name;
            dbReptile.Species = reptile.Species;
            dbReptile.Clutch = reptile.Clutch;

            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
