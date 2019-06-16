using System.ComponentModel.DataAnnotations;

namespace MegaDesk3.Models
{
	public class Desk
	{
		private const int MIN_DEPTH = 12;
		private const int MAX_DEPTH = 48;
		private const int MIN_WIDTH = 24;
		private const int MAX_WIDTH = 96;
		private const int DRAWER_MIN = 0;
		private const int DRAWER_MAX = 7;

		public int DeskId { get; set; }

		[Required]
		[Range( MIN_DEPTH, MAX_DEPTH, ErrorMessage = "Depth must be between 12in and 48in." )]
		public int Depth { get; set; }

		[Required]
		[Range( MIN_WIDTH, MAX_WIDTH, ErrorMessage = "Width must be between 24in and 96in." )]
		public int Width { get; set; }

		[Display( Name = "Drawers" )]
		[Range( DRAWER_MIN, DRAWER_MAX, ErrorMessage = "Must be between 0 and 7." )]
		public int NumberOfDrawers { get; set; }

		[Display( Name = "Surface Material" )]
		public SurfaceMaterial SurfaceMaterial { get; set; }
	}
}
