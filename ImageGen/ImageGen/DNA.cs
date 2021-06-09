using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageGen
{
    class DNA
    {
        // Los genes del algoritmo serán el numero
        // de triagulos a dibujar, el numero de vertices
        // y las posiciones de cada vertice, asi como
        // tambien el color de cada triangulo
        Polygon[] genes;

        // Valor de aptitud de cada individuo
        public double fitness = 0;

        // Numero de triangulos a dibujar,
        // numero de vertices de cada triangulo
        // el numero de componentes de las coordenadas
        int nPolygons, nVertex;

        // Bitmap para la imagen generada
        public Bitmap newPaint;

        // Colores de la imagen generada
        Color[,] newPaintColors;

        public DNA()
        {
            nPolygons = 500;
            nVertex = 3;

            Init();
        }

        // Metodo que inicializa los genes de manera aleatoria
        public void Init()
        {
            // Se inicializan los genes y el color
            genes = new Polygon[nPolygons];

            newPaintColors = new Color[200,200];

            // Se inicializan los triangulos de manera aleatoria
            for (int i = 0; i < nPolygons; i++) genes[i] = new Polygon(nVertex, Mat.RandomColor());
        }

        // Metodo que calcula el valor fitness del individuo
        // el cual será la suma de las diferencias de color
        // de cada pixel
        public void Fit(Color[,] target)
        {
            // Se obtiene la imagen generada por el individuo
            GetNewImage();

            fitness = 0;

            // Se recorre cada pixel (x, y)
            for (int y = 0; y < 200; y++)
            {
                for(int x = 0; x < 200; x++)
                {
                    // Se obtiene el color del pixel (x, y) de la 
                    // imagen original y la imagen generada
                    Color c1 = target[x, y];
                    Color c2 = newPaintColors[x, y];

                    // Se calcula la diferencia en cada canal RGB
                    double diffRed = c1.R - c2.R;
                    double diffGreen = c1.G - c2.G;
                    double diffBlue = c1.B - c2.B;

                    // Se calcula la diferencia del pixel
                    double diffPixel = Math.Sqrt(diffRed * diffRed + diffGreen * diffGreen + diffBlue * diffBlue);

                    // La diferencia se suma al valor del fitness
                    fitness += diffPixel;
                }
            }
        }

        public DNA Crossover(DNA parent)
        {
            // Se crea el objeto para el hijo
            DNA child = new DNA();

            // Se calcula el punto medio de manera aleatoria
            int midpoint = Mat.Random(child.nPolygons);

            for(int i = 0; i < nPolygons; i++)
            {
                // Se heredan los genes al hijo
                if (i < midpoint) child.genes[i] = genes[i];
                else child.genes[i] = parent.genes[i];
            }

            // Se devuelve el hijo creado
            return child;
        }

        // Metodo que aplica una mutacion en el individuo 
        // alterando completamente algunos de sus genes
        public void Mutate(double mutationRate)
        {
            // Se recorre cada triangulo i
            for(int i = 0; i < nPolygons; i++)
            {
                if (Mat.Random() < mutationRate) genes[i] = new Polygon(nVertex, Mat.RandomColor());
            }
        }

        // Metodo que genera una nueva imagen con los 
        // triagulos dibujados del individuo
        public void GetNewImage()
        {   
            // Se crea un bitmap para el contexto grafico
            newPaint = new Bitmap(200, 200);
            // Se obtiene el contexto grafico del 
            // bitmap
            Graphics g = Graphics.FromImage(newPaint);

            // Se coloca un fondo negro en el bitmap
            g.Clear(Color.Black);

            // Se dibuja cada triagulo en el bitmap
            for(int i = 0; i < nPolygons; i++) g.FillPolygon(genes[i].color, genes[i].vertex);

            GetColor();
        }

        public void GetColor()
        {
            for (int y = 0; y < 200; y++)
                for (int x = 0; x < 200; x++)
                    newPaintColors[x, y] = newPaint.GetPixel(x, y);
        }
    }
}