using PostOptimizer.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PostOptimizer.Services
{
	public class OptimizationManager : IOptimizationManager
	{
		private readonly ApplicationDbContext dataContext;
		private OptimizationRules optimizationRule;

		public OptimizationManager(ApplicationDbContext dbContext)
		{
			this.dataContext = dbContext;
			this.OptimizationRule = OptimizationRules.Balance;
		}

		#region IOptimizationManager
		public OptimizationRules OptimizationRule
		{
			get => this.optimizationRule;
			set
			{
				this.optimizationRule = value;
				// TODO
			}
		}

		public double Minimum => throw new NotImplementedException();

		public double Maximum => throw new NotImplementedException();

		public int Count => throw new NotImplementedException();

		#endregion IOptimizationManager
	}
}
