using System;
using System.Collections.Generic;
using System.Text;

namespace Gladiators
{
    class Layer1
    {
        public List<Node1> nodes = new List<Node1>();
        public int nodeCount;
        public double averageNodeScore;
        double[] layerVector;

        public Layer1(int numberOfNodes, int relations)
        {
            for (int i = 0; i < numberOfNodes; i++)
            {
                nodes.Add(new Node1(relations));
            }
            layerVector = new double[numberOfNodes];
            this.nodeCount = numberOfNodes;
        }

        public double[] CalculateLayerVector(double[] inputVector)
        {
            double[] resultVector = new double[nodes.Count];
            int i = 0;
            foreach (Node1 node in nodes)
            {
                resultVector[i] = node.CalculateNode(inputVector);
                i++;
            }
            CalculateAverageNodeScore();
            this.layerVector = resultVector;
            return resultVector;

        }
        public void AdjustLayer(double dScore,double Score, int learningRate)
        {
            for (int i = 0; i < this.nodes.Count; i++)
            {
                nodes[i].AdjustNode(dScore, Score, learningRate);
            }
        }

        public void CalculateAverageNodeScore()
        {
            double sumOfRealNodeValues = 0;
            foreach (Node1 node in nodes)
            {
                sumOfRealNodeValues += node.realValue;
            }
            this.averageNodeScore = sumOfRealNodeValues / ((double)nodes.Count);
        }

        public double[] SeeOutPutValues()
        {
            return this.layerVector;

        }
    }
}
