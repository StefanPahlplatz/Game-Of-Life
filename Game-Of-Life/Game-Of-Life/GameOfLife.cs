using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Life
{
    public class GameOfLife
    {
        private const int CELL_DIM = 8;

        private readonly Cell[,] cells;
        private readonly int columns;
        private readonly int rows;

        public GameOfLife(int width, int height)
        {
            columns = width / CELL_DIM;
            rows = height / CELL_DIM;
            cells = new Cell[columns, rows];

            initCells();
        }

        public void Draw(Graphics g)
        {
            foreach (Cell cell in cells)
            {
                cell.Draw(g);
            }
        }

        private void initCells()
        {
            Random r = new Random();

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    cells[x, y] = new Cell(x * CELL_DIM, y * CELL_DIM, CELL_DIM, (Cell.State)r.Next(0, 2));
                }
            }
        }
    }
}
