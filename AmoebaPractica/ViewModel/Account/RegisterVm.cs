using System.ComponentModel.DataAnnotations;

namespace AmoebaPractica.ViewModel.Account
{
	public class RegisterVm
	{
		[MaxLength(25),MinLength(3)]
		public string Name { get; set; }
		public string Surname { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string RepeatPassword { get; set; }
	}
}
