using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PostOptimizer.Models
{
	/// <summary>
	/// The csv file to be uploaded from client
	/// </summary>
	public class ProjectFileUpload : Project
	{		
		[Required]
		[Display(Name = "Upload file (csv)")]
		public IFormFile FileUpload { get; set; }		
	}
}
