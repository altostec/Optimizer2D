using CsvHelper;
using Humanizer.Bytes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PostOptimizer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace PostOptimizer.Services
{
	public class FileHelpers
	{
		public static IEnumerable<OptimizationRow> ProcessFormFile(IFormFile formFile,
			ModelStateDictionary modelState)
		{
			var fieldDisplayName = string.Empty;

			// Use reflection to obtain the display name for the model 
			// property associated with this IFormFile. If a display
			// name isn't found, error messages simply won't show
			// a display name.
			MemberInfo property =
				typeof(ProjectFileUpload).GetProperty(
					formFile.Name.Substring(formFile.Name.IndexOf(".") + 1));

			if (property != null)
			{
				var displayAttribute =
					property.GetCustomAttribute(typeof(DisplayAttribute))
						as DisplayAttribute;

				if (displayAttribute != null)
				{
					fieldDisplayName = $"{displayAttribute.Name} ";
				}
			}

			// Use Path.GetFileName to obtain the file name, which will
			// strip any path information passed as part of the
			// FileName property. HtmlEncode the result in case it must 
			// be returned in an error message.
			var fileName = WebUtility.HtmlEncode(
				Path.GetFileName(formFile.FileName));

			//if (formFile.ContentType.ToLower() != "text/csv")
			//{
			//	modelState.AddModelError(formFile.Name,
			//		$"The {fieldDisplayName}file ({fileName}) must be a text/csv file.");
			//}

			// Check the file length 
			if (formFile.Length == 0)
			{
				modelState.AddModelError(formFile.Name,
					$"The {fieldDisplayName}file ({fileName}) is empty.");
			}
			else if (formFile.Length > ByteSize.FromMegabytes(3).Bytes)
			{
				modelState.AddModelError(formFile.Name,
					$"The {fieldDisplayName}file ({fileName}) exceeds 1 MB.");
			}
			else
			{
				try
				{					
					// Read the file an parse it to rows
					using (
						var reader =
							new StreamReader(
								formFile.OpenReadStream(),
								new UTF8Encoding(encoderShouldEmitUTF8Identifier: false,
									throwOnInvalidBytes: true),
								detectEncodingFromByteOrderMarks: true))
					{
						IList<OptimizationRow> rows;
						using (var csv = new CsvReader(reader))
						{
							csv.Configuration.HasHeaderRecord = false;
							rows= csv.GetRecords<OptimizationRow>().ToList();
						}
												
						// Warn if the file is empty.
						if (rows.Any())
						{
							return rows.ToList();
						}
						else
						{
							modelState.AddModelError(formFile.Name,
								$"The {fieldDisplayName}file ({fileName}) is empty.");
						}
					}
				}
				catch (Exception ex)
				{
					modelState.AddModelError(formFile.Name,
						$"The {fieldDisplayName}file ({fileName}) upload failed. " +
						$"Error: {ex.Message}");
					// Log the exception
				}
			}

			return Enumerable.Empty<OptimizationRow>();
		}
	}
}
