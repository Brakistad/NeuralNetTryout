using System;
using System.Collections.Generic;
using System.Text;

namespace Gladiators
{
    class Layer
    {
        public List<Node> nodes = new List<Node>();
        public int nodeCount;
        public double averageNodeScore;
        double[] relativeNodeValue;

        public Layer(int numberOfNodes, int relations)
        {
            for (int i = 0; i < numberOfNodes; i++)
            {
                nodes.Add(new Node(relations));
            }
            relativeNodeValue = new double[numberOfNodes];
            this.nodeCount = numberOfNodes;
        }

        public double[] CalculateLayerVector(double[] inputVector)
        {
            double[] resultVector = new double[nodes.Count];
            int i = 0;
            foreach (Node node in nodes)
            {
                resultVector[i] = node.CalculateNode(inputVector);
                i++;
            }
            CalculateAverageNodeScore();
            return resultVector;

        }
        public void AdjustLayer(double scoreForLayer, int learningRate)
        {
            CalculateRelativeNodeScores();
            for (int i = 0; i < this.nodes.Count; i++)
            {
                nodes[i].AdjustNode(this.relativeNodeValue[i]* scoreForLayer, learningRate);
            }


        }
        private void CalculateRelativeNodeScores()
        {
            double sumOfRealNodeValues = 0;
            foreach (Node node in nodes)
            {
                sumOfRealNodeValues += node.realValue;
            }
            for (int i = 0; i < nodes.Count; i++)
            {
                this.relativeNodeValue[i] = (nodes[i].realValue)/sumOfRealNodeValues;
            }

        }

        public void CalculateAverageNodeScore()
        {
            double sumOfRealNodeValues = 0;
            foreach (Node node in nodes)
            {
                sumOfRealNodeValues += node.realValue;
            }
            this.averageNodeScore = sumOfRealNodeValues / ((double)nodes.Count);
        }

        public double[] SeeOutPutValues()
        {
            CalculateRelativeNodeScores();
            return this.relativeNodeValue;

        }
    }
}
