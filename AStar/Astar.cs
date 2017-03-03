using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AStar
{
    internal class Astar
    {

        #region Events

        public delegate void OnInvalidateCaller(object sender, EventArgs e);

        public event OnInvalidateCaller InvalidateCaller;

        #endregion

        #region Private Members

        private Dictionary<Point, Spot> Spots;

        private OpenSet OpenSet;

        private ClosedSet ClosedSet;

        private List<Spot> MainPath;

        private Point End;

        #endregion

        #region Constructor

        public Astar(Dictionary<Point,Spot> spots, Point end)
        {

            OpenSet = new OpenSet(Color.Green);

            ClosedSet = new ClosedSet(Color.Red);

            MainPath = new List<Spot>();

            Spots = spots;

            End = end;

        }

        #endregion

        private void Invalidate()
        {

            if (InvalidateCaller != null)
            {

                InvalidateCaller(this, new EventArgs());

            }

        }

        public void FindPath(Object obj)
        {

            try
            {

                KeyValuePair<Point, Spot> FirstPair = Spots.First();

                FirstPair.Value.GScore = 0;

                FirstPair.Value.HScore = PointFunctions.DistanceTo(FirstPair.Value.Point, End);

                OpenSet.Add(FirstPair);

                while (OpenSet.Count > 0)
                {

                    Spot Current = OpenSet.ToList().OrderBy(p => p.Value.FScore).First().Value;

                    Console.WriteLine("Current point is: " + Current.Point.ToString());

                    Invalidate();

                    if (Current.Point == End)
                    {

                        Current.Color = Color.Blue;
                                                
                        bool Searching = true; 

                        while (Searching)
                        {

                            if (Current.CameFrom.Value != null)
                            {

                                Current.CameFrom.Value.Color = Color.Blue;

                                Current.CameFrom.Value.OnBestPath = true;

                                Current = Current.CameFrom.Value;

                            } else
                            {

                                Searching = false; 

                            }

                        }


                        Spots.ToList().ForEach(s =>
                        {
                            if (!s.Value.OnBestPath && !s.Value.IsObstacle)
                            {
                                s.Value.Color = Color.White;
                                Invalidate();
                            }
                        });

                        Invalidate();

                        Console.WriteLine("Done!");

                        break;

                    }

                    ClosedSet.Add(Current.Point, Current);

                    OpenSet.Remove(Current.Point);

                    int tempG = 0;

                    foreach (KeyValuePair<Point, Spot> neighbour in Current.Neibhours)
                    {

                        if (ClosedSet.Contains(neighbour) || neighbour.Value.IsObstacle)
                        {

                            continue;

                        }

                        tempG = Current.GScore + PointFunctions.DistanceTo(Current.Point, neighbour.Key);

                        if (!OpenSet.Contains(neighbour))
                        {

                            OpenSet.Add(neighbour);

                        }
                        else if (tempG >= neighbour.Value.GScore)
                        {

                            continue;

                        }

                        neighbour.Value.GScore = tempG;
                        neighbour.Value.HScore = PointFunctions.DistanceTo(neighbour.Key, End);
                        neighbour.Value.CameFrom = new KeyValuePair<Point, Spot>(Current.Point, Current);
                        
                    }

                    Invalidate();

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace);

                System.Diagnostics.Debugger.Break();

                throw;

            }


        }

    }
}
