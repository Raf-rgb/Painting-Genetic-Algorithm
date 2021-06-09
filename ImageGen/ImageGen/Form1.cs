using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageGen
{
    public partial class Form1 : Form
    {
        Thread thread;
        Stopwatch time = new Stopwatch();
        int i = 1;

        Bitmap target = new Bitmap("C:\\Users\\Rafael\\Pictures\\Slide Shows\\calamardo.png"); // Imagen objetivo a recrear

        Population population; // Poblacion que intentará recrear la imagen objetivo
        public Form1()
        {
            InitializeComponent();

            // Se inicializa la población de tamaño 10, con la 
            // imagen objetivo y con un porcentaje de mutacion del 1%
            population = new Population(100, target, 0.01);

            // Se crea un hilo encargado de dibujar 
            // en pantalla la mejor pintura generada
            thread = new Thread(Draw);

            // Se inicia el hilo
            thread.IsBackground = true;
            thread.Start();

            // Se inicia el conteo del tiempo
            time.Start();

            // Se muestra la imagen original al lado
            Bitmap image = (Bitmap)target.Clone();
            originalImage.Image = image;
        }

        // Metodo que dibuja en pantalla la mejor pintura de
        // la poblacion
        public void Draw()
        {
            while(thread.IsAlive)
            {
                // Se calcula el valor fitness
                // de la poblacion
                population.CalcFitness();
                // Se ordenan los individuos de la poblacion con su fitness
                // del menor al mayor. Entre más pequeño sea el valor del fitness
                // es mejor
                population.SortPopulation();

                // Se obtiene el mejor individuo
                DNA bestPaint = population.GetTheBest();

                // Se obtiene la pintura generada por el mejor
                // individuo
                Bitmap newImage = bestPaint.newPaint;
                // Se obtiene el contexto grafico para dibujar la informacion
                // del algoritmo
                Graphics g = Graphics.FromImage(newImage);

                // Se dibuja el numero de la generacion
                g.DrawString($"Generación: #{i}", new Font("Arial", 8), new SolidBrush(Color.White), new PointF(10, 10));
                // Se dibuja el fitness del mejor individuo
                g.DrawString($"Fitness: {bestPaint.fitness / 100000}", new Font("Arial", 8), new SolidBrush(Color.White), new PointF(10, 25));
                // Se dibuja el tiempo de ejecucion
                g.DrawString($"Tiempo de ejecución:  {time.Elapsed.ToString("hh\\:mm\\:ss\\.fff")}", new Font("Arial", 8), new SolidBrush(Color.White), new PointF(10, 180));
                
                // Se muestra en pantalla la pintura generada por el 
                // mejor individuo
                bestPictureBox.Image = newImage;

                Bitmap saveImage = (Bitmap) newImage.Clone();
                saveImage.Save("D:\\Images\\" + i + ".png", ImageFormat.Png);

                // Se calcula la siguiente generacion
                population.NextGeneration();

                // Aumenta la siguiente generacion
                i++;
            }
        }
    }
}