using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageGen
{
    class Population
    {
        // Arreglo que contendrá los n individuos de 
        // la poblacion
        public DNA[] pop;

        // La imagen objetivo a recrear
        Bitmap target;

        // Colores de la imagen objetivo
        Color[,] targetColor;

        // Tamaño de la poblacion
        int popSize;

        // El porcentaje de mutation a aplicar
        double mutationRate;


        public Population(int popSize_, Bitmap target_, double mutationRate_)
        {
            popSize = popSize_;
            target = target_;
            mutationRate = mutationRate_;

            pop = new DNA[popSize];
            targetColor = new Color[200, 200];

            for(int i = 0; i < popSize; i++) pop[i] = new DNA();

            GetColor();
        }

        public void CalcFitness()
        {
            for (int i = 0; i < popSize; i++) pop[i].Fit(targetColor);
        }

        public void SortPopulation()
        {
            for (int i = 1; i < popSize - 1; i++)
            {
                for (int j = 0; j < popSize - i - 1; j++)
                {
                    if (pop[j].fitness > pop[j + 1].fitness)
                    {
                        DNA aux = pop[j];
                        pop[j] = pop[j + 1];
                        pop[j + 1] = aux;
                    }
                }
            }
        }

        public void NextGeneration()
        {
            for (int i = popSize/4; i < popSize; i++)
            {
                
                if (Mat.Random() < 0.5)
                {
                    DNA parent1 = pop[Mat.Random(popSize)];
                    DNA parent2 = pop[Mat.Random(popSize)];

                    DNA child = parent1.Crossover(parent2);

                    child.Mutate(mutationRate);

                    pop[i] = child;
                }
                else
                {
                    //pop[i].Mutate(mutationRate);
                    pop[i] = new DNA();
                }
            }
        }

        public DNA GetTheBest() { return pop[0]; }

        public void GetColor()
        {
            for (int y = 0; y < 200; y++)
                for (int x = 0; x < 200; x++)
                    targetColor[x, y] = target.GetPixel(x, y);
        }
    }
}