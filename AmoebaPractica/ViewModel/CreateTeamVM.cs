using System.ComponentModel.DataAnnotations;

namespace AmoebaPractica.ViewModel
{
	public class CreateTeamVM
	{
		[Required,MaxLength(25)]
		public string Fullname { get; set; }
		[Required, MaxLength(25)]

		public string Position { get; set; }
		public string ImageUrl { get; set; }
		public string Icons { get; set; }
		public string Description { get; set; }
	}
}
