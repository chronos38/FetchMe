using System;
using System.ComponentModel.DataAnnotations;

namespace FetchMe.Data
{
	public class Goal
	{
		[Key]
		public int Id { get; set; }
		public string Goalscrorer { get; set; }
		public int Minute { get; set; }
	}
}