using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PostOptimizer.Models;
using PostOptimizer.Data;
using PostOptimizer.Services;

namespace PostOptimizer.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
		public IList<Project> Projects { get; set; }

		public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }        
				
        public async Task OnGetAsync()
		{
			await this.LoadProjects();
		}
				
		[BindProperty]
		public ProjectFileUpload ProjectFileUpload { get; set; }		

		public async Task<IActionResult> OnPostAsync()
		{			
			// Validate model
			if (!this.ModelState.IsValid)
			{
				await this.LoadProjects();
				return this.Page();
			}

			//import csv
			var projectRows =FileHelpers.ProcessFormFile(ProjectFileUpload.FileUpload, ModelState);
			
			// Perform a second check to catch ProcessFormFile method
			// violations.
			if (!this.ModelState.IsValid)
			{
				await this.LoadProjects();
				return this.Page();
			}
						
			using (var transaction = this._context.Database.BeginTransaction())
			{
				try
				{
					_context.Projects.Add(this.ProjectFileUpload);
					this._context.OptimizationRow.AddRange(projectRows);
					await _context.SaveChangesAsync();
					transaction.Commit();
				}
				catch (Exception ex)
				{
					throw; //Custom error here.					
				}
			}

			return this.RedirectToPage("./Index");
		}

		private async Task LoadProjects()
		{
			this.Projects = await this._context.Projects.ToListAsync();
		}

	}
}
