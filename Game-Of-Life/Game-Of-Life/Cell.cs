using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Life
{
    public class Cell
    {
        private int x;
        private int y;
        private readonly int dim;
        private State state;

        public enum State { DEATH, BIRTH, LIVE };

        public Cell(int x, int y, int dim, State initialState)
        {
            this.x = x;
            this.y = y;
            this.dim = dim;

            state = initialState;
        }

        public void NewState(State s)
        {
            state = s;
        }

        public void Draw(Graphics g)    // TODO: test with ref param
        {
            switch (state)
            {
                case State.DEATH:
                    g.FillRectangle(Brushes.Black, x, y, dim, dim);
                    break;
                case State.BIRTH:
                    g.FillRectangle(Brushes.White, x, y, dim, dim);
                    break;
                case State.LIVE:
                    g.FillRectangle(Brushes.White, x, y, dim, dim);
                    break;
            }
        }
    }
}
