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
        private const int DIM = 8;

        private readonly Cell[,] cells;
        private readonly int columns;
        private readonly int rows;

        public GameOfLife(int width, int height)
        {
            columns = width / DIM;
            rows = height / DIM;
            cells = new Cell[columns, rows];

            InitCells();
        }

        public void Update()
        {
            // Loop through every cell
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    // Get all the cells in a 3x3 grid
                    // Start at -1 to compensate for the current cell
                    int cellCount = -1;
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            cellCount += cells[(x + i + columns) % columns, (y + j + rows) % rows].GetValue();
                        }
                    }

                    // Rules
                    if ((cells[x, y].CurrentState == State.LIVE) && cellCount < 2)          // Loneliness
                        cells[x, y].CurrentState = State.DEATH;
                    else if ((cells[x, y].CurrentState == State.LIVE) && cellCount > 3)     // Overpopulation
                        cells[x, y].CurrentState = State.DEATH;
                    else if ((cells[x, y].CurrentState == State.DEATH) && cellCount == 3)   // Reproduction
                        cells[x, y].CurrentState = State.LIVE;
                }
            }
        }

        public void Draw(Graphics g)
        {
            foreach (Cell cell in cells)
            {
                cell.Draw(g);
            }
        }

        private void InitCells()
        {
            Random r = new Random();

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    cells[x, y] = new Cell(x * DIM, y * DIM, DIM, (State)r.Next(0, 2));
                }
            }
        }
    }
}
