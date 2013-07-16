using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public enum Comparison
    {
        Equal,
        GreatorThan,
        LessThan,
        GreatorThanEqualTo,
        LessTanEqualTo,
        LeftLike,
        RightLike,
        BothLike,
    }

    public static class ComparisonHelper
    {
        public static string ToOperator(this Comparison comparison)
        {
            switch (comparison)
            {
                case Comparison.Equal:
                    return "=";
                case Comparison.GreatorThan:
                    return ">";
                case Comparison.GreatorThanEqualTo:
                    return ">=";
                case Comparison.LessTanEqualTo:
                    return "<=";
                case Comparison.LessThan:
                    return "<";
                default:
                    throw new InvalidCastException();
            }

        }
    }
}
