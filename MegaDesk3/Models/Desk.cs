using System;
namespace MegaDesk3.Models
{
    public class Desk
    {
        public int DeskId { get; set; }
        public int Depth { get; set; }
        public int Width { get; set; }
        public int NumberOfDrawers { get; set; }
        public SurfaceMaterial SurfaceMaterial { get; set; }
    }
}
