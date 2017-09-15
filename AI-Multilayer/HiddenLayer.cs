using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Multilayer
{
    class HiddenLayer
    {
        HiddenNode[] hiddenNodes;
        public double Count { get; set; }

        public HiddenLayer(int hiddenNodes_Count, Brain.FunctionType funcType, int countInputOfNeurons)
        {
            hiddenNodes = new HiddenNode[hiddenNodes_Count];
            for (int i = 0; i < hiddenNodes.Length; i++)
            {
                hiddenNodes[i] = new HiddenNode(funcType, countInputOfNeurons);
            }
            
            Count = hiddenNodes_Count;
        }

        public void SendInput(double input, int index)
        {
            hiddenNodes[index].SendInput(input);
        }

        public void Calculate()
        {
            foreach (var item in hiddenNodes)
            {
                item.Calculate();
            }
        }

        public double[] ReceiveInput()
        {
            List<double> output = new List<double>();
            foreach (var item in hiddenNodes)
            {
                item.ReceiveOutput();
            }
            return output.ToArray();
        }
    }
}
