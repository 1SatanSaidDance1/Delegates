using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class FloatValue : IFloatValue
    {
        public FloatValue(float value)
        {
            Value = value;
        }

        public float Value { get; }
    }
}
