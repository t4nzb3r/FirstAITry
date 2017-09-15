using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Multilayer
{
    class OutputLayer
    {
        OutputNode[] outputNodes;
        public int Count { get; set; }

        public OutputLayer(int count, Brain.FunctionType funcType, int countInputOfNeurons)
        {
            outputNodes = new OutputNode[count];
            for (int i = 0; i < outputNodes.Length; i++)
            {
                outputNodes[i] = new OutputNode(funcType, countInputOfNeurons);
            }

            Count = count;
        }
    }
}
