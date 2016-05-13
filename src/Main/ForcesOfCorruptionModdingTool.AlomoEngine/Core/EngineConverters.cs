using System;
using System.Globalization;
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

        public static double ToEngineFloat(this string s)
        {
            s = s.Trim();
            if (string.Equals(s[s.Length - 1].ToString(), "f", StringComparison.InvariantCultureIgnoreCase))
                s = s.Remove(s.Length - 1);
            return double.Parse(s, CultureInfo.InvariantCulture);
        }

        public static int ToInteger(this string s)
        {
            s = s.Trim();
            var d = s.ToEngineFloat();
            return Convert.ToInt32(d);
        }
    }
}
