using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PostOptimizer.Models;
using PostOptimizer.Data;

namespace PostOptimizer.Pages.Projects
{
    public class DetailsModel : PageModel
    {
        private readonly PostOptimizer.Data.ApplicationDbContext _context;

        public DetailsModel(PostOptimizer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Project Project { get; set; }
		public IList<OptimizationRow> Optimizations { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            this.Project = await _context.Projects.FirstOrDefaultAsync(m => m.Id == id);

            if (this.Project == null)
            {
                return NotFound();
            }

			this.Optimizations = this._context.OptimizationRow.Where(r => r.ProjectId == id).ToList();

            return Page();
        }
    }
}
