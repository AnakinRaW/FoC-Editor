using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AlomoEngine.DataTypes
{
    public class PlanetAbilityRgbList
    {

        public PlanetAbilityRgbList(List<EngineColor> fileTable)
        {
            Table = fileTable;
        }

        public List<EngineColor> Table { get; set; }

        public static PlanetAbilityRgbList CreateFromString(string s)
        {
            s = s.Trim();
            s = Regex.Replace(s, @"\t|\n|\r", "");
            if (s.EndsWith(","))
                s = s.Remove(s.Length - 1);
            var list = new List<EngineColor>();
            var primeArray = s.Split(',');
            for (var i = 0; i < primeArray.Length; i += 3)
            {
                var first = primeArray[i];
                var second = primeArray[i + 1];
                var third = primeArray[i + 2];

                var r = byte.Parse(first);
                var g = byte.Parse(second);
                var b = byte.Parse(third);
                list.Add(new EngineColor(r, g, b));
            }
            return new PlanetAbilityRgbList(list);
        }

        public override string ToString()
        {
            var result = Table.Aggregate(string.Empty, (current, color) => current + $"{color.ToString(false)}, ");
            result = result.Remove(result.Length - 2, 2);
            return result;
        }

        public string ToString(bool forceNewLine)
        {
            if (!forceNewLine)
                return ToString();
            var result = Table.Aggregate(string.Empty, (current, color) => current + $"{color.ToString(false)},\r\n");
            result = result.Remove(result.Length - 3, 1);
            return result;
        }
    }
}
