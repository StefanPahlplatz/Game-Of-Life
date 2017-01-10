using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Of_Life
{
    public partial class FormMain : Form
    {
        private const int WIDTH = 640;
        private const int HEIGHT = 360;
        private const int FPS = 24;

        private Bitmap bm;
        private GameOfLife gol;
        private Timer fps;

        // Default constuctor
        public FormMain()
        {
            InitializeComponent();

            // Initialize
            bm = new Bitmap(WIDTH, HEIGHT);
            gol = new GameOfLife(WIDTH, HEIGHT);
            fps = new Timer();
            fps.Interval = 1000 / FPS;
            fps.Tick += Fps_Tick;
            fps.Enabled = true;
        }

        // Timer tick
        private void Fps_Tick(object sender, EventArgs e)
        {
            // Update the cells
            gol.Update();

            // Call the draw event
            canvas.Invalidate();
        }

        // Draw event
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            // Draw the canvas
            e.Graphics.DrawImage(bm, 0, 0);

            // Draw the game
            gol.Draw(e.Graphics);
        }
    }
}
