using System;
using System.Collections.Generic;
using System.Drawing;

namespace Mars.Classes
{
    public class SuperficieMarte
    {
        #region Proprerties
        public int MaxX { get; set; }

        public int MinX { get; set; }

        public int MaxY { get; set; }

        public int MinY { get; set; }

        public HashSet<Point> Ostacoli { get; set; }

        #endregion

        #region Consturctors
        public SuperficieMarte(int maxX = 10, int minX = -10, int maxY = 10, int minY = -10)
        {
            try
            {
                MaxX = maxX;
                MinX = minX;
                MaxY = maxY;
                MinY = minY;

                int numOstacoli = ((maxX - minX) * (maxY - minY)) / 10;

                Ostacoli = new HashSet<Point>();

                Random rand = new Random();

                int index = 1;

                while (index <= numOstacoli)
                {
                    Point p = new Point(rand.Next(minX, maxX + 1), rand.Next(minY, maxY + 1));
                    if (!Ostacoli.Contains(p))
                    {
                        Ostacoli.Add(p);
                        index++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Methods
        public string[] MostraOstacoli()
        {
            try
            {
                string[] result = new string[Ostacoli.Count];
                int i = 0;
                foreach (Point p in Ostacoli)
                {
                    result[i] = $"({p.X},{p.Y})";
                    i++;
                }
                Array.Sort(result);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
