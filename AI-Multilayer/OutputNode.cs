using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Multilayer
{
    class OutputNode : NeuronModell
    {
        double thresh;

        public OutputNode(Brain.FunctionType funcType, int countInputOfNeurons) : base(funcType, countInputOfNeurons)
        {

        }

        public override void Calculate()
        {
            Output = Function(Input - thresh);
        }
    }
}
