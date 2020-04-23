using System;
using System.Collections.Generic;
using System.Text;

namespace Gladiators
{
    class Brain
    {
        public List<Layer> hiddenLayers = new List<Layer>();
        public static Random random = new Random();
        double[] output;
        int learningRate = 10;

        public Brain()
        {

        }
        public Brain(int[] nodesInLayers)
        {
            
            
            for (int i = 0; i < nodesInLayers.Length; i++)
            {
                if (i == 0)
                {
                    hiddenLayers.Add(new Layer(nodesInLayers[i],10));
                }
                else
                {
                    hiddenLayers.Add(new Layer(nodesInLayers[i],nodesInLayers[i-1]));
                }
                
            }
            output = new double[hiddenLayers[hiddenLayers.Count-1].nodeCount];
        }
        public void Think(double[] inputs)
        {
            int[] maxActions = new int[Action.maxAmount];
            int i = 0;
            foreach (var item in maxActions)
            {
                maxActions[i] = 0;
                i++;
            }
            double[] nextInput = inputs;
            foreach ( Layer layer in hiddenLayers)
            {
                nextInput = layer.CalculateLayerVector(nextInput);
            }
            FokusOutputs();
        }
        public void FokusOutputs()
        {
            this.output = hiddenLayers[hiddenLayers.Count - 1].SeeOutPutValues();
        }
        public void Learn(double Score)
        {
            double[] relativeValueInLayers = new double[hiddenLayers.Count];
            double sumOfLayerValues = 0;
            foreach  ( Layer layer in hiddenLayers)
            {
                sumOfLayerValues += layer.averageNodeScore;
            }
            for (int i = 0; i < hiddenLayers.Count; i++)
            {
                relativeValueInLayers[i] = (hiddenLayers[i].averageNodeScore)/sumOfLayerValues;
                hiddenLayers[i].AdjustLayer(Score * relativeValueInLayers[i], this.learningRate);
            }

        }



        public double[] Outputs
        {
            get { return this.output; }
        }
        public int LearningRate
        {
            get { return this.learningRate; }
            set { this.learningRate = value; }
        }
    }
}
