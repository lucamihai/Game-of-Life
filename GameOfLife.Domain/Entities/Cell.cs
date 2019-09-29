using System.Drawing;

namespace GameOfLife.Domain.Entities
{
    public class Cell
    {
        public bool Alive { get; set; }
        public Rectangle Rectangle { get; set; }
    }
}
