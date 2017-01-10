using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Life
{
    public enum State { DEATH, LIVE };

    public class Cell
    {
        private int x;
        private int y;
        private readonly int dim;
        public State CurrentState { get; set; }

        public Cell(int x, int y, int dim, State initialState)
        {
            this.x = x;
            this.y = y;
            this.dim = dim;

            CurrentState = initialState;
        }

        public void Draw(Graphics g)
        {
            switch (CurrentState)
            {
                case State.DEATH:
                    g.FillRectangle(Brushes.Black, x, y, dim, dim);
                    break;
                case State.LIVE:
                    g.FillRectangle(Brushes.White, x, y, dim, dim);
                    break;
            }
        }

        public int GetValue()
        {
            return CurrentState == State.DEATH ? 0 : 1;
        }
    }
}
