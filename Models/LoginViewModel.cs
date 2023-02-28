using System.ComponentModel.DataAnnotations;

namespace QB_University.Models
{
	public class LoginViewModel
	{
		[Required] 
		public string Username { get; set; }
		[Required]
		public string Pass { get; set; }
	}
}
