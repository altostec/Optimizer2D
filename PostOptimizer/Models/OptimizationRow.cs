using CsvHelper.Configuration.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PostOptimizer.Models
{
	/// <summary>
	/// Matches the columns of the cvs file to be imported
	/// </summary>
	public class OptimizationRow
	{		
		public OptimizationRow()
		{
		}
				
		public int Id { get; set; }

		[Display(Name = "Pass")]		
		[Index(0)]
		public int Pass { get; set; }

		[Display(Name = "Profits")]
		[Index(1)]
		public double Profits { get; set; }

		[Display(Name = "Total Transactions")]
		[Index(2)]
		public int Transations { get; set; }

		[Display(Name = "Profit Factor")]
		[Index(3)]
		public double ProfitFactor { get; set; }

		[Display(Name = "Expected Payoff")]
		[Index(4)]
		public double ExpectedPayoff { get; set; }

		[Display(Name = "Balance Drawdown")]
		[Index(5)]
		public double BalanceDrawDown { get; set; }
		
		[Display(Name = "Relative Drawdown")]
		[Index(6)]
		public string RelativeDrawDown { get; set; }

		[Display(Name = "Paramenter 1")]
		[Index(8)]		
		public string InputParameter1 { get; set; }

		[Display(Name = "Paramenter 2")]
		[Index(9)]
		public string InputParameter2 { get; set; }

		[Display(Name = "Paramenter 3")]
		[Index(10)]
		public string InputParameter3 { get; set; }

		[Display(Name = "Paramenter 4")]
		[Index(11)]
		public string InputParameter4 { get; set; }

		public int ProjectId { get; set; }
	}
}
