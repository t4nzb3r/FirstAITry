using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Multilayer
{
    abstract class NeuronModell
    {
        public double Output { get; set; }
        public double Input { get; set; }
        public double Thresh { get; set; }
        public Brain.FunctionType FunctionType { get; set; }

        public NeuronModell(Brain.FunctionType funcType = Brain.FunctionType.NONE, int countInputOfNeurons = 0)
        {
            Input = 0;
            Output = 0;
            FunctionType = funcType;
            Thresh = (countInputOfNeurons == 0) ? 0 : Brain.GetRandomWeightThresh(countInputOfNeurons);
        }

        public void AssignThresh()
        {
            // Set Random Thresh
        }

        public void SendInput(double input)
        {
            Input = input;
        }

        public abstract void Calculate();

        public double ReceiveOutput()
        {
            return Output;
        }

        public double Function(double x)
        {
            switch (FunctionType)
            {
                case Brain.FunctionType.LINEAR:
                    return x;
                case Brain.FunctionType.SIGMOID:
                    return 1 / (1 + Math.Pow(Brain.e, -x));
                case Brain.FunctionType.SIGN:
                    return (x < 0) ? -1 : 1;
                case Brain.FunctionType.STEP:
                    return (x < 0) ? 0 : 1;
                default:
                    return 0;
            }
        }
    }
}
