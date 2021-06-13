using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageGen
{
    class Ellipse
    {
        // Alto y Ancho de la elipse
        int w, h;
        // Posición de la elipse en la pantalla
        PointF pos;
        // Color del relleno
        SolidBrush color;

        public Ellipse(PointF pos_, int w_, int h_, Color c)
        {
            w = w_;
            h = h_;
            pos = pos_;
            color = new SolidBrush(c);
        }

        // Metodo para dibujar la elipse
        public void Draw(Graphics g) { g.FillEllipse(color, pos.X, pos.Y, w, h); }
    }
}
