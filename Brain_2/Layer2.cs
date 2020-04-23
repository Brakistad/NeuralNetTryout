using System;
using System.Collections.Generic;
using System.Text;

namespace Gladiators
{
    class Layer2
    {
        //public List<Node2> nodes = new List<Node2>();
        //public int nodeCount;
        //public double averageNodeScore;
        //double[] layerVector;

        //public Layer2(int numberOfNodes, int relations)
        //{
        //    for (int i = 0; i < numberOfNodes; i++)
        //    {
        //        nodes.Add(new Node2(relations));
        //    }
        //    layerVector = new double[numberOfNodes];
        //    this.nodeCount = numberOfNodes;
        //}

        //public double[] CalculateLayerVector(double[] inputVector)
        //{
        //    double[] resultVector = new double[nodes.Count];
        //    int i = 0;
        //    foreach (Node2 node in nodes)
        //    {
        //        resultVector[i] = node.CalculateNode(inputVector);
        //        i++;
        //    }
        //    CalculateAverageNodeScore();
        //    this.layerVector = resultVector;
        //    return resultVector;

        //}
        //public void AdjustLayer(double dScore, double Score, int learningRate)
        //{
        //    for (int i = 0; i < this.nodes.Count; i++)
        //    {
        //        nodes[i].AdjustNode(dScore, Score, learningRate);
        //    }
        //}

        //public void CalculateAverageNodeScore()
        //{
        //    double sumOfRealNodeValues = 0;
        //    foreach (Node2 node in nodes)
        //    {
        //        sumOfRealNodeValues += node.realValue;
        //    }
        //    this.averageNodeScore = sumOfRealNodeValues / ((double)nodes.Count);
        //}

        //public double[] SeeOutPutValues()
        //{
        //    return this.layerVector;

        //}
        public List<Node2> nodes = new List<Node2>();
        public int nodeCount;
        double[] layerVector;

        public Layer2(int numberOfNodes, int relations)
        {
            for (int i = 0; i < numberOfNodes; i++)
            {
                nodes.Add(new Node2(relations));
            }
            layerVector = new double[numberOfNodes];
            this.nodeCount = numberOfNodes;
        }

        public double[] CalculateLayerVector(double[] inputVector)
        {
            double[] resultVector = new double[nodes.Count];


            this.layerVector = resultVector;
            return resultVector;

        }
        public void AdjustLayer(double dScore, double Score, int learningRate)
        {

        }

        public void CalculateAverageNodeScore()
        {

        }

        public double[] SeeOutPutValues()
        {
            return this.layerVector;

        }
    }
}
