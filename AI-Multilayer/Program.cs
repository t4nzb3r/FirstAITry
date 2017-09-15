using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Multilayer
{
    class Program
    {
        static InputLayer inputLayer;
        static HiddenLayer[] hiddenLayers;
        static OutputLayer outputLayer;

        static Boolean verbose = false;

        static void Main(string[] args)
        {
            double[][] trainingData = new double[][]
            {
                new double[]{ 0, 0, 0 },
                new double[]{ 0, 1, 1 },
                new double[]{ 1, 0, 1 },
                new double[]{ 1, 1, 0 }
            };

            Brain b = new Brain();
            b.BuildNetwork(2, 1, 1, Brain.FunctionType.SIGMOID, Brain.FunctionType.SIGN);

            Console.ReadLine();
        }
    }
}
