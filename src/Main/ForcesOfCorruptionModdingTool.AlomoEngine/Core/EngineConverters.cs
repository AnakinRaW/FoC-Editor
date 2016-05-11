using System;
using System.Linq;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.Core
{
    public static class EngineConverters
    {
        public static bool ToEngineBoolean(this string s)
        {
            s = s.Replace(" ", string.Empty);
            string[] trueStrings = { "1", "yes", "true" };
            string[] falseStrings = { "0", "no", "false" };


            if (trueStrings.Contains(s, StringComparer.OrdinalIgnoreCase))
                return true;
            if (falseStrings.Contains(s, StringComparer.OrdinalIgnoreCase))
                return false;

            throw new InvalidCastException("only the following are supported for converting strings to boolean: "
                + string.Join(",", trueStrings)
                + " and "
                + string.Join(",", falseStrings));
        }
    }
}
