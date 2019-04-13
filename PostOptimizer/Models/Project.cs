using System;
using System.ComponentModel.DataAnnotations;

namespace PostOptimizer.Models
{
	public class Project
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "File name")]
		[StringLength(100, MinimumLength = 3)]
		public string OriginalFileName { get; set; }

		[Required]
		[Display(Name = "Project")]
		[StringLength(100, MinimumLength = 3)]
		public string Title { get; set; }

		[Display(Name = "Size (bytes)")]
		[DisplayFormat(DataFormatString = "{0:N1}")]
		public long FileSize { get; set; }

		[Display(Name = "Date (UTC)")]
		[DisplayFormat(DataFormatString = "{0:F}")]
		public DateTime UploadDate { get; set; }		
	}
}
