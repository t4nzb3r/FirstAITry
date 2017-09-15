using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Multilayer
{
    class Brain
    {
        public static double e = 2.71828182845904523536028747135266249775724709369995f;

        InputLayer inputLayer;
        HiddenLayer[] hiddenLayer;
        OutputLayer outputLayer;

        Dictionary<String, double> weights; // String format: [layer of startpoint]_[startpoint position]_[endpoint position] -> input layer = 0

        int calculateHiddenLayer_Pointer;

        public Brain()
        {
            calculateHiddenLayer_Pointer = 0;

            weights = new Dictionary<String, double>();
        }

        public void BuildNetwork(int inputLayerSize, int hiddenLayerCount, int outputLayerSize, FunctionType hiddenLayerFunction, FunctionType outputLayerFunction)
        {
            int countInputOfNeurons = 0;
            for (int i = 0; i < hiddenLayerCount; i++)
            {
                // Since the count of each hidden layer equals the count of the input layer, this works
                countInputOfNeurons += inputLayerSize * inputLayerSize;
            }
            countInputOfNeurons += inputLayerSize * inputLayerSize;

            DefineInputLayer(inputLayerSize);
            DefineHiddenLayer(hiddenLayerCount, inputLayerSize, hiddenLayerFunction, countInputOfNeurons);
            DefineOutputLayer(outputLayerSize, outputLayerFunction, countInputOfNeurons);
            DefineRandomWeights(inputLayerSize, hiddenLayerCount, outputLayerSize, countInputOfNeurons);
        }

        private void DefineInputLayer(int count)
        {
            inputLayer = new InputLayer(count);
        }

        private void DefineHiddenLayer(int layer_Count, int layerSize, FunctionType funcType, int countInputOfNeurons)
        {
            hiddenLayer = new HiddenLayer[layer_Count];
            for (int i = 0; i < hiddenLayer.Length; i++)
            {
                hiddenLayer[i] = new HiddenLayer(layerSize, funcType, countInputOfNeurons);
            }
        }

        private void DefineOutputLayer(int count, FunctionType funcType, int countInputOfNeurons)
        {
            outputLayer = new OutputLayer(count, funcType, countInputOfNeurons);
        }

        private void DefineRandomWeights(int inputLayerSize, int hiddenLayerCount, int outputLayerSize, int countInputOfNeurons)
        {
            int first = 0;
            int third = 0;

            Random r = new Random();

            for (int i = 0; i < inputLayerSize; i++)
            {
                String key = first.ToString() + "_" + i + "_";

                for (int j = 0; j < hiddenLayer[0].Count; j++)
                {
                    weights.Add(key + j, GetRandomWeightThresh(countInputOfNeurons));
                }
            }

            first = 0;
            for (int i = 0; i < hiddenLayer.Length - 1; i++)
            {
                first++;

                for (int j = 0; j < hiddenLayer[i].Count; j++)
                {
                    String key = first.ToString() + "_" + j + "_";

                    for (int k = 0; k < hiddenLayer[i + 1].Count; k++)
                    {
                        weights.Add(key + k, GetRandomWeightThresh(countInputOfNeurons));
                    }
                }
            }

            first++;
            for (int i = 0; i < hiddenLayer[hiddenLayer.Length - 1].Count; i++)
            {
                String key = first.ToString() + "_" + i + "_";

                for (int j = 0; j < outputLayer.Count; j++)
                {
                    weights.Add(key + j, GetRandomWeightThresh(countInputOfNeurons));
                }
            }

            foreach (var item in weights)
            {
                Console.WriteLine(item.Key + ":  " + item.Value);
            }
        }


        public void SendInput(double[] input)
        {
            // Make the input size fit the inputLayer size
            if (inputLayer.Count != input.Length)
            {
                List<double> cache = input.ToList();
                while (inputLayer.Count != input.Length)
                {
                    cache.Add(0);
                }
                input = cache.ToArray();
            }

            inputLayer.SendInput(input);
        }

        public void CalculateAllLayer()
        {
            // Input Nodes
            //is already done by sending input

            // Hidden Nodes (first layer, inputNode -> hiddenNodes[0], weight: "0*i")
            for (int i = 0; i < hiddenLayer[0].Count; i++)
            {
                // Select all weights (values), where the layer is 0 (input layer)
                //      where the startPoint is ignored
                //      where the endPoint is i(current hiddenLayer).
                double[] weight = weights.Where(c => c.Key.Split('_')[0].Equals("0")).Where(c => c.Key.Split('_')[2].Equals(i)).Select(c => c.Value).ToArray();
                // -> weight[0] correspondes to inputLayer.ReceiveOutput(0)
                double sum = 0;
                for (int j = 0; j < inputLayer.Count; j++)
                {
                    sum += inputLayer.ReceiveOutput(j) * weight[j];
                }

                hiddenLayer[0].SendInput(sum, i);
            }
        }


        public static double GetRandomWeightThresh(int countInputOfNeurons)
        {
            int r = new Random().Next(-24, 24);
            double output = r / countInputOfNeurons;

            return output;
        }

        public enum FunctionType
        {
            STEP, SIGN, SIGMOID, LINEAR, NONE
        }
    }
}
