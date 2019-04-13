namespace PostOptimizer.Services
{

	public interface IOptimizationManager
	{
		OptimizationRules OptimizationRule { get; set; }

		double Minimum { get; }

		double Maximum { get; }

		/// <summary>
		/// The total rows
		/// </summary>
		int Count { get;  }

	}
}