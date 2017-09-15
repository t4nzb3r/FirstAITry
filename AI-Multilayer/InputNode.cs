using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Multilayer
{
    class InputNode : NeuronModell
    {
        public InputNode() : base()
        {

        }

        public override void Calculate()
        {
            Output = Input;
        }
    }
}
