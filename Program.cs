using System;

namespace Gladiators
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Which neural structure would you like to test, brain0 or brain1. Just type the respective integer of the version you are testing");
                try
                {
                    int version = System.Convert.ToInt32(Console.ReadLine());
                    switch (version)
                    {
                        case 0:
                            runBrain0();
                            break;
                        case 1:
                            runBrain1();
                            break;
                        default:
                            Console.WriteLine("That is not a valid version");
                            break;
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            } while (true);
        }
        private static void runBrain0()
        {
            Brain brain = new Brain();
            bool flag = true;
            bool flag1 = true;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            Random random = new Random();
            int[] numberOfNodesInHiddenLayers = { 0, 0 };
            int numberOfLayers = 0;
            Console.WriteLine("This is a test of your first neural net. We are going to be simple here, our score will be just output[2], just randomly... and lets see " +
                "if it is able to adjust to our irrational rule");
            Console.ReadLine();
            do
            {

                if (flag1)
                {
                    Console.WriteLine("Write how many layers our network shall have, it have to just be a whole number");
                    try
                    {
                        numberOfLayers = System.Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {

                    }
                    numberOfNodesInHiddenLayers = new int[numberOfLayers + 1];

                    for (int i = 0; i < numberOfLayers; i++)
                    {
                        Console.WriteLine("Write how many nodes that hiddenlayer#" + i + " shall have, it have to just be a whole number");
                        try
                        {
                            numberOfNodesInHiddenLayers[i] = System.Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            i--;
                        }
                    }
                    numberOfNodesInHiddenLayers[numberOfNodesInHiddenLayers.Length - 1] = 4;
                    flag2 = true;


                }
                if (flag2)
                {
                    flag1 = false;
                    brain = new Brain(numberOfNodesInHiddenLayers);
                    Console.WriteLine("Write a learning rate you would like, this will affect how aggressivly your neural net will learn by each iteration.");
                    try
                    {
                        brain.LearningRate = System.Convert.ToInt32(Console.ReadLine());
                        flag3 = true;
                    }
                    catch (Exception)
                    {

                    }
                }
                if (flag3)
                {
                    flag2 = false;
                    double[] input = {
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0)
                    };
                    brain.Think(input);
                    string inputFormated = " { ";
                    for (int i = 0; i < input.Length - 1; i++)
                    {
                        inputFormated += input[i] + " : ";
                    }
                    inputFormated += input[input.Length - 1] + " } ";

                    double[] output = brain.Outputs;
                    string outputFormated = " { ";
                    for (int i = 0; i < output.Length - 1; i++)
                    {
                        outputFormated += output[i] + " : ";
                    }
                    outputFormated += output[output.Length - 1] + " } ";

                    Console.WriteLine("The brains response to " + inputFormated + " Was " + outputFormated);
                    Console.WriteLine("You may type a new learning rate if you want");
                    string userInput = Console.ReadLine();
                    int newLearningRate;
                    if (int.TryParse(userInput, out newLearningRate))
                    {
                        brain.LearningRate = newLearningRate;
                    }

                    double score = output[2];
                    brain.Learn(score);
                    string weightsFormatted = "";
                    foreach (Layer layer in brain.hiddenLayers)
                    {
                        Console.WriteLine("Layer" + brain.hiddenLayers.IndexOf(layer));
                        foreach (Node node in layer.nodes)
                        {
                            Console.WriteLine("node: " + layer.nodes.IndexOf(node));
                            weightsFormatted = "";
                            foreach (double weight in node.weights)
                            {
                                weightsFormatted += weight + ", ";
                            }
                            Console.WriteLine("Weights:   " + weightsFormatted);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }

            } while (flag);
        }
        private static void runBrain1()
        {
            int numberOfAverages = 100;
            int tempNumber = numberOfAverages;
            double averageScore = 0;
            double displayAverage = averageScore;
            int skipAmount = 0;
            Brain1 brain = new Brain1();
            bool flag = true;
            bool flag1 = true;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            Random random = new Random();
            int[] numberOfNodesInHiddenLayers = { 0, 0 };
            int numberOfLayers = 0;
            Console.WriteLine("This is a test of your first neural net. We are going to be simple here, our score will be just output[2], just randomly... and lets see " +
                "if it is able to adjust to our irrational rule");
            Console.ReadLine();
            do
            {

                if (flag1)
                {
                    Console.WriteLine("Write how many layers our network shall have, it have to just be a whole number");
                    try
                    {
                        numberOfLayers = System.Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {

                    }
                    numberOfNodesInHiddenLayers = new int[numberOfLayers + 1];

                    for (int i = 0; i < numberOfLayers; i++)
                    {
                        Console.WriteLine("Write how many nodes that hiddenlayer#" + i + " shall have, it have to just be a whole number");
                        try
                        {
                            numberOfNodesInHiddenLayers[i] = System.Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            i--;
                        }
                    }
                    numberOfNodesInHiddenLayers[numberOfNodesInHiddenLayers.Length - 1] = 4;
                    flag2 = true;


                }
                if (flag2)
                {
                    flag1 = false;
                    brain = new Brain1(numberOfNodesInHiddenLayers);
                    Console.WriteLine("Write a learning rate you would like, this will affect how aggressivly your neural net will learn by each iteration.");
                    try
                    {
                        brain.LearningRate = System.Convert.ToInt32(Console.ReadLine());
                        flag3 = true;
                    }
                    catch (Exception)
                    {

                    }
                }
                if (flag3)
                {


                    flag2 = false;
                    double[] input = {
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0),
                        (((double)random.Next(0,100))/100.0)
                    };
                    brain.Think(input);
                    string inputFormated = " { ";
                    for (int i = 0; i < input.Length - 1; i++)
                    {
                        inputFormated += Math.Round(input[i],2) + " : ";
                    }
                    inputFormated += Math.Round(input[input.Length - 1],2) + " } ";

                    double[] output = brain.Outputs;
                    string outputFormated = " { ";
                    for (int i = 0; i < output.Length - 1; i++)
                    {
                        outputFormated += Math.Round(output[i],4) + " : ";
                    }
                    outputFormated += Math.Round(output[output.Length - 1],4) + " } ";





                    // Displays network outputs based on the current inputs

                    if (skipAmount == 0)
                    {
                        if (displayAverage > 0)
                        {
                            Console.WriteLine("The last average score was  " + Math.Round(displayAverage, 10) );
                        }
                        Console.WriteLine("The brains response to " + inputFormated + " Was " + outputFormated);
                        Console.WriteLine("You may type a new learning rate if you want");
                        string userInput = Console.ReadLine();
                        int newLearningRate;
                        if (int.TryParse(userInput, out newLearningRate))
                        {
                            brain.LearningRate = newLearningRate;
                        }
                        skipAmount = 0;
                        Console.WriteLine("Would you like to skip iterations?");
                        string userInput2 = Console.ReadLine();
                        if (userInput2.Contains("y") || userInput2.Contains("Y"))
                        {
                            Console.WriteLine("How many iterations?");
                            string userInput3 = Console.ReadLine();
                            int.TryParse(userInput3, out skipAmount);
                        }
                    }



                    
                    double score = (output[2]-output[0]-output[1]+output[3]+2)/(4.0);
                    if (tempNumber == 0)
                    {
                        brain.Learn(averageScore);
                        displayAverage = averageScore;
                        averageScore = 0;
                        tempNumber = numberOfAverages;
                    }
                    else
                    {
                        averageScore += score / ((double)numberOfAverages);
                        tempNumber--;
                    }
                    



                    // Formats and displays all the weights
                    if (skipAmount == 0)
                    {
                        string weightsFormatted = "";
                        foreach (Layer1 layer in brain.hiddenLayers)
                        {
                            Console.WriteLine("Layer" + brain.hiddenLayers.IndexOf(layer));
                            foreach (Node1 node in layer.nodes)
                            {
                                Console.WriteLine("node: " + layer.nodes.IndexOf(node));
                                weightsFormatted = "";
                                foreach (double weight in node.weights)
                                {
                                    weightsFormatted += Math.Round(weight,2) + ", ";
                                }
                                Console.WriteLine("Weights:   " + weightsFormatted +"bias:  " + Math.Round(node.bias,2));
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                    }
                }
                if (skipAmount>0)
                {
                    skipAmount--;
                }

            } while (flag);
        }
    }
}
