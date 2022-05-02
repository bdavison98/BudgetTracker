using System.ComponentModel.DataAnnotations;
namespace budge.Models
{
	public class Expenses
	{
		public Expenses() { }

		public int ID { get; set; }
		public string Label { get; set; } = string.Empty;
		public float Amount { get; set; }
		//public string[] Tags { get; set; }

	} 
	
}

