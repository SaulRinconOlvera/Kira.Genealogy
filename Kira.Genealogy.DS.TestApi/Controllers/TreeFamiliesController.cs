using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kira.Genealogy.Model.Domain.Tree;
using Kira.Genealogy.Persistence.Context;

namespace Kira.Genealogy.DS.TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeFamiliesController : ControllerBase
    {
        private readonly GenealogyContext _context;

        public TreeFamiliesController(GenealogyContext context)
        {
            _context = context;
        }

        // GET: api/TreeFamilies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TreeFamily>>> GetTrees()
        {
            return await _context.Trees.ToListAsync();
        }

        // GET: api/TreeFamilies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TreeFamily>> GetTreeFamily(Guid id)
        {
            var treeFamily = await _context.Trees.FindAsync(id);

            if (treeFamily == null)
            {
                return NotFound();
            }

            return treeFamily;
        }

        // PUT: api/TreeFamilies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTreeFamily(Guid id, TreeFamily treeFamily)
        {
            if (id != treeFamily.Id)
            {
                return BadRequest();
            }

            _context.Entry(treeFamily).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreeFamilyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TreeFamilies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TreeFamily>> PostTreeFamily(TreeFamily treeFamily)
        {
            _context.Trees.Add(treeFamily);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTreeFamily", new { id = treeFamily.Id }, treeFamily);
        }

        // DELETE: api/TreeFamilies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TreeFamily>> DeleteTreeFamily(Guid id)
        {
            var treeFamily = await _context.Trees.FindAsync(id);
            if (treeFamily == null)
            {
                return NotFound();
            }

            _context.Trees.Remove(treeFamily);
            await _context.SaveChangesAsync();

            return treeFamily;
        }

        private bool TreeFamilyExists(Guid id)
        {
            return _context.Trees.Any(e => e.Id == id);
        }
    }
}
