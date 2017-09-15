using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Multilayer
{
    class HiddenNode : NeuronModell
    {
        double thresh;

        Brain.FunctionType functionType;

        public HiddenNode(Brain.FunctionType funcType, int countInputOfNeurons) : base(funcType, countInputOfNeurons)
        {

        }

        public override void Calculate()
        {
            Output = Function(Input - thresh);
        }
    }
}
