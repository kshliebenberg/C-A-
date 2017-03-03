using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AStar
{ 
    public partial class Form1 : Form
    {

        private int Cols = 50;

        private int Rows = 50;

        Dictionary<Point,Spot> Spots;
                
        OpenSet  OpenSet;

        ClosedSet ClosedSet;

        List<Spot> MainPath; 

        private int w, h;

        private int Width = 500;

        private int Height = 500;

        Point End;

        public Form1()
        {

            InitializeComponent();

            this.DoubleBuffered = true;

            this.BackColor = Color.Black;

            w = (Width) / Cols;

            h = (Height) / Rows;

            this.WindowState = FormWindowState.Maximized;

            Spots = new Dictionary<Point, Spot>();

            OpenSet = new OpenSet(Color.Green);

            ClosedSet = new ClosedSet(Color.Red);

            MainPath = new List<Spot>();

            Random Ran = new Random(10000000);

            for (int i = 0; i < Cols; i++)
            {
                for (int j = 0; j < Rows; j++)
                {

                    Spot spot = new Spot(i, j, w, h, Color.White,Ran);

                    KeyValuePair<Point, Spot> pair = new KeyValuePair<Point, Spot>(spot.Point, spot);
           
                    Spots.Add(spot.Point,spot);

                    if (i == Cols -1 && j == Rows -1)
                    {

                        End = spot.Point;

                    }
                }
            }

            //Spot s = Spots.Last().Value;

            foreach (KeyValuePair<Point,Spot> item in Spots)
            {

                item.Value.FindNeighbours(Spots,Cols,Rows);

            }

            Astar algorithm = new Astar(Spots, End);

            algorithm.InvalidateCaller += RefreshForm;

            ThreadPool.QueueUserWorkItem(new WaitCallback(algorithm.FindPath));

        }


        private delegate void _RefreshForm(object sender, EventArgs e);

        private void RefreshForm(object sender, EventArgs e)
        {
           
            //if (InvokeRequired)
            //{

            //    BeginInvoke(new _RefreshForm(RefreshForm));

            //    return;

            //}

            this.Invalidate();

        }

                
        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);

            this.SuspendLayout();
            try
            {

                foreach (KeyValuePair<Point, Spot> item in Spots)
                {

                    e.Graphics.FillRectangle(item.Value.Brush, item.Value.Rectangle);

                }

            }
            catch (Exception ex)
            {

                throw;
            }
            
            this.ResumeLayout();

        }

    }

    public static class PointFunctions
    {
        public static int DistanceTo(this Point point1, Point point2)
        {
            var a = (double)(point2.X - point1.X);

            var b = (double)(point2.Y - point1.Y);

            return (int)Math.Floor(Math.Sqrt(a * a + b * b));
        }
    }

}
