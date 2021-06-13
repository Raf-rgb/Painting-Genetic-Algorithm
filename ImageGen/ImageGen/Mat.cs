using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageGen
{
    class Mat
    {
        static Random random = new Random();
        public static int Random(int max) { return random.Next(max); }
        public static int Random(int min, int max) { return random.Next(min, max); }
        public static double Random() { return random.NextDouble(); }

        public static float Constrain(float value, int min, int max)
        {
            if (value < min) return (float) min;
            else if (value > max) return (float) max;
            else return value;
        }

        public static Color RandomColor() { return Color.FromArgb(Random(10, 100), Random(255), Random(255), Random(255)); }

        public static Color RandomChanges(Color color, int c)
        {
            return Color.FromArgb(color.A, Math.Abs(color.R + Random(-c, c)) % 255, Math.Abs(color.G + Random(-c, c)) % 255, Math.Abs(color.B + Random(-c, c)) % 255);
        }

        public static PointF RandomChanges(PointF point, int min, int max, int c)
        {
            float newX = point.X + Random(-c, c);
            float newY = point.Y + Random(-c, c);

            //newX = Constrain(newX, min, max);
            //newY = Constrain(newY, min, max);

            return new PointF(newX, newY);
        }

        public static PointF RandomPoint(int max)
        {
            return new PointF(Random(max), Random(max));
        }
    }
}
