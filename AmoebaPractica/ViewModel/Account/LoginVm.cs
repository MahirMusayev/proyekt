using System.ComponentModel.DataAnnotations;

namespace AmoebaPractica.ViewModel.Account
{
	public class LoginVm
	{
		[MaxLength(25), MinLength(3)]

		public string UserOrEmail {  get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
