using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Multilayer
{
    class InputLayer
    {
        InputNode[] inputNodes;
        public int Count { get; }

        public InputLayer(int inputNodes_Count)
        {
            inputNodes = new InputNode[inputNodes_Count];
            for (int i = 0; i < inputNodes.Length; i++)
            {
                inputNodes[i] = new InputNode();
            }

            Count = inputNodes_Count;
        }

        public void SendInput(double[] input)
        {
            for (int i = 0; i < inputNodes.Length; i++)
            {
                inputNodes[i].SendInput(input[i]);
            }
        }

        public void Calculate()
        {
            foreach (var item in inputNodes)
            {
                item.Calculate();
            }
        }

        public double[] ReceiveOutput()
        {
            List<double> output = new List<double>();
            foreach (var item in inputNodes)
            {
                output.Add(item.ReceiveOutput());
            }
            return output.ToArray();
        }

        public double ReceiveOutput(int index)
        {
            return inputNodes[index].Output;
        }
    }
}
