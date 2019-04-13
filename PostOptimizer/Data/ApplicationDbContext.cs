using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PostOptimizer.Models;

namespace PostOptimizer.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		/// <summary>
		/// The collection of optimizations by project
		/// </summary>
		public DbSet<PostOptimizer.Models.OptimizationRow> OptimizationRow { get; set; }

		/// <summary>
		/// the collection of projects 
		/// </summary>
		public DbSet<PostOptimizer.Models.Project> Projects { get; internal set; }
	}
}
