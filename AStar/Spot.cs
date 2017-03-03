using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AStar
{
    class Spot
    {

        public int FScore { get { return GScore + HScore; } }

        public int GScore { get; set; }

        public int HScore { get; set; }

        public int x { get; set; }

        public int y { get; set; }

        public int WidthAdjust { get; set; }

        public int HeightAdjust { get; set; }

        public Color Color { get; set; }

        public Brush Brush { get { return new SolidBrush(Color); } }

        public Rectangle Rectangle { get { return new Rectangle(x * WidthAdjust, y * HeightAdjust, WidthAdjust - 1, HeightAdjust - 1); } }

        public Point Point { get { return new Point(Rectangle.X, Rectangle.Y); } }

        public bool IsObstacle { get; set; }

        public bool OnBestPath { get; set; }

        public Dictionary<Point, Spot> Neibhours;


        public KeyValuePair<Point, Spot> CameFrom;

        #region Constructor

        public Spot(int xPos, int yPos, int W, int H, Color color, Random R)
        {

            x = xPos;

            y = yPos;

            GScore = 0;

            HScore = 0;

            WidthAdjust = W;

            HeightAdjust = H;

            Color = color;

            Neibhours = new Dictionary<Point, Spot>();
            
            if (R.NextDouble() < 0.2)
            {

                IsObstacle = true;

                Color = Color.Black;

            }

        }

        #endregion

        private void AddNeigbhour(int nX, int nY, Dictionary<Point,Spot> Spots)
        {

            Point point = new Point(nX, nY);

            Neibhours.Add(point, Spots[point]);

        }

      
        public void FindNeighbours(Dictionary<Point,Spot> Spots, int Cols, int Rows)
        {

            int CurrX = Point.X;

            int CurrY = Point.Y;

            Cols = Cols * WidthAdjust;

            Rows = Rows * HeightAdjust;

            if (CurrX < Cols - WidthAdjust)    
            {

                AddNeigbhour(CurrX + WidthAdjust, CurrY, Spots);

            }

            if (CurrX > 0 )
            {

                AddNeigbhour(CurrX - WidthAdjust, CurrY, Spots);

            }

            if (CurrY > 0)
            {

                AddNeigbhour(CurrX, CurrY - HeightAdjust, Spots);

            }

            if (CurrY < Rows -WidthAdjust )
            {

                AddNeigbhour(CurrX, CurrY + HeightAdjust, Spots);

            }

            if (CurrX > 0 && CurrY > 0)
            {

                AddNeigbhour(CurrX - WidthAdjust, CurrY - HeightAdjust, Spots);

            }

            if (CurrX < Cols -WidthAdjust && CurrY < Rows - HeightAdjust)
            {

                AddNeigbhour(CurrX + WidthAdjust, CurrY + HeightAdjust, Spots);
            }

            if (CurrX > 0 && CurrY < Rows - HeightAdjust)
            {

                AddNeigbhour(CurrX - WidthAdjust, CurrY + HeightAdjust, Spots);

            }

            if (CurrX < Cols -WidthAdjust && CurrY > 0)
            {

                AddNeigbhour(CurrX + WidthAdjust, CurrY - HeightAdjust, Spots);

            }

        }

        public override string ToString()
        {
            return Color.ToString() + " | " + Point.ToString();
        }

         
    }
}
