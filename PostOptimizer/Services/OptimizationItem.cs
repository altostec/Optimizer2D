namespace PostOptimizer.Services
{
	public class OptimizationItem
	{
		int Id { get; set; }

		double Value { get; set; }

		/// <summary>
		/// The percentage the value represents respect the maximum possible.
		/// </summary>
		double Weight { get; set; }
	}
}