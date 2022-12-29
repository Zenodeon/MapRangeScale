using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapRangeScale
{
    public static class UUtility
    {
        public static float RangedMapClamp(float value, float InMinimum, float InMaximum, float OutMinimum, float OutMaximum)
        {
            var InRange = InMaximum - InMinimum;
            var OutRange = OutMaximum - OutMinimum;
            var finalValue = ((value - InMinimum) * OutRange / InRange) + OutMinimum;

            return finalValue;
        }

        public static int Signum(this float value)
        {
            if (value >= 0)
                return 1;
            else
                return -1;
        }
    }
}
