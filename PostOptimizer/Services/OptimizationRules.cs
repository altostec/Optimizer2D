namespace PostOptimizer.Services
{
	public enum OptimizationRules
	{
		Balance //Greatest is better
		, ProfitFactor //Greatest profit factor is better
		, ExpectedPayoff //Greatest expected payoff is better
		, MaximalDrawdown //Minimum drawdown is better
		, DrawdownPercent //Minimum drawdown percent is better
	}
}