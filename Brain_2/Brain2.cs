using System;
using System.Collections.Generic;
using System.Text;

namespace Gladiators
{
    class Brain2
    {
        //public List<Layer2> hiddenLayers = new List<Layer2>();
        //public static Random random = new Random();
        //double[] output;
        //int learningRate = 10;
        //double prevScore = 0;

        //public Brain2()
        //{

        //}
        //public Brain2(int[] nodesInLayers)
        //{


        //    for (int i = 0; i < nodesInLayers.Length; i++)
        //    {
        //        if (i == 0)
        //        {
        //            hiddenLayers.Add(new Layer2(nodesInLayers[i],10));
        //        }
        //        else
        //        {
        //            hiddenLayers.Add(new Layer2(nodesInLayers[i],nodesInLayers[i-1]));
        //        }

        //    }
        //    output = new double[hiddenLayers[hiddenLayers.Count-1].nodeCount];
        //}
        //public void Think(double[] inputs)
        //{
        //    int[] maxActions = new int[Action.maxAmount];
        //    int i = 0;
        //    foreach (var item in maxActions)
        //    {
        //        maxActions[i] = 0;
        //        i++;
        //    }
        //    double[] nextInput = inputs;
        //    foreach ( Layer2 layer in hiddenLayers)
        //    {
        //        nextInput = layer.CalculateLayerVector(nextInput);
        //    }
        //    FokusOutputs();
        //}
        //public void FokusOutputs()
        //{
        //    this.output = hiddenLayers[hiddenLayers.Count - 1].SeeOutPutValues();
        //}
        //public void Learn(double Score)
        //{
        //    double dScore = Score - this.prevScore;

        //    for (int i = 0; i < hiddenLayers.Count; i++)
        //    {
        //        hiddenLayers[i].AdjustLayer(dScore, Score, this.learningRate);
        //    }




        //    this.prevScore = Score;
        //}



        //public double[] Outputs
        //{
        //    get { return this.output; }
        //}
        //public int LearningRate
        //{
        //    get { return this.learningRate; }
        //    set { this.learningRate = value; }
        //}
        public List<Layer2> hiddenLayers = new List<Layer2>();
        public static Random random = new Random();
        double[] output;
        int learningRate = 10;
        double prevScore = 0;

        public Brain2()
        {

        }
        public Brain2(int[] nodesInLayers)
        {


            for (int i = 0; i < nodesInLayers.Length; i++)
            {
                if (i == 0)
                {
                    hiddenLayers.Add(new Layer2(nodesInLayers[i], 10));
                }
                else
                {
                    hiddenLayers.Add(new Layer2(nodesInLayers[i], nodesInLayers[i - 1]));
                }

            }
            output = new double[hiddenLayers[hiddenLayers.Count - 1].nodeCount];
        }
        public void Think(double[] inputs)
        {
            double[] nextInput = inputs;
            foreach (Layer2 layer in hiddenLayers)
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
            for (int i = 0; i < hiddenLayers.Count; i++)
            {

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
