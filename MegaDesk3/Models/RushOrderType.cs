using System.ComponentModel.DataAnnotations;

namespace MegaDesk3.Models
{
	public enum RushOrderType
	{
		Standard = 0,

		[Display( Name = "3 Day" )]
		ThreeDay = 1,

		[Display( Name = "5 Day" )]
		FiveDay = 2,

		[Display( Name = "7 Day" )]
		SevenDay = 3
	}
}
