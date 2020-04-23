using System;
using System.Collections.Generic;
using System.Text;

namespace Gladiators
{
    
    class Node1
    {
        Random random;
        int relations;
        public double[] weights;
        public double[] prevWeights;

        public double bias;
        double prevBias;
        double biasVelocity;


        double[] weightVelocities;
        double[] adaptedVelocities;

        double kickFactor = 0.001;
        double kickTreshold = 0.9;

        public double realValue;

        public Node1(int rel)
        {
            this.relations = rel;
            weights = new double[rel];
            prevWeights = new double[rel];
            weightVelocities = new double[rel];
            adaptedVelocities = new double[rel];
            random = new Random();
            InitiateParameters();
        }

        public void InitiateParameters()
        {
            this.bias = random.NextDouble() * random.Next(-100, 100);
            this.prevBias = this.bias;
            this.biasVelocity = 0;
            for (int i = 0; i < this.relations; i++)
            {
                weights[i] = random.NextDouble()*random.Next(-100,100);
                prevWeights[i] = weights[i];
                weightVelocities[i] = 0;
            }
        }

        public void AdjustNode(double dScore, double Score, int learningRate)
        {
            this.biasVelocity = this.bias - this.prevBias;
            this.prevBias = this.bias;
            this.bias += (biasVelocity * dScore) * (((double)learningRate) / 100.0);
            CalculateWeightVelocities();
            this.prevWeights = this.weights;
            AdaptVelocities(dScore, Score, learningRate);
            for (int i = 0; i < this.relations; i++)
            {
                this.weights[i] += this.adaptedVelocities[i]*(((double)learningRate)/100.0);
            }
        }

        public double CalculateNode(double[] inputVector)
        {

            double weightedSum = 0.0;
            double[] maxResults = new double[this.relations];
            double sigmoid = 1;
            for (int i = 0; i < inputVector.Length; i++)
            {
                weightedSum += inputVector[i] * weights[i];
            }
            double sigmoidDenom = Math.Pow(Math.E, -(weightedSum + this.bias));
            if (Double.IsPositiveInfinity(sigmoidDenom))
            {
                sigmoid = 0;
            }
            else
            {
                sigmoid = 1 / (1 + sigmoidDenom);
            }
            this.realValue = sigmoid;
            return this.realValue;
        }
        private void CalculateWeightVelocities()
        {
            for (int i = 0; i < weights.Length; i++)
            {
                this.weightVelocities[i] = this.weights[i] - this.prevWeights[i];
            }
            
        }
        private void AdaptVelocities(double dScore, double Score, int learningRate)
        {
            double kick = 0;
            
            for (int i = 0; i < weights.Length; i++)
            {
                if ((Score < this.kickTreshold)&&(weightVelocities[i] == 0))
                {
                    kick = 1;
                }
                else
                {
                    kick = 0;
                }
                this.adaptedVelocities[i] = weightVelocities[i]*dScore + kick * this.kickFactor*( (double)random.Next(-10,10) )*(((double)learningRate)/100.0);
            }

            

            kick = 0;
        }
    }
}
