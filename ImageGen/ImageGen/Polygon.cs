using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageGen
{
    class Polygon
    {
        public PointF[] vertex;

        public SolidBrush color;

        public Polygon(int nVertex, Color color_)
        {
            color = new SolidBrush(color_);
            vertex = new PointF[nVertex];

            for (int i = 0; i < nVertex; i++) vertex[i] = Mat.RandomPoint(200);
        }

        // Funcion para dibujar el poligono en un objeto
        // graphics
        public void Draw(Graphics g) { g.FillPolygon(color, vertex); }
    }
}
