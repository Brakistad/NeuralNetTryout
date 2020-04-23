using System;
using System.Collections.Generic;
using System.Text;

namespace Gladiators
{
    
    class Node
    {
        Random random;
        int relations;
        public double[] weights;
        double bias;
        double minWeight = 0;
        double maxWeight = 10;
        double minBias = 0;
        double maxBias = 100;

        public double realValue;

        public Node(int rel)
        {
            this.relations = rel;
            weights = new double[rel];
            random = new Random();
            InitiateParameters();
        }

        public void InitiateParameters()
        {
            this.bias = 1;
            for (int i = 0; i < this.relations; i++)
            {
                weights[i] = random.NextDouble()*maxWeight;
            }
        }

        public void AdjustNode(double scoreForNode, int learningRate)
        {
            /* attempt#1
            double punishScore = 1.0 - score*realValue;

            weight = weight * (1 - punishScore * learningRate);
            */
            double[] scoreForWeight = new double[this.relations];
            double[] punnishForWeight = new double[this.relations];
            for (int i = 0; i < this.relations; i++)
            {
                scoreForWeight[i] = scoreForNode * RelativeWeight(weights[i]);
                punnishForWeight[i] = (1 - scoreForWeight[i])*(0.0001*((double)learningRate));
                weights[i] += punnishForWeight[i]*(((double)random.Next(-learningRate, learningRate))/100);
                if (weights[i] < minWeight)
                {
                    weights[i] = minWeight;
                }
                else if (weights[i] > maxWeight)
                {
                    weights[i] = maxWeight;
                }
            }

            
        }

        private double RelativeWeight(double fokusWeight)
        {
            double sumWeights = 0;
            foreach  (double weight in this.weights)
            {
                sumWeights += weight;
            }
            if (sumWeights == 0)
            {
                return 1.0/((double)this.weights.Length);
            }
            fokusWeight = fokusWeight / sumWeights;
            return fokusWeight;
        }

        public double CalculateNode(double[] inputVector)
        {

            double[] results = new double[this.relations];
            double[] maxResults = new double[this.relations];
            double final = 1;
            double maxFinal = 1;
            for (int i = 0; i < inputVector.Length; i++)
            {
                results[i] = inputVector[i] * weights[i] + this.bias;
                maxResults[i] = inputVector[i] * maxWeight + this.bias;

                final *= Math.Pow(Math.E, results[i]);
                maxFinal *= Math.Pow(Math.E, maxResults[i]);
            }
            final = final / maxFinal;
            this.realValue = final;
            return this.realValue;
        }
    }
}
